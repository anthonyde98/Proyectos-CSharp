create database Prestamos;

use Prestamos;

create table Usuario(
idUsuario INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
nickName VARCHAR(40) NOT NULL,
contrasena VARCHAR(30) NOT NULL,
nivel INTEGER NOT NULL CHECK(nivel IN (1, 2)),
estado BIT NOT NULL
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

INSERT INTO PagoRetrasado SELECT * FROM PagoSiguiente WHERE fechaPagar < (DATEADD(d,DATEDIFF(DD,1,GETDATE()),0));
DELETE FROM PagoSiguiente WHERE fechaPagar < (DATEADD(d,DATEDIFF(DD,1,GETDATE()),0));INSERT INTO usuario (codigo, nickName, contrasena, nivel, estado, imagen) 
SELECT 101, 'anthonyde98', 'andepe99', 1, 1, BulkColumn 
FROM Openrowset( Bulk 'C:\Users\AnthonyPC\Pictures\Mis imagenes\Anthony.jpg', Single_Blob) as UsuarioImagen
Insert into personal (usuario, codigo, nombre, apellido, telefono, cedula, direccion, cargo, estado) values (1, 101, 'Anthony Delanoy', 'Peralta Pérez', '8298195019', '40335941008', 'Calle Desiderio Arias 94-A, Santo Domingo', 'Manejador de Sistemas', 1)

Select * from usuario Where idUsuario = 1;