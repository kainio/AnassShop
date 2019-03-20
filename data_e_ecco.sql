create database E_COMMERCE
use E_COMMERCE
go 
create table admincp(
	id int primary key identity(1,1),
	username nvarchar(50),
	pass nvarchar(50)
)

insert into admincp values('admin','pass')

create table users(
	id int primary key identity(1,1),
	nom nvarchar(50),
	prenom nvarchar(50),
	username nvarchar(50),
	pass nvarchar(50)
)
insert into users values('nom1','prenom1','user1','pass')
insert into users values('nom2','prenom2','user2','pass')
insert into users values('nom3','prenom3','user3','pass')
insert into users values('nom4','prenom4','user4','pass')
insert into users values('nom5','prenom5','user5','pass')
insert into users values('nom6','prenom6','user6','pass')
create table produit(
	id int primary key identity(1,1),
	nom nvarchar(50),
	imagep nvarchar(max),
	discription nvarchar(100),
	prix money,
	typep nvarchar(50)
)
truncate table produit
drop table achat
insert into produit values('produit1','Sources/Images/image1.jpg','description1','51','Femme')
insert into produit values('produit2','Sources/Images/image2.jpg','description2','52','Homme')
insert into produit values('produit3','Sources/Images/image3.jpg','description3','53','Femme')
insert into produit values('produit4','Sources/Images/image4.jpg','description4','54','Homme')
insert into produit values('produit5','Sources/Images/image5.jpg','description5','55','Femme')
create table achat(
	id int primary key identity(1,1),
	id_user int foreign key references users(id) on delete cascade on update cascade,
	id_pro int foreign key references produit(id) on delete cascade on update cascade,
	quantite int,
	adresse nvarchar(max)
)

insert into achat values(1,1,11,'adresse1')