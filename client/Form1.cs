//using client.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication1;

namespace client
{
    public partial class Form1 : Form
    {
        suber_silk_service suber_service = new suber_silk_service();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            login l1 = new login();
            this.Hide();
            l1.Show();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string role = "client";
            string name = txtName.Text;
            string address = txtAddress.Text;
            string nic = txtNic.Text;
            string birthday = txtBirthday.Text;
            string email = txtEmail.Text;
            string username = txtName.Text;
            string password = txtPassword.Text;
            string time = txtTime.Text;
            string date = txtDate.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(nic) || string.IsNullOrEmpty(birthday) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else if (nic.Length <= 9 || nic.Length >= 11)
            {
                MessageBox.Show("Invalid NIC!");
            }
            else if (txtMobile.Text.Length <= 9 || txtMobile.Text.Length >= 11)
            {
                MessageBox.Show("Invalid mobile number!");
            }
            else if (txtAge.Text.Length <= 1 || txtAge.Text.Length >= 3)
            {
                MessageBox.Show("Invalid age!");
            }
            else if (password.Length <= 7)
            {
                MessageBox.Show("Password should be more than 8 characters!");
            }
            else
            {

                DialogResult dr = MessageBox.Show("Are you sure that your details are correct?", "SIGNUP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        int mobile = Convert.ToInt32(txtMobile.Text);
                        int age = Convert.ToInt32(txtAge.Text);


                        if (suber_service.insertClient(role, name, address, mobile, nic, birthday, email, age, username, password, time, date) > 0)
                        {
                            MessageBox.Show("You are successfully singup!");
                            login l1 = new login();
                            this.Hide();
                            l1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Record not found!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }
                }
            }
        }

        
    }
}
