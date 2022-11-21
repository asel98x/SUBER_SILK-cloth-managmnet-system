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

namespace suber_silk
{
    public partial class order : UserControl
    {
        suber_silk_service suber_service = new suber_silk_service();
        public order()
        {
            InitializeComponent();
            
        }

        public void AllClient_list()
        {
            try
            {
                DataSet ds = suber_service.sellectAllOrders();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgv_orders.DataSource = ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void Order_Load(object sender, EventArgs e)
        {
            AllClient_list();
        }
    }
    
}
