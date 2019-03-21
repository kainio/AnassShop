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
    public partial class Panier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["iduser"] == null)
                Response.Redirect("default.aspx");
            else if (!IsPostBack)
            {
                TraitementDataGrid();
            }
        }

        private void TraitementDataGrid()
        {
            try
            {
                if (Data.cn.State == ConnectionState.Closed)
                {
                    Data.cn.Open();
                }
                SqlCommand cmd = new SqlCommand("", Data.cn);
                cmd.CommandText = "select a.id_pro as 'Idprod',p.imagep as 'Photo',p.nom as 'Nomprod',p.prix as 'Prix',a.quantite as 'Quantite', (a.quantite * p.prix)  as 'Sous-total' from achat a inner join produit p on p.id = a.id_pro where id_user =@Iduser";
                cmd.Parameters.AddWithValue("Iduser", this.Page.Session["iduser"].ToString());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    SqlCommand cmdTotal = new SqlCommand("", Data.cn);
                    cmdTotal.CommandText = "Select SUM(a.quantite * p.prix) from achat a inner join produit p on p.id = a.id_pro where id_user =@Iduser";
                    cmdTotal.Parameters.AddWithValue("Iduser", this.Page.Session["iduser"].ToString());
                    Decimal total = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                    (GridView1.FooterRow.FindControl("Lbl_footer_total") as Label).Text = total.ToString();

                }
                else
                {
                    Label Label_error = (Label)this.Master.FindControl("Lbl_error");
                    Label_error.Text = "Votre panier est vide";
                }

            }
            finally
            {
                Data.cn.Close();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            TraitementDataGrid();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            TraitementDataGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (Data.cn.State == ConnectionState.Closed)
                    Data.cn.Open();

                SqlCommand cmd = new SqlCommand("", Data.cn);
                cmd.CommandText = @"update achat set quantite = @quantite where id_user =@iduser and id_pro=@idprod";
                cmd.Parameters.AddWithValue("quantite", (GridView1.Rows[e.RowIndex].FindControl("Txt_EditItem_qte") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("iduser", this.Session["iduser"]);
                cmd.Parameters.AddWithValue("idprod", (GridView1.Rows[e.RowIndex].FindControl("HiddenField_idprod") as HiddenField).Value.Trim());
                cmd.ExecuteNonQuery();
            }
            finally
            {
                GridView1.EditIndex = -1;
                TraitementDataGrid();
                Data.cn.Close();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (Data.cn.State == ConnectionState.Closed)
                    Data.cn.Open();

                SqlCommand cmd = new SqlCommand("", Data.cn);
                cmd.CommandText = "Delete From achat where id_user = @iduser and id_pro = @idprod";
                cmd.Parameters.AddWithValue("iduser", this.Session["iduser"]);
                cmd.Parameters.AddWithValue("idprod", (GridView1.Rows[e.RowIndex].FindControl("HiddenField_idprod") as HiddenField).Value);
                cmd.ExecuteNonQuery();
                this.Session["CartItemsCount"] = Convert.ToInt32(this.Session["CartItemsCount"]) - 1;
            }
            finally
            {
                Data.cn.Close();
                this.Response.Redirect("panier.aspx");
            }
        }
    }
}
