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

namespace suber_silk
{
    public partial class client_list : Form
    {
        suber_silk_service suber_service = new suber_silk_service();
        public client_list()
        {
            InitializeComponent();
            AllClient_list();
        }

        private void DgvClient_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void AllClient_list()
        {
            try
            {
                DataSet ds = suber_service.sellectAllClient();
                if (ds.Tables[0].Rows.Count > 0)
                {
                   dgvClient_list.DataSource = ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void BtnSearh_Click(object sender, EventArgs e)
        {
            
        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtID_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TxtID_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                string id = txtID.Text;
                DataSet ds = suber_service.get_client_details(id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvClient_list.DataSource = ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearh_Click_1(object sender, EventArgs e)
        {

        }
    }
}
