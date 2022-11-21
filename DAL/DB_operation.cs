using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DB_operation
    {
        private SqlConnection con = new SqlConnection("Server=DESKTOP-104HPCC\\SQLEXPRESS;Database=saber_silk;Integrated Security=true");

        public int exeQuery(string sql)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                return com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet ExeSelect(string sql)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
