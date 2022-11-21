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
    
    public partial class add_to_cart : Form
    {
        suber_silk_service suber_service = new suber_silk_service();

        public string id { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public int clientMobile { get; set; }
        public string itemName { get; set; }
        public string itemCategory { get; set; }
        public string itemPrice { get; set; }
        public string itemQuantity { get; set; }
        public string total { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public add_to_cart()
        {
            InitializeComponent();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Add_to_cart_Load(object sender, EventArgs e)
        {
            //view_list();
        }

        public void view_list()
        {
            string s = "5";
            try
            {
                DataSet ds = suber_service.view_client_cart(clientId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bunifuDataGridView1.DataSource = ds.Tables[0];
                    cart_total();
                }
                else
                {
                    label1.Hide();
                    label2.Show();
                    label8.Hide();
                    label3.Hide();
                    btnBuy.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        public void cart_total()
        {
            label1.Show();
            label3.Show();
            label2.Hide();
            label8.Show();
            btnBuy.Show();
            try
            {
                DataSet ds = suber_service.view_client_cart_total(clientId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    label1.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want Buy?", "BUY NOW", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    suber_service.insertToOrder(clientId);

                    MessageBox.Show("Order completed successfully!");
                    cart_delete();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        private void Guna2GradientButton3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to clear your cart list?", "CLEAR CART LIST", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                cart_delete();
            }
        }

        public void cart_delete()
        {
            try
            {
                string s = "3";
                if (suber_service.deletecart(clientId) > 0)
                {
                    MessageBox.Show("Your cart list is empty!");
                    cart_total();
                    view_list();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
