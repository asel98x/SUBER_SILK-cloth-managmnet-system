using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suber_silk
{
    public partial class Form1 : Form
    {
        public string name { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            stock1.categoryView();
            stock1.Show();
            order1.Hide();
            client1.Hide();
            admin1.Hide();
            profile1.Hide();
            material1.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            stock1.Hide();
            order1.Hide();
            client1.Show();
            admin1.Hide();
            profile1.Hide();
            material1.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            stock1.Hide();
            order1.Hide();
            client1.Hide();
            admin1.Show();
            profile1.Hide();
            material1.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            stock1.Hide();
            order1.Hide();
            client1.Hide();
            admin1.Hide();
            profile1.Show();
            material1.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            stock1.Hide();
            order1.Hide();
            client1.Hide();
            admin1.Hide();
            profile1.Hide();
            material1.Show();
        }

        private void Stock1_Load(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to logout?", "LOGOUT PROFILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                login l1 = new login();
                this.Hide();
                l1.Show();
            }
                
        }

        private void Stock1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adminName.Text = name;
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            stock1.Hide();
            order1.Show();
            client1.Hide();
            admin1.Hide();
            profile1.Hide();
            material1.Hide();
        }

        private void Stock1_Load_2(object sender, EventArgs e)
        {

        }
    }
}
