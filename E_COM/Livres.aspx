<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Livres.aspx.cs" Inherits="E_COM.Livres" %>

<asp:Content runat="server" ID="LivreContent" ContentPlaceHolderID="MainContent">
	<asp:HiddenField ID="Idprod" runat="server" />
	<asp:Label ID="Nomprod" runat="server"></asp:Label>
	<asp:Image ID="imageprod" Width="450px" runat="server" />
	<asp:Label ID="description" runat="server"></asp:Label>
	<asp:Label ID="prix" runat="server" Text="Label"></asp:Label>
	<asp:Button ID="AjouterPanier" OnClick="AjouterPanier_Click" Text="Ajouter au panier" ToolTip="Ajouter au panier" runat="server" />
</asp:Content>
