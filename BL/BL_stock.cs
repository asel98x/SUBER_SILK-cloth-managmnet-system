using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using System.IO;
using System.Drawing;

namespace BL
{
    public class BL_stock
    {
        public string id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public byte[] image { get; set; }
        public string description { get; set; }
        public string availability { get; set; }
        public double price { get; set; }

        public DataSet get_material()
        {
            try
            {
                string sql = "select material from material ";
                DataSet ds = new DB_operation().ExeSelect(sql);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int stock_insert()
        {
            try
            {
                String sql = "insert into stock values ('" + category + "','" + name + "',CAST('{"+image.ToString()+"}' AS VARBINARY(MAX)),'" + description + "','" + availability + "','" + price + "')";
                return new DB_operation().exeQuery(sql); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findStock()
        {
            try
            {
                string sql = "select * from stock where id like '%" + id + "%' or name like '"+name+"'";
                DataSet ds = new DB_operation().ExeSelect(sql);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        public int stock_update()
        {
            try
            {
                string sql = "update stock set category = '" + category + "', name = '" + name + "', image = '" + image + "',, description = '" + description + "', quantity = '" + availability + "', price = '" + price + "' where id = '" + id + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int stock_delete()
        {
            try
            {
                string sql = "delete from stock where id = '" + id + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findAllStocks()
        {
            try
            {
                string sql = "select * from stock";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
