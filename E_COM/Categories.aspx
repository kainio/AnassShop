<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="E_COM.Categories" %>

<asp:Content runat="server" ID="LivreContent" ContentPlaceHolderID="MainContent">
	<% for (int i=0; i < Produits.Rows.Count; i++){ %>
		<a href='Livres.aspx?id=<%: Produits.Rows[i]["id"]%>' title='voir le livre: <%: Produits.Rows[i]["nom"] %>'>
			<%: Produits.Rows[i]["nom"] %>
			<img width="450" src='<%= Produits.Rows[i]["imagep"] %>' />
        </a>
		<%: Produits.Rows[i]["discription"] %>
		<%: Produits.Rows[i]["prix"] %>
	<%} %>
</asp:Content>