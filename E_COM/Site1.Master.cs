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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected bool isAthenticated = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Session["iduser"] != null)
            {
                isAthenticated = true;
                try
                {
                    if (Data.cn.State == ConnectionState.Closed)
                        Data.cn.Open();

                    SqlCommand cmd;
                    cmd = new SqlCommand("select count(*) from achat where id_user= @iduser", Data.cn);
                    cmd.Parameters.AddWithValue("iduser", this.Session["iduser"]);
                    this.Page.Session["CartItemsCount"] = cmd.ExecuteScalar();
                }
                finally
                {
                    Data.cn.Close();
                }
            }
            else
            {
                isAthenticated = false;

            }

        }

        protected void SubmitConnexion_Click(object sender, EventArgs e)
        {
            var username = Username.Text.Trim();
            var password = Password.Text.Trim();
            if (username != "" && password != "")
            {
                try
                {
                    string[] paramArray = new string[] { username, password };

                    if (Data.IsExists(paramArray, Data.DType.utilisateur))
                    {
                        if (Data.cn.State == ConnectionState.Closed)
                            Data.cn.Open();

                        SqlCommand cmd;
                        cmd = new SqlCommand(@"Select * FROM users where username = @username and pass =@password", Data.cn);
                        cmd.Parameters.AddWithValue("username", paramArray[0]);
                        cmd.Parameters.AddWithValue("password", paramArray[1]);


                        SqlDataReader dr = cmd.ExecuteReader();



                        if (dr.Read())
                            this.Session["iduser"] = Convert.ToInt32(dr[0]);

                        dr.Close();


                        this.Response.Redirect("default.aspx");
                    }
                    else
                    {

                    }



                }
                finally
                {
                    Data.cn.Close();
                }

            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.Session.Abandon();

            this.Response.Redirect("default.aspx");
        }
    }
}