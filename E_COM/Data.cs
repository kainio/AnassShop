using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace E_COM
{
    public class Data
    {
        public static SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-DFV915E\SQLEXPRESS;Initial Catalog=Anass_Shop;Integrated Security=True");
    }
}