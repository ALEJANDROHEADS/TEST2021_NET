USE [DBHeads]
GO

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID ('sp_listar_biblioteca') AND type = 'P' )
BEGIN
    DROP PROCEDURE sp_listar_biblioteca
    IF OBJECT_ID('sp_listar_biblioteca') IS NOT NULL
    	PRINT '<<< ERROR AL ELIMINAR sp_listar_biblioteca >>>'
    ELSE
        PRINT '<<< sp_listar_biblioteca ELIMINADO >>>'
    END
GO

CREATE PROC dbo.sp_listar_biblioteca

AS
	BEGIN
	    SET NOCOUNT ON
	    SET DATEFORMAT DMY
		-->>>_____________________________________________________________________________________
	    -->>>¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	    -- AUTOR    : (CAMOLANO Heads) César Alejandro Cabezas Molano 
	    -- FECHA    : 05/octubre/2021
	    -->>>_____________________________________________________________________________________
	    -->>>¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯

		SELECT 
			AU.apellidos + ' '+ AU.nombre AS 'Autor',	
			ED.nombre as 'Editorial',
			LB.titulo as 'Titulo',
			LB.n_paginas as 'Num Paginas',
			LB.sinopsis as 'Sinopsis'
			FROM  dbo.Libros			LB  With(NoLock) 
			INNER JOIN dbo.Editoriales	ED  With(NoLock) ON ED.id = LB.editorial_id  
			INNER JOIN DBO.Autores_has_libros HAS With(NoLock) ON HAS.libros_id = LB.id 
			INNER JOIN DBO.Autores AU With(NoLock) ON AU.id = HAS.autores_id


RETURN 0

    END
GO 				
IF OBJECT_ID('sp_listar_biblioteca') IS NOT NULL
    PRINT '<<< sp_listar_biblioteca CREADO >>>'
ELSE
    PRINT '<<< ERROR AL CREAR sp_listar_biblioteca >>>'
GO		