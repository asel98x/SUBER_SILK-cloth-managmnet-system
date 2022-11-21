using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL_client
{
    public class bl_client
    {
        
        public string id { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
        public string nic { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string age { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string time { get; set; }
        public string date { get; set; }

        public int admin_insert()
        {
            try
            {
                String sql = "insert into client values ('" + name + "','" + address + "','" + mobile + "','" + nic + "','" + birthday + "','" + email + "','" + age + "','" + username + "','" + password + "','" + time + "','" + date + "')";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
