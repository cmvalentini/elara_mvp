
/* ******************
********TABLAS*******
******************* */
CREATE TABLE Usuario(
UsuarioID integer primary key identity,
Usuario varchar(80) not null,
Clave varchar(120) not null,
Nombre varchar(90) not null,
Apellido varchar(90) not null,
DNI integer null,
Email varchar(70) not null,
Habilitado bit not null,
FlagIntentosLogin integer not null,
DVH varchar(32) not null
);

create table medio(
medioid int primary key identity,
medionombre varchar(50) not null,
descripcion varchar(150),
iva decimal(4,2) not null
);


drop table ubicacion;
create table ubicacion(
Ubicacionid integer primary key identity,
Nombreubicacion varchar(30) not null,
Medioid integer not null,
Medidas varchar(50) not null,
Formato varchar(100) null,
Formula varchar(100) not null,
Habilitado bit not null,
precio decimal(10,3) null
FOREIGN KEY (Medioid) REFERENCES medio(Medioid)
);


create table PerfilUsuario(
PerfilUsuarioID integer primary key identity,
NombrePerfil varchar(50) not null,
DescPerfil varchar(50) not null,
DVH integer null default 0

);



create table Bitacora(
BitacoraID integer primary key identity,
NombreOperacion varchar(120) not null,
Descripcion varchar(120) not null,
UsuarioID integer not null,
Criticidad integer not null,
FechayHora datetime not null,
DVH integer
);

create table Idioma(
IdiomaID Int PRIMARY KEY,
Descripcion varchar(8) not null,
Seleccionado Int not null 
)

 
create table OPERACION(
OperacionID integer primary key identity,
Descripcion varchar(50) not null,
PatenteEscencial varchar(2) null
);

create table usuariooperacion(
  UsuarioID INT NOT NULL,
  OperacionID int not null,
  Habilitado varchar(2) not null,
  DVH int null
  FOREIGN KEY (UsuarioID) REFERENCES usuario(usuarioid),
  FOREIGN KEY (OperacionID) REFERENCES operacion(OperacionID)
); 


create table PerfilOperacion(
OperacionID	INTEGER,
PerfilUsuarioID	INTEGER
 FOREIGN KEY (OperacionID) REFERENCES operacion(OperacionID),
 FOREIGN KEY (PerfilUsuarioID) REFERENCES PerfilUsuario(PerfilUsuarioID)
 );


create table cliente(
clienteid int  primary key identity,
razon_social varchar(50) not null unique,
condicion_fiscal varchar(50) not null,
telefono varchar(20) null,
Domicilio varchar(100) not null,
Habilitado bit not null
)

drop table pedido;
create table pedido (
pedidoid integer identity primary key,
medioid integer not null,
ubicacionid integer not null,
clienteid integer not null,
Preciopedido decimal(10,3) not null,
FechainicioPublicacion datetime not null,
FechafinPublicacion datetime not null,
Impresiones integer not null,
Descripcion varchar(300) null,
fechapedido datetime not null,
fechaborrado datetime null
FOREIGN KEY(medioid) REFERENCES medio(medioid),
FOREIGN KEY(ubicacionid) REFERENCES ubicacion(ubicacionid),
FOREIGN KEY(clienteid) REFERENCES cliente(clienteid)
   );

   
  alter table operacion add DVH varchar(100) null;



/* ******************
**ALGUNOS INSERTS**
******************* */

insert into PerfilUsuario values ('Soporte','Hace Soporte',null)

insert into Idioma values(1,'Español',1)
insert into Idioma values(2,'Ingles',0)

insert into OPERACION(Descripcion,patenteescencial) VALUES	('login','S'),
	('menuusuarios','S'),
	('modificarperfilusuario','S'),
	('calculardigitosverificadores','S'),
	('digitosverificadores','S');
insert into operacion values('HacerRestore','S')
 insert into OPERACION values('ConfigurarIdioma','N')
 insert into operacion values('abmusuario','S')
insert into operacion values('ABMFamilias','S')
insert into operacion values ('consultarbitacora','S')
 insert into OPERACION values ('ABMMedios','S')
 
 insert into operacion values ('BloquearDesbloquearOperacionesaUsuario','S')

insert into OPERACION values('DesbloquearOperacionAUsuariocs','S')

  insert into OPERACION values ('ABMClientes','S')
  insert into OPERACION values ('CrearNegocio','N')


   insert into usuariooperacion(UsuarioID,OperacionID,Habilitado) values (1,1018,'S')
   
insert into usuario values ('Test','xSwdFW81PYo=','Test','Test',12345,'Test@test.com.ar',1,0,0)

 insert into usuariooperacion(UsuarioID,OperacionID,Habilitado) values (1,1,'S')
insert into usuariooperacion(UsuarioID,OperacionID,Habilitado) values (1,2,'S')
insert into usuariooperacion(UsuarioID,OperacionID,Habilitado) values (1,3,'S')
insert into usuariooperacion(UsuarioID,OperacionID,Habilitado) values (1,4,'S')
insert into usuariooperacion values(1,5,'S',null)
insert into usuariooperacion values (1,6,'S',null)
 insert into usuariooperacion values (1,7,'S',null)
insert into usuariooperacion(UsuarioID,OperacionID,Habilitado) values (1,8,'S')
 insert into usuariooperacion values (1,9,'S',null)
 
 insert into usuariooperacion values (1,13,'S',null)
 
 
insert into usuariooperacion values (1,14,'S',null)

 insert into dvv values ('PerfilUsuario',null)
insert into dvv values ('PerfilOperacion',null)
insert into dvv values ('Operación',null) 
insert into dvv values ('Bitacora',null)
insert into dvv values ('DVV',NULL)
 insert into dvv values ('usuariooperacion',null)
 
insert into usuariooperacion values (1,11,'S',null)
 insert into usuariooperacion values(1,12,'S',null)

 insert into OPERACION values('ABMUbicacion','N')

 insert into usuariooperacion values (1,1017,'S',null);
 
  insert into dvv values ('bitacora',null);
  
 insert into dvv values ('PerfilUsuario',null);
  insert into dvv values ('Operacion',null);

 insert into perfiloperacion values
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(7,1),
(8,1),
(9,1),
(10,1),
(11,1),
(12,1)

insert into operacion(Descripcion,PatenteEscencial) values ('AltaMedio','S')

insert into usuariooperacion values 
(1,15,'S',null)

insert into operacion(Descripcion,PatenteEscencial) values ('ConsultaOperacion','N')
insert into usuariooperacion values (1,2019,'s',null)

insert into medio(medionombre,descripcion,iva) values 
('Diario Ole','Diario Ole deportivo',10.5)


  insert into ubicacion(Nombreubicacion,Medioid,Medidas,Formato,Formula,Habilitado,precio)
  values ('ROS',1,'4x8','ROS','<!DOCTYPE html><html><head><title>Mi pagina de prueba</title></head> <body></body></html>',
  1,10)
   insert into ubicacion(Nombreubicacion,Medioid,Medidas,Formato,Formula,Habilitado,precio)
  values ('ROS',6,'4x8','ROS','<!DOCTYPE html><html><head><title>Mi pagina de prueba</title></head> <body></body></html>',
  1,10)

    insert into ubicacion(Nombreubicacion,Medioid,Medidas,Formato,Formula,Habilitado,precio)
  values ('LEFT BANNER',1,'2x6','LEFT BANNER','<!DOCTYPE html><html><head><title>Mi pagina de prueba</title></head> <body></body></html>',
  1,15)
     insert into ubicacion(Nombreubicacion,Medioid,Medidas,Formato,Formula,Habilitado,precio)
  values ('RIGHT BANNER',1,'2x6','RIGHT BANNER','<!DOCTYPE html><html><head><title>Mi pagina de prueba</title></head> <body></body></html>',
  1,15)


/* ******************
**STORES PROCEDURES**
******************* */
CREATE PROCEDURE [dbo].[SumarFlagIntentos] 
@usuid int
AS

declare @flag int = 0;
BEGIN

  select @flag = FlagIntentosLogin
   from usuario
   where UsuarioID= @usuid
  select @flag = @flag +1;
   update usuario set FlagIntentosLogin = @flag
   where UsuarioID = @usuid
END;
GO
CREATE PROCEDURE [dbo].[RealizarBackup] 
@PATH1 nchar(400),
@PATH2 nchar(400),
@PATH3 nchar(400)
AS
BEGIN
BACKUP DATABASE ELARA
TO DISK = @PATH1,
DISK = @PATH2,
DISK = @PATH3
END;
GO



 create procedure GrabarPedido
  @preciopedido decimal,
  @impresiones int,
  @fechafinpublicacion datetime,
  @fechainiciopublicacion datetime,
  @descripcion varchar(300),
  @nombreubicacion varchar(100),
  @medionombre varchar(100),
  @nombreAgencia varchar(200)

 as
 declare @medioid int
 declare @ubicacionid int
 declare @clienteid int
  
 select @medioid = u.Medioid,@ubicacionid = u.Ubicacionid from medio m inner join ubicacion u
 on u.Medioid = m.medioid
 where m.medionombre like @medionombre
  and u.Nombreubicacion like  @nombreubicacion
  
  select @clienteid = clienteid from cliente
  where razon_social like @nombreAgencia

  insert into pedido(medioid,ubicacionid,clienteid,Preciopedido,FechainicioPublicacion,FechafinPublicacion,Impresiones,Descripcion,fechapedido)
  (select @medioid,@ubicacionid,@clienteid,@preciopedido,@fechainiciopublicacion,@fechafinpublicacion,@impresiones,@descripcion,GETDATE())
 
   ;
 

 


