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
    public partial class material : UserControl
    {
        suber_silk_service suber_service = new suber_silk_service();
        public material()
        {
            InitializeComponent();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtTime.Text = DateTime.Now.ToLongTimeString();
            AllAdmin();
        }

        private void Btn_material_add_Click(object sender, EventArgs e)
        {
            string material = txtMaterial.Text;
            string description = txtDescription.Text;

            if (string.IsNullOrEmpty(material) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Fields can not be empty!");
            }
            else
            {

                try
                {
                    DialogResult dr = MessageBox.Show("Are you sure that you want to insert new material record?", "INSERT NEW RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {


                        if (suber_service.insertMaterial(material, description) > 0)
                        {
                            AllAdmin();
                            MessageBox.Show("Material record inserted!");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Record not inserted!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        public void clear()
        {
            textID.Text="id";
            txtID.Clear();
            txtMaterial.Clear();
            txtDescription.Clear();
            txtMaterial.Focus();
        }

        public void AllAdmin()
        {
            try
            {
                DataSet ds = suber_service.sellectAllMaterial();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvMaterials.DataSource = ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id = textID.Text;
            string Material = txtMaterial.Text;
            string Description = txtDescription.Text;

            if (string.IsNullOrEmpty(Material) || string.IsNullOrEmpty(Description))
            {
                MessageBox.Show("Fields can not be empty!");
            }else if (id == "id")
            {
                MessageBox.Show("ID does not exist!");
            }
            else { 

            DialogResult dr = MessageBox.Show("Are you sure that you want to update Material record?", "UPDATE MATERIAL RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (suber_service.updateMaterial(Material, Description) > 0)
                        {
                            AllAdmin();
                            MessageBox.Show("Material record updated!");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }
                }
            }
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

                    DataSet ds = suber_service.selectMaterial(id, id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        textID.Text = ds.Tables[0].Rows[0][0].ToString();
                        txtMaterial.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtDescription.Text = ds.Tables[0].Rows[0][2].ToString();
                    }
                    else
                    {
                        clear();
                        MessageBox.Show("Material record not found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error - " + ex);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = textID.Text;
            if (id == "id")
            {
                MessageBox.Show("ID does not exist!");
            }
            else { 
            DialogResult dr = MessageBox.Show("Are you sure that you want to delete Material record?", "DELETE MATERIAL RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {


                        if (suber_service.deleteMaterial(id) > 0)
                        {
                            AllAdmin();
                            MessageBox.Show("Material record deleted!");
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void DgvMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dgvMaterials.Rows[e.RowIndex];
            //    textID.Text = row.Cells["id"].Value.ToString();
            //    txtMaterial.Text = row.Cells["material"].Value.ToString();
            //    txtDescription.Text = row.Cells["description"].Value.ToString();
            //}
        }
    }
}
