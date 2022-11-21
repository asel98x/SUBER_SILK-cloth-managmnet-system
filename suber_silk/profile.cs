using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suber_silk
{
    public partial class profile : UserControl
    {
        public string id { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public profile()
        {
            InitializeComponent();
        }
        private void AdminId_Click(object sender, EventArgs e)
        {
        }
        private void Profile_Load(object sender, EventArgs e)
        {
            adminId.Text = id;
            adminRole.Text = role;
            adminName.Text = name;
            adminUsername.Text = username;
            adminPassword.Text = password;
        }
    }
}
