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
using System.IO;
using System.Data.SqlClient;

namespace suber_silk
{
    public partial class stock : UserControl
    {
        suber_silk_service suber_service = new suber_silk_service();
        string imgLocation = "";
       
        public stock()
        {
            InitializeComponent();
            AllStock();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtTime.Text = DateTime.Now.ToLongTimeString();

            categoryView();
        }

        public void categoryView()
        {
            string material = cmb_category.Text;
            DataSet ds = suber_service.get_all_materials();
            cmb_category.DataSource = ds.Tables[0];
            cmb_category.DisplayMember = "material";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void BtnGetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                open.Filter = "(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = open.FileName.ToString();
                    p.ImageLocation = imgLocation;

                }
            }
        }


        private void Btn_cloth_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_category.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDiscription.Text) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection("Server=DESKTOP-104HPCC\\SQLEXPRESS;Database=saber_silk;Integrated Security=true");
                try
                {
                    DialogResult dr = MessageBox.Show("Are you sure that you want to insert new stock record?", "INSERT NEW RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        byte[] images = null;
                        FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                        BinaryReader brs = new BinaryReader(stream);
                        images = brs.ReadBytes((int)stream.Length);

                        con.Open();

                        string category = cmb_category.Text;
                        string name = txtName.Text;
                        string description = txtDiscription.Text;
                        string availability = txtQuantity.Text;
                        double price = Convert.ToDouble(txtPrice.Text);

                        string sqlQuary = "insert into stock (category, name, image,description,availability, price) values ('" + category + "'," +
                                            "'" + name + "',@images,'" + description + "','" + availability + "','" + price + "')";

                        cmd = new SqlCommand(sqlQuary, con);
                        cmd.Parameters.Add(new SqlParameter("@images", images));
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                        AllStock();
                        MessageBox.Show("Stock record inserted!");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Record not inserted!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_category.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDiscription.Text) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else if (textID.Text == "id")
            {
                MessageBox.Show("ID doen not exist!");
            }
            else
            {
                SqlConnection con = new SqlConnection("Server=DESKTOP-104HPCC\\SQLEXPRESS;Database=saber_silk;Integrated Security=true");

                try
                {
                    //byte[] images = null;
                    //FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    //BinaryReader brs = new BinaryReader(stream);
                    //images = brs.ReadBytes((int)stream.Length);

                    string id = textID.Text;
                    string category = cmb_category.Text;
                    string name = txtName.Text;
                    string description = txtDiscription.Text;
                    string availability = txtQuantity.Text;
                    double price = Convert.ToDouble(txtPrice.Text);
                    con.Open();
                    string sqlQuary = "update stock set category = @category, name =@name , description = @description," +
                                        " image=@image, availability = @availability, price = @price where id=@id";

                    SqlCommand cmd = new SqlCommand(sqlQuary, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@image", updatePhoto());
                    cmd.Parameters.AddWithValue("@availability", availability);
                    cmd.Parameters.AddWithValue("@price", price);
                    int n = cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Stock record updated!");
                    clear();
                    AllStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error - " + ex);
                }
            }

        }

        private byte[] updatePhoto()
        {
            MemoryStream ms = new MemoryStream();
            BtnGetImage.Image.Save(ms, BtnGetImage.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Field can not be empty!");
            }
            else
            {

                try
                {

                    DataSet ds = suber_service.selectStock(id,id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        textID.Text = ds.Tables[0].Rows[0][0].ToString();
                        cmb_category.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                        byte[] img = (byte[])ds.Tables[0].Rows[0][3];
                        txtDiscription.Text = ds.Tables[0].Rows[0][4].ToString();
                        txtQuantity.Text = ds.Tables[0].Rows[0][5].ToString();
                        txtPrice.Text = ds.Tables[0].Rows[0][6].ToString();

                        if (img == null)
                        {
                            BtnGetImage.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            BtnGetImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        
                        MessageBox.Show("Stock record not found!");
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

        public void clear()
        {
            textID.Text = "id";
            txtID.Text = null;
            cmb_category.Text = null;
            txtName.Text = null;
            BtnGetImage.Image = default;
            txtDiscription.Text = null;
            txtQuantity.Text = null;
            txtPrice.Text = null;
            txtName.Focus();
        }

        public void AllStock()
        {
            try
            {
                DataSet ds = suber_service.sellectAllStock();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvStock.DataSource = ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = textID.Text;
            if (id == "id")
            {
                MessageBox.Show("ID does not exist!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure that you want to delete stock record?", "DELETE Stock RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {


                        if (suber_service.deleteStock(id) > 0)
                        {
                            AllStock();
                            MessageBox.Show("Stock record deleted!");
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

        private void TxtDate_Click(object sender, EventArgs e)
        {

        }

        private void TxtTime_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Stock_Click(object sender, EventArgs e)
        {
            categoryView();
        }
    }
}
