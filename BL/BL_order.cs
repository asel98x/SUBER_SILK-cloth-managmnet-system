using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BL
{
    public class BL_order
    {
        public string id { get; set; }
        public string orderId { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public int clientMobile { get; set; }
        public string itemName { get; set; }
        public string itemCategory { get; set; }
        public string itemPrice { get; set; }
        public string itemQuantity { get; set; }
        public string total { get; set; }

        public int order_insert()
        {
            try
            {
                String sql = "insert into client_order ( clientId, clientName,clientAddress,clientMobile,itemName,itemCategory,itemPrice,itemQuantity,total) select clientId, clientName,clientAddress,clientMobile,itemName,itemCategory,itemPrice,itemQuantity,total from cart where clientId = '"+ clientId + "'";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int direct_insert()
        {
            try
            {
                String sql = "insert into client_order values ('" + clientId + "', '" + clientName + "', '" + clientAddress + "', '" + clientMobile + "', '" + itemName + "','" + itemCategory + "','" + itemPrice + "','" + itemQuantity + "','" + total + "')";
                return new DB_operation().exeQuery(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findAllorders()
        {
            try
            {
                string sql = "select * from client_order";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet findClientorders()
        {
            try
            {
                string sql = "select itemName,itemCategory,itemPrice,itemQuantity,total from client_order where clientId ='" + clientId + "'";
                return new DB_operation().ExeSelect(sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
