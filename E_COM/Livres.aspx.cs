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
    public partial class Livres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    var idprod = this.Request.Params["id"];
                    string[] paramArray = new string[] { idprod.ToString() };
                    if ( idprod != null && Data.IsExists(paramArray, Data.DType.produit))
                    {
                        if (Data.cn.State == ConnectionState.Closed)
                            Data.cn.Open();

                        SqlCommand cmd = new SqlCommand(@"Select * FROM produit where id=" + idprod.ToString(), Data.cn);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if(dr.Read())
                        {
                            Idprod.Value = dr["id"].ToString();
                            Nomprod.Text = dr["nom"].ToString();
                            imageprod.ImageUrl = dr["imagep"].ToString();
                            description.Text = dr["discription"].ToString();
                            prix.Text = dr["prix"].ToString();
                        }


                    }
                }
                finally
                {
                    Data.cn.Close();
                }
            }
        }

        protected void AjouterPanier_Click(object sender, EventArgs e)
        {
            try
            {
                string[] paramArray = new string[] { this.Session["iduser"].ToString(), Idprod.Value.ToString() };
                if (paramArray[0] != "" && paramArray[1] != "" && !Data.IsExists(paramArray, Data.DType.achat))
                {
                    if (Data.cn.State == ConnectionState.Closed)
                        Data.cn.Open();

                    SqlCommand cmd = new SqlCommand(@"Insert INTO achat VALUES(@iduser,@idprod,1)", Data.cn);
                    cmd.Parameters.AddWithValue("iduser", paramArray[0]);
                    cmd.Parameters.AddWithValue("idprod", paramArray[1]);
                    cmd.ExecuteNonQuery();

                    Response.Redirect("panier.aspx");
                }
            }
            finally
            {
                Data.cn.Close();
            }
        }
    }
}