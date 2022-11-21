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
    public partial class Form2 : Form
    {
        public string id { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            adminId.Text = id;
            adminRole.Text = role;
            adminName.Text = name;
            adminUsername.Text = username;
            adminPassword.Text = password;
        }
    }
}
