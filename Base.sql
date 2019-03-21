create database E_COMMERCE
use E_COMMERCE
go 

create table users(
	id int primary key identity(1,1),
	nom nvarchar(50),
	prenom nvarchar(50),
	username nvarchar(50),
	pass nvarchar(50)
)
insert into users values('nom1','prenom1','user1','pass')
insert into users values('nom2','prenom2','user2','pass')

create table produit(
	id int primary key identity(1,1),
	nom nvarchar(100),
	imagep nvarchar(max),
	discription nvarchar(max),
	prix int,
	typep nvarchar(50)
)

insert into produit values('Mes Petites Lecons D Informatique','Content/images/livre/img1.png','De la naissance de l informatique à la navigation sur Internet',150,'francais')
insert into produit values('L''Informatique Et Internet Expliques Aux Seniors (Edition 2017)','Content\images\livre\img2.png','Cet ouvrage présente les notions fondamentales de l univers de l informatique et d Internet',250,'francais')
insert into produit values('Architecture Des Machines Et Des Systemes Informatiques (6e Edition)','Content\images\livre\img3.png','Cet ouvrage présente le fonctionnement d un ordinateur au niveau materiel',200,'francais')
insert into produit values('Decouvrir L Informatique Avec Windows 10 Pour Les Nuls (Edition 2017)','Content\images\livre\img4.png','Vous venez de faire l acquisition d un beau PC flambant neuf',300,'francais')
insert into produit values('Les Reseaux','Content/images/livre/mg5.png','Ce livre sur les réseaux informatiques est destiné à toute 
personne ayant une connaissance',250,'francais')

insert into produit values('Je Serai Le Dernier Homme...','Content\images\romans\pic1.png','Un chemin dans la campagne normande, trois heures du matin. Un homme passablement éméché',100,'action')
insert into produit values('Du Passe Faisons Table Rase
Jérôme Bertin','Content\images\romans\pic2.png',' un père de famille sexagénaire, est abattu un soir devant chez lui près de Strasbourg',85,'action')
insert into produit values('La Compagnie','Content\images\romans\pic3.png','Le Grand Roman De La Cia
Dans ce redoutable thriller politique, Robert Littell restitue un demi-siècle de notre histoire.',70,'action')
insert into produit values('Feroce','Content\images\romans\pic4.png','
Une enquête du commissaire Edwige Marion. Un inconnu suit une petite fille.',90,'action')
insert into produit values('Protocoles Fatals
','Content\images\romans\pic5.png','Cannes, 1995. Un tueur à gages s apprête à exécuter un contrat : éliminer une jeune fille.',100,'action')

create table achat(
	id_user int foreign key references users(id) on delete cascade on update cascade,
	id_pro int foreign key references produit(id) on delete cascade on update cascade,
	primary key(id_user,id_pro),
	quantite int
)

insert into achat values(1,1,11)