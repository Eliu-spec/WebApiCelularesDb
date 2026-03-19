--Eliminando base de datos si existe
USE master
GO
DROP DATABASE IF EXISTS DbCelulares
GO

--Creacion de Base de Datos
CREATE DATABASE DbCelulares
GO 

--Indicar que base de datos vamos a utilizar
USE DbCelulares
GO

--CREAR TABLA PARA ADMINISTRAR CATEGORIAS
CREATE TABLE Categorias (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Marca VARCHAR(250) NOT NULL,
)
GO

--Crear tabla para administrar los celulares
CREATE TABLE Celulares(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Marca VARCHAR(500) NOT NULL,
	Modelo VARCHAR(500) NOT NULL,
	Descripcion VARCHAR(500) NOT NULL,
	CategoriaId INT NOT NULL,

	FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
)
GO



--AGREGANDO CATEGORIAS
INSERT INTO Categorias (Marca)
VALUES
	('Gama Alta'),
	('Gama Media'),
	('Gama Baja')

SELECT * FROM Categorias


--AGREGANDO CELULARES
INSERT INTO Celulares
(
	Marca,
	Modelo,
	Descripcion,
	CategoriaId
)
VALUES
('Samsung', 'Galaxy S22 Ultra', 'Alta gama del 2022', 1),
('Apple','Iphone 17 Pro Max','Lo mas top de Apple', 1),
('Apple','Iphone 17 Pro','Lo mas top de Apple', 1),
('Samsung', 'Galaxy Z Fold', 'Alta gama del 2022', 1),
('Xiaomi', 'Redmi Note 10 Pro', 'Calidad Precio', 2),
('Samsung', 'Galaxy A15', 'Gama accesible de Samsung', 3)
GO


SELECT * FROM Celulares

--ELIMINANDO TABLA POR SI EXISTE:
--DROP TABLE IF EXISTS Celulares
--GO
--FILTRO POR ID
SELECT * FROM Celulares
WHERE Id = 2

--FILTRO WHERE
SELECT * FROM Celulares
WHERE Marca = 'Samsung'

--FILTRO PRO LIKE
SELECT * FROM Celulares
WHERE Descripcion LIKE 'Lo mas top de Apple'

--obtener una cantidad especifica de registro
SELECT TOP 2 * FROM Celulares


--UPDATES
UPDATE Celulares
	SET
		Marca = 'Samsung'
WHERE Id = 3

SELECT * FROM Celulares WHERE Id = 4

