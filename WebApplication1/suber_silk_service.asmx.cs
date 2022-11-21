using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Web.Services;
using BL;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for suber_silk_service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class suber_silk_service : System.Web.Services.WebService
    {
        BL_admin admin = new BL_admin();
        BL_client client = new BL_client();
        BL_material matril = new BL_material();
        BL_stock stock = new BL_stock();
        BL_stockList Slist = new BL_stockList();
        BL_cart cart = new BL_cart();
        BL_order order = new BL_order();

        [WebMethod]
        public int insertAdmin(string role, string name, string username, string password, string time, string date)
        {
            int numRow = 0;
            try
            {
                //admin.id = id;
                admin.role = role;
                admin.name = name;
                admin.username = username;
                admin.password = password;
                admin.time = time;
                admin.date = date;

                numRow = admin.admin_insert();
            }
            catch (Exception ex)
            {
                throw;
            }
            return numRow;
        }

        [WebMethod]
        public DataSet selectAdmin(string id, string name)
        {
            try
            {
                admin.id = id;
                admin.name = name;
                return admin.findAdmin();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [WebMethod]
        public int updateAdmin(string name, string username, string password)
        {
            try
            {
                
                admin.name = name;
                admin.username = username;
                admin.password = password;

                return admin.admin_update();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public int deleteAdmin(string id)
        {
            try
            {
                admin.id = id;
                return admin.admin_delete();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet sellectAllAdmin()
        {
            try
            {
                return admin.findAlladmin();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet admin_login(string username, string password)
        {
            try
            {
                admin.username = username;
                admin.password = password;
                return admin.login();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet get_admin_details(string username, string password)
        {
            try
            {
                admin.username = username;
                admin.password = password;
                return admin.getUserDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public int insertClient(string role, string name, string address, int mobile, string nic, string birthday, string email, int age, string username, string password, string time, string date)
        {
            int numRow = 0;
            try
            {
                client.role = role;
                client.name = name;
                client.address = address;
                client.mobile = mobile;
                client.nic = nic;
                client.birthday = birthday;
                client.email = email;
                client.age = age;
                client.username = username;
                client.password = password;
                client.time = time;
                client.date = date;

                numRow = client.client_insert();
            }
            catch (Exception ex)
            {
                throw;
            }
            return numRow;
        }

        [WebMethod]
        public DataSet selectClient(string id)
        {
            try
            {
                client.id = id;
                return client.findClient();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [WebMethod]
        public DataSet selectClient2(string id)
        {
            try
            {
                client.id = id;
                return client.findClient2();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [WebMethod]
        public int updateClient(string id, string name,string address,int mobile,string nic,string birthday,string email, int age, string username, string password)
        {
            try
            {

                client.id = id;
                client.name = name;
                client.address = address;
                client.mobile = mobile;
                client.nic = nic;
                client.birthday = birthday;
                client.email = email;
                client.age = age;
                client.username = username;
                client.password = password;

                return client.client_update();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public int deleteClient(string id)
        {
            try
            {
                client.id = id;
                return client.client_delete();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet sellectAllClient()
        {
            try
            {
                return client.findAllclient();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet client_login(string username, string password)
        {
            try
            {
                client.username = username;
                client.password = password;
                
                return client.login();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //[WebMethod]
        //public DataSet get_client_details(string id, string name, string address, int mobile, string nic, string birthday, string email, int age)
        //{
        //    try
        //    {
        //        client.id = id;
        //        client.name = name;
        //        client.address = address;
        //        client.mobile = mobile;
        //        client.nic = nic;
        //        client.birthday = birthday;
        //        client.email = email;
        //        client.age = age;
        //        return client.getUserDetails();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        [WebMethod]
        public DataSet get_client_details(string id)
        {
            try
            {
                client.id = id;
                return client.client_find_from_table();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public int insertMaterial(string material, string description)
        {
            int numRow = 0;
            try
            {
                matril.material = material;
                matril.description = description;

                numRow = matril.material_insert();
            }
            catch (Exception ex)
            {
                throw;
            }
            return numRow;
        }

        [WebMethod]
        public DataSet selectMaterial(string id, string material)
        {
            try
            {
                matril.id = id;
                matril.material = material;
                return matril.findMaterial();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [WebMethod]
        public int updateMaterial(string material, string description)
        {
            try
            {

                matril.material = material;
                matril.description = description;

                return matril.material_update();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public int deleteMaterial(string id)
        {
            try
            {
                matril.id = id;
                return matril.material_delete();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet sellectAllMaterial()
        {
            try
            {
                return matril.findAllMaterial();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet get_all_materials()
        {
            try
            {
                return stock.get_material();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public int insertStock(string category, string name,byte[] image, string description, string availability, double price)
        {
            int numRow = 0;
            try
            {
                stock.category = category;
                stock.name = name;
                stock.image = image;
                stock.description = description;
                stock.availability = availability;
                stock.price = price;

                numRow = stock.stock_insert();
            }
            catch (Exception ex)
            {
                throw;
            }
            return numRow;
        }

        [WebMethod]
        public DataSet selectStock(string id, string name)
        {
            try
            {
                stock.id = id;
                stock.name = name;
                return stock.findStock();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [WebMethod]
        public int updateStock(string category, string name, byte[] image, string description, string availability, double price)
        {
            try
            {

                stock.category = category;
                stock.name = name;
                stock.image = image;
                stock.description = description;
                stock.availability = availability;
                stock.price = price;

                return stock.stock_update();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public int deleteStock(string id)
        {
            try
            {
                stock.id = id;
                return stock.stock_delete();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet sellectAllStock()
        {
            try
            {
                return stock.findAllStocks();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetItems()
        {
            try
            {

                return Slist.ReadItemsTable();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [WebMethod]
        public DataTable GetItem(string name)
        {
            try
            {
                Slist.name = name;
                return Slist.FindStock();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [WebMethod]
        public int insertToCart(string clientId, string clientName, string clientAddress, int clientMobile, string itemName, string itemCategory, string itemPrice, string itemQuantity, string total)
        {
            int numRow = 0;
            try
            {
                cart.clientId = clientId;
                cart.clientName = clientName;
                cart.clientAddress = clientAddress;
                cart.clientMobile = clientMobile;
                cart.itemName = itemName;
                cart.itemCategory = itemCategory;
                cart.itemPrice = itemPrice;
                cart.itemQuantity = itemQuantity;
                cart.total = total;

                numRow = cart.cart_insert();
            }
            catch (Exception ex)
            {
                throw;
            }
            return numRow;
        }

        [WebMethod]
        public DataSet view_client_cart(string clientId)
        {
            try
            {
                cart.clientId = clientId;
                return cart.findClientCart();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [WebMethod]
        public int deletecart(string clientId)
        {
            try
            {
                cart.clientId = clientId;
                return cart.cart_delete();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet view_client_cart_total(string clientId)
        {
            try
            {
                cart.clientId = clientId;
                return cart.totalsum();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [WebMethod]
        public int insertToOrder(string clientId)
        {
            int numRow = 0;
            try
            {
                order.clientId = clientId;
                numRow = order.order_insert();

            }
            catch (Exception ex)
            {
                throw;
            }
            return numRow;
        }

        [WebMethod]
        public int insertDirectToOrder(string clientId, string clientName, string clientAddress, int clientMobile, string itemName, string itemCategory, string itemPrice, string itemQuantity, string total)
        {
            int numRow = 0;
            try
            {
                order.clientId = clientId;
                order.clientName = clientName;
                order.clientAddress = clientAddress;
                order.clientMobile = clientMobile;
                order.itemName = itemName;
                order.itemCategory = itemCategory;
                order.itemPrice = itemPrice;
                order.itemQuantity = itemQuantity;
                order.total = total;

                numRow = order.direct_insert();
            }
            catch (Exception ex)
            {
                throw;
            }
            return numRow;
        }

        [WebMethod]
        public DataSet sellectAllOrders()
        {
            try
            {
                return order.findAllorders();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet view_client_order(string clientId)
        {
            try
            {
                order.clientId = clientId;
                return order.findClientorders();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}


