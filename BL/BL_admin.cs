using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;


namespace BL
{
    public class BL_admin
    {
        public string id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string time { get; set; }
        public string date { get; set; }

        public int admin_insert()
        {
            try
            {
                String sql = "insert into admin values ('" + role + "','" + name + "','" + username + "','" + password + "'," +
                    "'" + time + "','" + date + "')";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int admin_update()
        {
            try
            {
                string sql = "update admin set name = '" + name + "', username = '" + username + "'," +
                    "password = '" + password + "' where id = '" + id + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findAdmin()
        {
            try
            {
                string sql = "select * from admin where id like '%" + id + "%' or name like '%"+name+"%'";
                DataSet ds = new DB_operation().ExeSelect(sql);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int admin_delete()
        {
            try
            {
                string sql = "delete from admin where id = '" + id + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findAlladmin()
        {
            try
            {
                string sql = "select * from admin";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet login()
        {
            try
            {
                string sql = "select * from admin where username = '"+username+"' and password = '"+password+"'";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public DataSet getUserDetails()
        {
            try
            {
                string sql = "select id, role, name,username,password from admin where username = '"+ username + "' and password = '"+ password + "'";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
