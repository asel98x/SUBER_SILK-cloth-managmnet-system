using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BL
{
    public class BL_cart
    {
        public string id { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public int clientMobile { get; set; }
        public string itemName { get; set; }
        public string itemCategory { get; set; }
        public string itemPrice { get; set; }
        public string itemQuantity { get; set; }
        public string total { get; set; }
        public string time { get; set; }
        public string date { get; set; }

        public int cart_insert()
        {
            try
            {
                String sql = "insert into cart values ('"+ clientId + "', '" + clientName + "', '" + clientAddress + "', '" + clientMobile + "', '" + itemName + "','" + itemCategory + "','" + itemPrice + "','" + itemQuantity + "','" + total + "')";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findClientCart()
        {
            try
            {
                string sql = "select itemName,itemCategory,itemPrice,itemQuantity,total from cart where clientId ='" + clientId + "'";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int cart_delete()
        {
            try
            {
                string sql = "delete from cart where clientId = '" + clientId + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet totalsum()
        {
            try
            {
                string sql = "select sum (total) from cart where clientId ='" + clientId + "'";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
