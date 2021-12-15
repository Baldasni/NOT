
USE [aspnet-MDC]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Comuni_Province')
			  AND parent_object_id = OBJECT_ID(N'dbo.Comuni')
)
    ALTER TABLE [dbo].[Comuni] DROP CONSTRAINT [FK_Comuni_Province]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Province')  
	DROP TABLE [dbo].[Province]
GO

CREATE TABLE [dbo].[Province]
(
    [IdProvincia]        		INTEGER		  	NOT NULL IDENTITY(1,1),
	[Sigla] 		        	CHAR (02)   	NOT NULL,
	[Descrizione] 		        NVARCHAR (50)   NOT NULL,
	[Regione] 		        	NVARCHAR (50)   NOT NULL
    CONSTRAINT [PK_Province] PRIMARY KEY  CLUSTERED ([IdProvincia])

);

-- Reinserimento FK precedentemente cancellata 
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Comuni')  
	ALTER TABLE [dbo].[Comuni] ADD CONSTRAINT [FK_Comuni_Province]
								FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[Province] ([IdProvincia])
								ON DELETE NO ACTION;
GO
