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
    public partial class update_client : Form
    {
        suber_silk_service suber_service = new suber_silk_service();

        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int mobile { get; set; }
        public string nic { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public update_client()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string nic = txtNic.Text;
            string dob = txtBirthday.Text;
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int age = Convert.ToInt32(txtAge.Text);
            int mobile = Convert.ToInt32(txtMobile.Text);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(nic) || string.IsNullOrEmpty(dob) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else if (nic.Length <= 9 || nic.Length >= 11)
            {
                MessageBox.Show("Invalid NIC!");
            }
            else if (txtAge.Text.Length <= 1 || txtAge.Text.Length >= 3)
            {
                MessageBox.Show("Invalid age!");
            }
            else if (txtMobile.Text.Length <= 8 || txtMobile.Text.Length >= 11)
            {
                MessageBox.Show("Invalid mobile number!");
            }
            else if (password.Length <= 7)
            {
                MessageBox.Show("Password should be more than 8 characters!");
            }
            else
            {

                DialogResult dr = MessageBox.Show("Are you sure that you want to update your profile?", "UPDATE PROFILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        

                        if (suber_service.updateClient(id,name, address, mobile, nic, dob, email, age, username, password) > 0)
                        {
                            MessageBox.Show("client record updated!");
                            
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Error while updating!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }
                }
            }
        }


        public void get_details()
        {
            txtId.Text = id;
            txtName.Text = name;
            txtAddress.Text = address;
            txtMobile.Text = mobile + "";
            txtNic.Text = nic;
            //txtBirthday.Text = birthday;
            DateTime dob = Convert.ToDateTime(birthday);
            txtBirthday.Value = dob;
            txtEmail.Text = email;
            txtAge.Text = age + "";
            txtUsername.Text = username;
            txtPassword.Text = password;
        }

        private void Update_client_Load(object sender, EventArgs e)
        {
            
        }
    }
}
