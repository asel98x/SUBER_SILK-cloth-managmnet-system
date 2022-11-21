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
using BL;
using WebApplication1;

namespace client
{
    public partial class login : Form
    {
        suber_silk_service suber_service = new suber_silk_service();
        public login()
        {
            InitializeComponent();
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else
            {
                try
                {
                    DataSet ds = suber_service.client_login(name, pass);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (ds.Tables[0].Rows[0][9].ToString().Equals(name) && ds.Tables[0].Rows[0][10].ToString().Equals(pass))
                        {

                            string id = ds.Tables[0].Rows[0][0].ToString();
                            string Fname = ds.Tables[0].Rows[0][2].ToString();
                            string adress = ds.Tables[0].Rows[0][3].ToString();
                            int mobile =Convert.ToInt32(ds.Tables[0].Rows[0][4]);
                            string nic = ds.Tables[0].Rows[0][5].ToString();
                            string birthday = ds.Tables[0].Rows[0][6].ToString();
                            string email = ds.Tables[0].Rows[0][7].ToString();
                            int age = Convert.ToInt32(ds.Tables[0].Rows[0][8]);
                            string username = ds.Tables[0].Rows[0][9].ToString();
                            string password = ds.Tables[0].Rows[0][10].ToString();

                            account acc = new account();
                            success_messageBox dialog = new success_messageBox();
                            dialog.ShowDialog();
                            this.Hide();
                            acc.id = id;
                            acc.name = Fname;
                            acc.address = adress;
                            acc.mobile = mobile;
                            acc.nic = nic;
                            acc.birthday = birthday;
                            acc.email = email;
                            acc.age = age;
                            acc.username = username;
                            acc.password = password;
                           
                            acc.Show();

                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password123!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error - " + ex);
                }
            }
        }

        

        private void Label9_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.ShowDialog();
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }
    }
}
