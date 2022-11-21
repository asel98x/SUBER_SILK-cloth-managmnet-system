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

namespace suber_silk
{
    public partial class login : Form
    {
        suber_silk_service suber_service = new suber_silk_service();
        public login()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else {
                try
                {
                    DataSet ds = suber_service.admin_login(name, pass);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (ds.Tables[0].Rows[0][3].ToString().Equals(name) && ds.Tables[0].Rows[0][4].ToString().Equals(pass))
                        {

                            string id = ds.Tables[0].Rows[0][0].ToString();
                            string role = ds.Tables[0].Rows[0][1].ToString();
                            string Fname = ds.Tables[0].Rows[0][2].ToString();
                            string username = ds.Tables[0].Rows[0][3].ToString();
                            string password = ds.Tables[0].Rows[0][4].ToString();
                            Form1 fm = new Form1();
                            MessageBox.Show("Successfully loged in!");
                            fm.name = Fname;
                            this.Hide();
                            
                            fm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password!");
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

        public void get_user_details()
        {
            string name = txtUsername.Text;
            string pass = txtPassword.Text;

            DataSet ds = suber_service.admin_login(name, pass);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string id = ds.Tables[0].Rows[0][0].ToString();
                string role = ds.Tables[0].Rows[0][1].ToString();
                string Fname = ds.Tables[0].Rows[0][2].ToString();
                string username = ds.Tables[0].Rows[0][3].ToString();
                string password = ds.Tables[0].Rows[0][4].ToString();

                Form2 pf = new Form2();
                pf.id = id;
                pf.role = role;
                pf.name = Fname;
                pf.username = username;
                pf.password = password;
            }
        }
    }
}
