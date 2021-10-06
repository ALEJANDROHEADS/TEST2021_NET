USE [DBHeads]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Libros
(
	id				INTEGER,
	titulo			VARCHAR(55),
	sinopsis		VARCHAR(55),
	n_paginas		VARCHAR(5),
	editorial_id	INTEGER,
	CONSTRAINT Libros_PK PRIMARY KEY (id),
	CONSTRAINT libroseditor_FK FOREIGN KEY (editorial_id)  REFERENCES dbo.Editoriales(id)
	)
	
