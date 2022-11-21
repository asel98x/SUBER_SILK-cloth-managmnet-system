using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication1;

namespace suber_silk
{
    public partial class client : UserControl
    {
        suber_silk_service suber_service = new suber_silk_service();
        public client()
        {
            InitializeComponent();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }

       

        private void BtnSearh_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Field can not be empty!");
            }
            else
            {
                try
                {

                    DataSet ds = suber_service.selectClient(id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtID.Text = ds.Tables[0].Rows[0][0].ToString();
                        txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
                        texNic.Text = ds.Tables[0].Rows[0][5].ToString();
                        DateTime dob = Convert.ToDateTime(ds.Tables[0].Rows[0][6].ToString());
                        txtDob.Value = dob;
                        //txtDob.Text = ds.Tables[0].Rows[0][6].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0][7].ToString();
                        txtAge.Text = ds.Tables[0].Rows[0][8].ToString();
                        txtUsername.Text = ds.Tables[0].Rows[0][9].ToString();
                        txtPassword.Text = ds.Tables[0].Rows[0][10].ToString(); 
                    }
                    else
                    {
                        clear();
                        MessageBox.Show("Client record not found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error - " + ex);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            string id2 = txtID.Text;
            if (id2 == "id")
            {
                MessageBox.Show("ID does not exist!");
            }
            else { 

            DialogResult dr = MessageBox.Show("Are you sure that you want to delete client record?", "DELETE CLIENT RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (suber_service.deleteClient(id) > 0)
                        {
                            MessageBox.Show("Client record deleted!");
                            clear();

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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            string role = txtRole.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string nic = texNic.Text;
            string birthday = txtDob.Text;
            string email = txtEmail.Text;
            string username = txtUsername.Text;
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
            else if (txtMobile.Text.Length<=9 || txtMobile.Text.Length >= 11)
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
            else { 

            DialogResult dr = MessageBox.Show("Are you sure that you want to insert new client record?", "INSERT NEW RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        int mobile = Convert.ToInt32(txtMobile.Text);
                        int age = Convert.ToInt32(txtAge.Text);


                        if (suber_service.insertClient(role, name, address, mobile, nic, birthday, email, age, username, password, time, date) > 0)
                        {
                            MessageBox.Show("Client record inserted!");
                            clear();
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

        private void clear()
        {
            txtSearch.Text = null;
            txtID.Text = "id";
            txtName.Text = null;
            txtAddress.Text = null;
            txtMobile.Text = null;
            texNic.Text = null;
            txtDob.Text = null;
            txtEmail.Text = null;
            txtAge.Text = null;
            txtPassword.Text = null;
            txtUsername.Text = null;
            txtName.Focus();
        }

        private void BtnErase_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string nic = texNic.Text;
            string dob = txtDob.Text;
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

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
            else { 

            DialogResult dr = MessageBox.Show("Are you sure that you want to UPDATE client record?", "UPDATE CLIENT RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        int age = Convert.ToInt32(txtAge.Text);
                        int mobile = Convert.ToInt32(txtMobile.Text);

                        if (suber_service.updateClient(id,name, address, mobile, nic, dob, email, age, username, password) > 0)
                        {
                            MessageBox.Show("client record updated!");
                            clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }
                }
            }
        }

        private void Btn_client_list_Click(object sender, EventArgs e)
        {
            client_list Clist = new client_list();
            Clist.Show();
        }
    }
}
