<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_COM.Default" %>


<asp:Content ID="default" runat="server" ContentPlaceHolderID="MainContent">

	<main role="main" class="cover">
		<img src="Content/images/librairie.jpg" style="margin-right: 60px" max-width="250px" height="250px" alt="image bienvenue">
		<div>
			<h1 class="cover-heading">Bienvenue dans votre librairie.</h1>
			<p class="lead">
				Notre librairie est spécialisée dans la vente de livres régionaux 
				En outre, nous vous proposons toute l'année
				<ul>
					<li>un grand choix de bandes dessinées</li>
					<li>un grand choix de livres de poches</li>
					<li>un grand choix de livres sur le bien être</li>
				</ul>

				Nous favorisons un lien particulier entre auteurs et lecteurs en proposant régulièrement des signatures et des conférences publiques.
				De plus, si vous recherchez un ouvrage particulier, nous pouvons le commander.
			    </p>
			</p>
		</div>
    </main>
</asp:Content>