USE [DBHeads]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Autores_has_libros
(
	autores_id	INTEGER,
	libros_id	INTEGER,
	CONSTRAINT HasAutoreslibros_PK PRIMARY KEY (autores_id,libros_id),
	CONSTRAINT HaslibrosAutores_FK FOREIGN KEY (autores_id)  REFERENCES dbo.Autores(id),
	CONSTRAINT Haslibros_FK FOREIGN KEY (libros_id)  REFERENCES dbo.Libros(id),
	)
	

