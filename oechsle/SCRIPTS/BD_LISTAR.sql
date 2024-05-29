SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BD_LISTAR]
@id INT,
@operation INT
@ReturnCode NVARCHAR(20) OUTPUT
AS
BEGIN
    IF operation = 0
      BEGIN      
        IF (@id <> 0) 
            BEGIN
                SELECT *, (DATEDIFF(DAY, Fecha_Nac, GETDATE()))/365 as Edad FROM CLIENTES WHERE ID = @id;
            END
        ELSE
            BEGIN
                SELECT *, (DATEDIFF(DAY, Fecha_Nac, GETDATE()))/365 as Edad FROM CLIENTES ORDER BY Nombre, Apellidos ASC;
            END
        END;
      END
    ELSE IF operation = 1
      BEGIN
        SELECT TOP 3 *, (DATEDIFF(DAY, Fecha_Nac, GETDATE()))/365 as Edad FROM CLIENTES ORDER BY Fecha_Nac ASC
      END;
END