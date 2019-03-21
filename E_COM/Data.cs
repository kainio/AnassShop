using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace E_COM
{
    public class Data
    {
        public static SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-DFV915E\SQLEXPRESS;Initial Catalog=E_COMMERCE;Integrated Security=True");
        public enum DType { produit, categorie, utilisateur,achat };

        public static bool IsExists(string[] param,DType type)
        {
            try
            {
                if (Data.cn.State == ConnectionState.Closed)
                    Data.cn.Open();

                SqlCommand cmd;
                if (type == DType.categorie)
                {
                    cmd = new SqlCommand(@"Select * FROM produit where typep=@typep", Data.cn);
                    cmd.Parameters.AddWithValue("typep", param[0].ToString());
                }
                else if(type == DType.produit)
                {
                    cmd = new SqlCommand(@"Select * FROM produit where id=@id", Data.cn);
                    cmd.Parameters.AddWithValue("id", Convert.ToInt32(param[0]));
                }
                else if (type == DType.utilisateur)
                {
                    cmd = new SqlCommand(@"Select * FROM users where username = @username and pass =@password", Data.cn);
                    cmd.Parameters.AddWithValue("username", param[0]);
                    cmd.Parameters.AddWithValue("password", param[1]);

                }
                else
                {
                    cmd = new SqlCommand(@"Select * FROM achat where id_pro = @idprod and id_user =@iduser", Data.cn);
                    cmd.Parameters.AddWithValue("idprod", param[0]);
                    cmd.Parameters.AddWithValue("iduser", param[1]);

                }

                var resultat = cmd.ExecuteScalar();

                if (resultat != null)
                    return true;

                return false;

            }
            finally
            {
                Data.cn.Close();
            }
        }
    }
}