using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BL
{
    public class BL_client
    {
        public string id { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int mobile { get; set; }
        public string nic { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string time { get; set; }
        public string date { get; set; }

        public int client_insert()
        {
            try
            {
                String sql = "insert into client values ('" + role + "','" + name + "','" + address + "'," + mobile + ",'" + nic + "','" + birthday + "','" + email + "'," + age + ",'" + username + "','" + password + "','" + time + "','" + date + "')";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int client_update()
        {
            try
            {
                string sql = "update client set name = '" + name + "', address = '" + address + "', mobile = '" + mobile + "'," +
                    " nic = '" + nic + "', birthday = '" + birthday + "', email = '" + email + "', age = '" + age + "', username = '" + username + "'," +
                    " password = '" + password + "' where id = " + id + "";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findClient()
        {
            try
            {
                string sql = "select * from client where id = " + id + " or name like '"+ name + "'";
                DataSet ds = new DB_operation().ExeSelect(sql);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findClient2()
        {
            try
            {
                string sql = "select * from client where id = " + id + "";
                DataSet ds = new DB_operation().ExeSelect(sql);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int client_delete()
        {
            try
            {
                string sql = "delete from client where id = '" + id + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findAllclient()
        {
            try
            {
                string sql = "select * from client";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet client_find_from_table()
        {
            try
            {
                string sql = "select id,role,name,address,mobile,nic,birthday,email,age,username,password,time,date from client where id like '%" + id + "%' or name like '%"+id+"%'";
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
                string sql = "select * from client where username = '" + username + "' and password = '" + password + "'";
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
                string sql = "select id, name, address, mobile, nic, birthday, email, age from client where username = '" + username + "' and password = '" + password + "'";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
