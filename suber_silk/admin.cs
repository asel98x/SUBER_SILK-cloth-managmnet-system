using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WebApplication1;

namespace suber_silk
{
    public partial class admin : UserControl
    {
        suber_silk_service suber_service = new suber_silk_service();

        public admin()
        {

            InitializeComponent();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtTime.Text = DateTime.Now.ToLongTimeString();
            AllAdmin();
                   }

        private void Btn_admin_add_Click(object sender, EventArgs e)
        {
            //string id = txtID.Text;
            string role = txtRole.Text;
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string time = txtTime.Text;
            string date = txtDate.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else if (password.Length<=7)
            {
                MessageBox.Show("Password should be more than 8 characters!");
            }
            else
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Are you sure that you want to insert new admin record?", "INSERT NEW RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {


                        if (suber_service.insertAdmin(role, name, username, password, time, date) > 0)
                        {
                            AllAdmin();
                            MessageBox.Show("Admin record inserted!");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        

        public void clear()
        {
            textID.Text="id";
            txtID.Clear();
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtName.Focus();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {  
        }

        private void F_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Text field can not be empty!");
            }
            else
            {
                try
                {

                    DataSet ds = suber_service.selectAdmin(id,id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        textID.Text = ds.Tables[0].Rows[0][0].ToString();
                        txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                        txtUsername.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtPassword.Text = ds.Tables[0].Rows[0][4].ToString();
                    }
                    else
                    {
                        clear();
                        MessageBox.Show("Admin record not found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error - " + ex);
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = textID.Text;

            if (id == "id")
            {
                MessageBox.Show("ID not exsit!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure that you want to delete admin record?", "DELETE ADMIN RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {


                        if (suber_service.deleteAdmin(id) > 0)
                        {
                            AllAdmin();
                            MessageBox.Show("Admin record deleted!");
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

        private void Button1_Click_2(object sender, EventArgs e)
        {
            AllAdmin();
        }

        public void AllAdmin()
        {
            try
            {
                DataSet ds = suber_service.sellectAllAdmin();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvAdmin.DataSource = ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
           }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id = textID.Text;
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if  (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else if (password.Length <= 7)
            {
                MessageBox.Show("Password should be more than 8 characters!");
            }
            else if (textID.Text == "id")
            {
                MessageBox.Show("ID doen not exist!");
            }
            else{ 
            DialogResult dr = MessageBox.Show("Are you sure that you want to update admin record?", "UPDATE ADMIN RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (suber_service.updateAdmin(name, username, password) > 0)
                        {
                            AllAdmin();
                            MessageBox.Show("Admin record updated!");
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

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void DgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dgvAdmin.Rows[e.RowIndex];
            //    textID.Text = row.Cells["id"].Value.ToString();
            //    txtName.Text = row.Cells["name"].Value.ToString();
            //    txtUsername.Text = row.Cells["username"].Value.ToString();
            //    txtPassword.Text = row.Cells["password"].Value.ToString();
            //}
        }

        private void TxtID_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
