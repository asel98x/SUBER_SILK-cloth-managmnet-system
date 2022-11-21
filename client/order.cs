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

namespace client
{
    public partial class order : UserControl
    {
        suber_silk_service suber_service = new suber_silk_service();
        public string id { get; set; }
        public string orderId { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public int clientMobile { get; set; }
        public string itemName { get; set; }
        public string itemCategory { get; set; }
        public string itemPrice { get; set; }
        public string itemQuantity { get; set; }
        public string total { get; set; }

        public order()
        {
            InitializeComponent();
        }

        public void get_details()
        {
            //MessageBox.Show(""+ id);
        }

        public void view_list()
        {
            try
            {
                DataSet ds = suber_service.view_client_order(id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgv_order.DataSource = ds.Tables[0];
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
