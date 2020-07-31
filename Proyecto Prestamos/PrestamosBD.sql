create database Prestamos;

use Prestamos;

create table Usuario(
idUsuario INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
nickName VARCHAR(40) NOT NULL,
contrasena VARCHAR(30) NOT NULL,
nivel INTEGER NOT NULL CHECK(nivel IN (1, 2)),
estado BIT NOT NULL
)

create table Cambio(
idCambio INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
usuario INTEGER NOT NULL,
fecha DATETIME NOT NULL CONSTRAINT fechaCambio DEFAULT (GETDATE()),
evento VARCHAR(10) NOT NULL,
tabla VARCHAR(30) NOT NULL,
descripcion VARCHAR(MAX) NOT NULL,

CONSTRAINT FK_USUARIO3 FOREIGN KEY (usuario) REFERENCES Usuario(idUsuario)
)

create table Personal(
idPersonal INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY, 
usuario INTEGER NOT NULL,
nombre VARCHAR(50) NOT NULL,
apellido VARCHAR(60) NOT NULL,
telefono VARCHAR(10) NOT NULL,
cedula VARCHAR(11) NOT NULL,
direccion VARCHAR(100) NOT NULL,
cargo VARCHAR(50) NOT NULL,
estado BIT NOT NULL

CONSTRAINT FK_USUARIO FOREIGN KEY (usuario) REFERENCES Usuario(idUsuario)
)

create table Cliente(
idCliente INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY, 
nombre VARCHAR(50) NOT NULL,
apellido VARCHAR(60) NOT NULL,
telefono VARCHAR(10) NOT NULL,
cedula VARCHAR(11) NOT NULL,
direccion VARCHAR(100) NOT NULL,
dataCredito VARCHAR(70) NOT NULL,
estado BIT NOT NULL
)

ALTER TABLE prestamo
ALTER COLUMN cantidadPrestada double

create table Prestamo(
idPrestamo INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY, 
usuario INTEGER NOT NULL,
cliente INTEGER NOT NULL,
cantidadPrestada FLOAT NOT NULL,
cantidadPagar FLOAT NOT NULL,
cantidadDebe FLOAT NOT NULL,
tasaInteres FLOAT NOT NULL,
tiempoMeses INTEGER NOT NULL,
interes FLOAT NOT NULL,
fechaPrestamo DATETIME NOT NULL,
fechaFinal DATETIME NOT NULL,
estado BIT NOT NULL

CONSTRAINT FK_USUARIO1 FOREIGN KEY (usuario) REFERENCES Usuario(idUsuario),
CONSTRAINT FK_CLIENTE FOREIGN KEY (cliente) REFERENCES Cliente(idCliente)
)

create table Pago(
idPago INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
prestamo INTEGER NOT NULL,
cantidad FLOAT NOT NULL,
fecha DATETIME NOT NULL,
usuario INTEGER NOT NULL

CONSTRAINT FK_USUARIO2 FOREIGN KEY (usuario) REFERENCES Usuario(idUsuario),
CONSTRAINT FK_PRESTAMO FOREIGN KEY (prestamo) REFERENCES Prestamo(idPrestamo)
)

create table PagoSiguiente(
idPagoSiguiente INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
prestamo INTEGER NOT NULL,
cantidad FLOAT NOT NULL,
fechaPagar DATETIME NOT NULL

CONSTRAINT FK_PRESTAMO1 FOREIGN KEY (prestamo) REFERENCES Prestamo(idPrestamo)
)

create table PagoRetrasado(
idPagoRetrasado INTEGER NOT NULL PRIMARY KEY,
prestamo INTEGER NOT NULL,
cantidad FLOAT NOT NULL,
fechaSupuestaPagar DATETIME NOT NULL,
codigo INTEGER NOT NULL

CONSTRAINT FK_PRESTAMO2 FOREIGN KEY (prestamo) REFERENCES Prestamo(idPrestamo)
)

INSERT INTO PagoRetrasado SELECT * FROM PagoSiguiente WHERE fechaPagar < (DATEADD(d,DATEDIFF(DD,0,GETDATE()),0));
select (DATEADD(d,DATEDIFF(DD,-31,GETDATE()),0));

 

SELECT ROW_NUMBER() OVER(ORDER BY idUsuario DESC) AS Row from Usuario where idUsuario = 1

select * from PagoSiguiente

select PagoRetrasado.idPagoRetrasado, cliente.nombre, cliente.apellido, PagoRetrasado.prestamo, PagoRetrasado.cantidad, PagoRetrasado.fechaSupuestaPagar, PagoRetrasado.codigo from PagoRetrasado join Prestamo on PagoRetrasado.prestamo = Prestamo.idPrestamo join cliente on Prestamo.cliente = cliente.idCliente where PagoRetrasado.prestamo = 1;

select * from cliente;


update prestamo set cantidadDebe = (select cantidadDebe from prestamo) - 10 WHERE idPrestamo = 1;
INSERT INTO PagoRetrasado SELECT idPagoSiguiente, prestamo, (cantidad * 0.05) + cantidad as cantidad, fechaPagar, codigo FROM PagoSiguiente WHERE fechaPagar < (DATEADD(d,DATEDIFF(DD,0,GETDATE()),0));
SELECT idPagoSiguiente, prestamo, (cantidad * 0.05) + cantidad , fechaPagar, codigo FROM PagoSiguiente
select * from usuario