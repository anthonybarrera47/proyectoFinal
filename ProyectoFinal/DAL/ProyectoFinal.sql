------------------DESCRIPCIÓN DEL PROYECTO----------------------------------
/*
Este script de base de datos, se basa en el analisis de un pequeño negocio de compra y ventas de arroz(en cascada) al detalle.
El analisis fue realizado por el Estudiante Anthony Manuel Barrera Hidalgo, estudiante de la carrera de 
Ingenieria de Sistema.
Una breve explicacion de como trabaja el negocio, consiste en la compra de arroz por la unidad de medida KILOS, el cual se dependiendo
de su estado se paga a un determinado precio. Asi mismo este es puede ser llevado a diferentes factorias.
------------------FUNCIONALIDAD----------------
Crear Factorias
Crear Tipo de arroz
Crear Clientes/Productores 
Crear Pesadas
Crear Detalle de las pesadas
Crear Usuarios (Para llevar control de quien atiende).
*/

--|Ejecutar esta parte del script si la base de datos ya existe.  --|
use master														  --|
if exists(select * from sysdatabases where name = 'Agrosoft')	  --|
	DROP DATABASE Agrosoft;										  --|		
--------------------------------------------------------------------|

--Aqui Esta el Script de la base de datos 
create database Agrosoft;
use Agrosoft;

create table Factoria
(
	FactoriaID int identity,
	Nombre varchar(max) not null,
	Direccion Varchar(50) not null,
	Telefono varchar(15) not null,
	FechaRegistro Datetime not null -- La fecha del registro no puede ser nula
	CONSTRAINT PK_Factoria_FactoriaID PRIMARY KEY CLUSTERED(FactoriaID),
	CONSTRAINT CK_Factoria_Telefono CHECK (Telefono like '809%' Or Telefono like '829%' or Telefono like '849%'), --Restrinccion para que los numeros de telefono comiencen de forma correcta
	CONSTRAINT CK_Factoria_FechaRegistro CHECK(FechaRegistro>=getdate()) -- La fecha del registro no puede ser menor a la fecha actual
);
create table Productores
(
	ProductorID int identity,
	Nombre Varchar(50) not null,
	Telefono varchar(15),
	Cedula Varchar(50) not null unique, -- La cedula es un registro unico dentro de la base de datos al igual que las PK 
	FechaNacimiento Date not null,
	FechaRegistro Datetime not null, 
	CONSTRAINT PK_Productores_ProductorID PRIMARY KEY CLUSTERED (ProductorID),--Restriccion de clave primaria 
	CONSTRAINT CK_Productores_Telefono CHECK (Telefono like '809%' Or Telefono like '829%' or Telefono like '849%'),----Restrinccion para que los numeros de telefono comiencen de forma correcta
	CONSTRAINT CK_Productores_FechaRegistro CHECK(FechaRegistro>=getdate()) --La fecha del registro no puede ser menor a la fecha actual
);
create table TipoArroz
(
	TipoArrozID int identity,
	Concepto varchar(50) not null,
	Kilos Decimal,
	FechaRegistro Datetime not null,
	CONSTRAINT PK_TipoArroz_TipoArrozID PRIMARY KEY CLUSTERED (TipoArrozID),
	CONSTRAINT CK_TipoArroz_FechaRegistro CHECK(FechaRegistro>=getdate()) ----La fecha del registro no puede ser menor a la fecha actual
);
create table Usuarios
(
	UsuarioID int identity,
	UserName varchar(30) not null unique, -- El nombre de usuario es unico dentro de la base de datos 
	Nombre varchar(50) not null, -- El nombre del usuario no puede ser nulo
	Password varchar(30) not null,--La contraseña no puede ser nula
	TipoUsuario char(1) not null, --El tipo de usuario no puede estar vacio 
	FechaRegistro datetime not null, -- FEcha del registro no puede ser nula
	CONSTRAINT PK_Usuarios_UsuarioID PRIMARY KEY CLUSTERED (UsuarioID), --Restriccion de la llave primaria 
	CONSTRAINT CK_Usuarios_Password Check(LEN(Password)>=8 and Password!=username and Password!= Nombre), --Restriccion de la contraseña donde la contraseña no puede tener menos de 8 digitos y debe de ser diferente tanto del usuario como del nombre
	CONSTRAINT CK_Usuarios_FechaRegistro CHECK(FechaRegistro>=getdate()),----La fecha del registro no puede ser menor a la fecha actual
	CONSTRAINT CK_Usuarios_TipoUsuario Check(TipoUsuario = 'A' OR TipoUsuario = 'N')--Solo hay dos tipos de usuarios A y N donde A es administrador y N es Normal 
);
create table Pesadas
(
	PesadaID int identity,
	Fanega decimal not null,
	PrecioFanega decimal not null,
	TotalKilogramos decimal not null,
	TotalSacos decimal not null,--
	FechaRegistro Datetime not null,--Fecha del registro no puede ser nula 
	ProductorID int,--Llave foranea
	FactoriaID int not null,--Llave foranea
	UsuarioID int not null , -- Llave foranea
	CONSTRAINT PK_Pesadas_PesadasID Primary key(PesadaID),--Restriccion de la llave Primaria
	CONSTRAINT FK_Pesadas_Productores Foreign key(ProductorID) references Productores(ProductorID) On Delete set null On Update cascade ,--Integridad referencial y restriccion de Llave Foranea, se inserta nulo en dado caso de que el productor sea eliminado y se actualiza en caso de update
	CONSTRAINT FK_Pesadas_Factorias Foreign key(FactoriaID) references Factoria(FactoriaID) On Delete Cascade On Update cascade , --Integridad referencial y restriccion de llave foranea, en caso de se trabaja en cascada
	CONSTRAINT FK_Pesadas_Usuarios Foreign key(UsuarioID) references Usuarios(UsuarioID) On Delete  Cascade On Update cascade,  --Integridad referencial y retriccion de llave Foranea
	CONSTRAINT CK_Pesadas_FechaRegistro Check(FechaRegistro>=GETDATE())--Restriccion para que la fecha del registro sea igual o mayor que la fecha actual
);
create table PesadasDetalle
(
	PesadaDetalleID int identity,
	Kilo decimal not null,
	CantidadSaco decimal not null,
	PesadaID int not null, --Llava Foranea
	TipoArrozID int not null,--Llave Foranea
	CONSTRAINT PK_PesadasDetalle_PesadasDetalleID PRIMARY KEY(PesadaDetalleID),
	CONSTRAINT FK_PesadasDetalle_PesadaID Foreign key(PesadaID) references Pesadas(PesadaID) On Delete Cascade On Update cascade ,--Integridad Referencial y Llave foranea 
	CONSTRAINT FK_PesadasDetalle_TipoArroz Foreign key(TipoarrozID) references TipoArroz(TipoarrozID) On Delete Cascade On Update cascade --Integridad Referencial Y llave forea
);