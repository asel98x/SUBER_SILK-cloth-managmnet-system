using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Connection
    {
        public SqlConnection connect = new SqlConnection("Server=DESKTOP-104HPCC\\SQLEXPRESS;Database=saber_silk;Integrated Security=true");

    }
}
