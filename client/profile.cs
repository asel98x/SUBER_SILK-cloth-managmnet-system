using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using WebApplication1;

namespace client
{
    public partial class profile : UserControl
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


        public profile()
        {
            InitializeComponent();
        }


        private void Guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Profile_Load(object sender, EventArgs e)
        {
            
        }

        public void get_details(){
            //txtId.Text = id;
            //txtName.Text = name;
            //txtAddress.Text = address;
            //txtMobile.Text = mobile+"";
            //txtNic.Text = nic;
            //txtBirthday.Text = birthday;
            //txtEmail.Text = email;
            //txtAge.Text = age+"";

            DataSet ds = suber_service.selectClient2(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtId.Text = ds.Tables[0].Rows[0][0].ToString();
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
                txtNic.Text = ds.Tables[0].Rows[0][5].ToString();
                txtBirthday.Text = ds.Tables[0].Rows[0][6].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][7].ToString();
                txtAge.Text = ds.Tables[0].Rows[0][8].ToString();
            }

        }

        private void BtnSettings_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            update_client update = new update_client();
            update.id = id;
            update.name = name;
            update.address = address;
            update.mobile = mobile;
            update.nic = nic;
            update.birthday = birthday;
            update.email = email;
            update.age = age;
            update.username = username;
            update.password = password;
            update.get_details();

            update.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            get_details();
        }
    }
}
