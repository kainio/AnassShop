using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace E_COM
{
    public partial class Categories : System.Web.UI.Page
    {
        protected DataTable Produits = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    var nomCat = this.Request.Params["nomCat"];
                    string[] paramArray = new string[] { nomCat.ToString() };
                    if (nomCat != null && Data.IsExists(paramArray, Data.DType.categorie))
                    {
                        if (Data.cn.State == ConnectionState.Closed)
                            Data.cn.Open();

                        SqlCommand cmd;
                        cmd = new SqlCommand(@"Select * FROM produit where typep=@typep", Data.cn);
                        cmd.Parameters.AddWithValue("typep", nomCat.ToString());

                        SqlDataReader dr = cmd.ExecuteReader();

                        this.Produits.Load(dr);

                    }



                }
                finally
                {
                    Data.cn.Close();
                }
            }
        }
    }
}