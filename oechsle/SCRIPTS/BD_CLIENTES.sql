CREATE DataBase BD_CLIENTES
USE BD_CLIENTES
GO

CREATE TABLE CLIENTES
    (ID int PRIMARY KEY NOT NULL,
    Nombre varchar(100) NOT NULL,
    Apellidos varchar(100) NOT NULL,
    Fecha_Nac DATETIME NOT NULL)
GO
