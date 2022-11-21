using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BL
{
    public class BL_material
    {
        public string id { get; set; }
        public string material { get; set; }
        public string description { get; set; }

        public int material_insert()
        {
            try
            {
                String sql = "insert into material values ('" + material + "','" + description + "')";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int material_update()
        {
            try
            {
                string sql = "update material set material = '" + material + "', description = '" + description + "' where id = '" + id + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findMaterial()
        {
            try
            {
                string sql = "select * from material where id like '%" + id + "%' or material like '%"+ material + "%'";
                DataSet ds = new DB_operation().ExeSelect(sql);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int material_delete()
        {
            try
            {
                string sql = "delete from material where id = '" + id + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findAllMaterial()
        {
            try
            {
                string sql = "select * from material";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
