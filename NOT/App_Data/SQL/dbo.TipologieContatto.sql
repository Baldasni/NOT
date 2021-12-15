
USE [aspnet-MDC]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Consulenze_TipologieContatto')
			  AND parent_object_id = OBJECT_ID(N'dbo.Consulenze')
)
    ALTER TABLE [dbo].[Consulenze] DROP CONSTRAINT [FK_Consulenze_TipologieContatto]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'TipologieContatto')  
	DROP TABLE [dbo].[TipologieContatto]
GO

CREATE TABLE [dbo].[TipologieContatto]
(
    [IdTipologiaContatto]   INTEGER			  NOT NULL IDENTITY(1,1),
	[Descrizione] 		    NVARCHAR (50)     NOT NULL
    CONSTRAINT [PK_TipologieContatto] PRIMARY KEY CLUSTERED ([IdTipologiaContatto]),

);

-- Reinserimento FK precedentemente cancellata 
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Consulenze')  
	ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_TipologieContatto]
									FOREIGN KEY ([IdTipologiaContatto]) REFERENCES [dbo].[TipologieContatto] ([IdTipologiaContatto])
									ON DELETE NO ACTION;
GO

