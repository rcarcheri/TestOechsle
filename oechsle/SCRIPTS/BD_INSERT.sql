SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BD_INSERT]
(
@id INT,
@Nombre VARCHAR(100),
@Apellidos VARCHAR(100),
@Fecha_nac DATE,
@ReturnCode NVARCHAR(20) OUTPUT
)
AS
BEGIN
    SET @ReturnCode = '0';
        BEGIN
            IF EXISTS (SELECT 1 FROM CLIENTES WHERE ID = @id)
                BEGIN
                    SET @ReturnCode = '1'
                    RETURN
                END
            ELSE
                BEGIN
                    INSERT INTO CITAS 
                    VALUES (@id,@Nombre,@nombre,@Apellidos,@Fecha_nac)
                END;    
        END    
    SELECT @ReturnCode as 'Resultado'
END
