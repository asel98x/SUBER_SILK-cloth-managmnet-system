using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WebApplication1;

namespace client
{
    public partial class account : Form
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
        int count = 1;
        public account()
        {
            InitializeComponent();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void Guna2GradientButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to logout?", "LOGOUT ACCOUNT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                login l1 = new login();
                this.Hide();
                l1.Show();
            }
        }

        public void  hide_propaties()
        {
            pb_icon.Hide();
            label1.Hide();
            label3.Hide();
            label2.Hide();
            label7.Hide();
            label8.Hide();
            label4.Hide();
            label5.Hide();
            guna2Separator2.Hide();
            guna2Separator3.Hide();
            btnMiner.Hide();
            lbl_quantity.Hide();
            guna2CircleButton1.Hide();
            label6.Hide();
            lbl_total.Hide();
            btn_Cart.Hide();
            btnBuy.Hide();   
        }

        public void show_propaties()
        {
            pb_icon.Show();
            label1.Show();
            label3.Show();
            label2.Show();
            label7.Show();
            label8.Show();
            label4.Show();
            label5.Show();
            guna2Separator2.Show();
            guna2Separator3.Show();
            btnMiner.Show();
            lbl_quantity.Text = "1";
            lbl_quantity.Show();
            guna2CircleButton1.Show();
            label6.Show();
            lbl_total.Show();
            btn_Cart.Show();
            btnBuy.Show();
        }

        private void MenuBtn1_Click(object sender, EventArgs e)
        {
            flp_product_list.Show();
            panel1.Show();
            panel2.Show();
            stock1.Hide();
            order1.Hide();
            order_history1.Hide();
            profile1.Hide();
        }

        private void MenuBtn2_Click(object sender, EventArgs e)
        {
            flp_product_list.Hide();
            panel1.Hide();
            panel2.Hide();
            stock1.Hide();

            order1.id = id;


            order1.Show();


            order1.get_details();
            order1.view_list();

            hide_propaties();
            order_history1.Hide();
            profile1.Hide();
        }

        private void MenuBtn3_Click(object sender, EventArgs e)
        {
            flp_product_list.Hide();
            panel1.Hide();
            panel2.Hide();
            stock1.Hide();
            order1.Hide();
            order_history1.Show();
            hide_propaties();
            profile1.Hide();
        }

        private void MenuBtn4_Click(object sender, EventArgs e)
        {
            flp_product_list.Hide();
            panel1.Hide();
            panel2.Hide();
            stock1.Hide();
            order1.Hide();
            order_history1.Hide();
            profile1.Show();
            hide_propaties();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            //txtId.Text = id;
            profile1.id = id;
            profile1.name = name;
            profile1.address = address;
            profile1.mobile = mobile;
            profile1.nic = nic;
            profile1.birthday = birthday;
            profile1.email = email;
            profile1.age = age;
            profile1.username = username;
            profile1.password = password;
            profile1.get_details();
            GenerateDynamicUserControl();
            hide_propaties();

        }

        private void GenerateDynamicUserControl()
        {
            flp_product_list.Controls.Clear();

            DataTable dt = suber_service.GetItems(); 

            if (dt != null) 
            {
                if (dt.Rows.Count > 0) 
                {
                    custom_product[] listItems = new custom_product[dt.Rows.Count];
                    //flp_product_list.AutoSize = true;
                    //flp_product_list.AutoSizeMode = AutoSizeMode.GrowAndShrink;


                    for (int i = 0; i < 1; i++) 
                    {
                        foreach (DataRow row in dt.Rows) 
                        {
                            listItems[i] = new custom_product();
                            //listItems[i].Width = flp_product_list.Width();
                            MemoryStream ms = new MemoryStream((byte[])row["Image"]);

                            listItems[i].Icon = new Bitmap(ms);
                            listItems[i].price = row["price"].ToString();
                            listItems[i].name = row["name"].ToString();
                            listItems[i].description = row["description"].ToString();
                            listItems[i].category = row["category"].ToString();
                            listItems[i].availability = row["availability"].ToString();


                            flp_product_list.Controls.Add(listItems[i]);

                            listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data not found! 1");
                }
            }
            else
            {
                MessageBox.Show("Data not found! 2");
            }
        }

        void UserControl_Click(object sender, EventArgs e)
        {
            custom_product obj = (custom_product)sender; // user control object to access controls used in it like( icon, title and sub title)


            pb_icon.Image = obj.Icon;
            label1.Text = obj.name;
            label2.Text = "" + obj.price;
            lbl_total.Text = "" + obj.price;
            label3.Text = obj.description;
            label4.Text = obj.category;

            showpanel();
        }
        private void showpanel()
        {
            show_propaties();
            panel1.Visible = true;
        }

        private void GenerateDynamicUserControl2()
        {
            flp_product_list.Controls.Clear();

            string name = bunifuTextBox1.Text;
            DataTable dt = suber_service.GetItem(name);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    custom_product[] listItems = new custom_product[dt.Rows.Count];


                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            listItems[i] = new custom_product();
                            //listItems[i].Width = flp_product_list.Width();
                            MemoryStream ms = new MemoryStream((byte[])row["Image"]);

                            listItems[i].Icon = new Bitmap(ms);
                            listItems[i].price = row["price"].ToString();
                            listItems[i].name = row["name"].ToString();
                            listItems[i].description = row["description"].ToString();
                            listItems[i].category = row["category"].ToString();
                            listItems[i].availability = row["availability"].ToString();


                            flp_product_list.Controls.Add(listItems[i]);

                            listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data not found!");
                }
            }
            else
            {
                MessageBox.Show("Data not found!");
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        public void incriment()
        {
            count++;
            lbl_quantity.Text=""+count;
            totalCalculate();
        }

        public void dicriment()
        {
            if (count <= 1) count = 1;
            else count--;
            lbl_quantity.Text = "" + count;
            totalCalculate();
        }
        
        public void totalCalculate()
        {
            double price, ttl;
            int qty;

                price = Convert.ToDouble(label2.Text);
                qty = Convert.ToInt32(lbl_quantity.Text);

                ttl = price * qty;
                lbl_total.Text = "" + ttl;
            
        }

        private void BtnMiner_Click(object sender, EventArgs e)
        {
           dicriment();
        }

        private void Guna2CircleButton1_Click(object sender, EventArgs e)
        {
            incriment();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void BunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            GenerateDynamicUserControl2();
        }

        private void Btn_Cart_Click(object sender, EventArgs e)
        {
            //string clientId = id;
            string itemName = label1.Text;
            string itemCategory = label4.Text;
            string itemPrice = label2.Text;
            string itemQuantity = lbl_quantity.Text;
            string total = lbl_total.Text;

            try
            {
                    if (suber_service.insertToCart(id, name, address, mobile, itemName, itemCategory, itemPrice, itemQuantity, total) > 0)
                    {
                        hide_propaties();
                        MessageBox.Show("Item added to your cart");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void Guna2GradientButton3_Click(object sender, EventArgs e)
        {
            add_to_cart cart = new add_to_cart();
            cart.clientId = id;
            cart.clientName = name;
            cart.clientAddress = address;
            cart.clientMobile = mobile;
            cart.Show();
            cart.view_list();
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            string itemName = label1.Text;
            string itemCategory = label4.Text;
            string itemPrice = label2.Text;
            string itemQuantity = lbl_quantity.Text;
            string total = lbl_total.Text;

            try
            {
                DialogResult dr = MessageBox.Show("Are you sure that you want to buy now?", "BUY NEW MATERIAL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (suber_service.insertDirectToOrder(id, name, address, mobile, itemName, itemCategory, itemPrice, itemQuantity, total) > 0)
                    {
                        hide_propaties();
                        MessageBox.Show("Successfully order completed!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
