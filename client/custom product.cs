using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class custom_product : Bunifu.UI.WinForms.BunifuUserControl
    {
        public custom_product()
        {
            InitializeComponent();
        }

        private Image _icon;
        private string _price;
        private string _name;
        private string _description;
        private string _category;
        private string _availability;

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; img_product.Image = value; }
        }

        [Category("Custom Props")]
        public string price
        {
            get { return _price; }
            set { _price = value; lbl_price.Text = value; }
        }

        [Category("Custom Props")]
        public string name
        {
            get { return _name; }
            set { _name = value; lbl_name.Text = value; }
        }

        [Category("Custom Props")]
        public string description
        {
            get { return _description; }
            set { _description = value; lbl_description.Text = value; }
        }

        [Category("Custom Props")]
        public string category
        {
            get { return _category; }
            set { _category = value; lbl_category.Text = value; }
        }

        [Category("Custom Props")]
        public string availability
        {
            get { return _availability; }
            set { _availability = value; lbl_availability.Text = value; }
        }

        private void Custom_product_MouseEnter(object sender, EventArgs e)
        {

            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void Custom_product_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void Lbl_name_Click(object sender, EventArgs e)
        {

        }
    }
}
