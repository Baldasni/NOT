
USE [aspnet-MDC]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Pratiche_TipologiePratica')
			  AND parent_object_id = OBJECT_ID(N'dbo.Pratiche')
)
    ALTER TABLE [dbo].[Pratiche] DROP CONSTRAINT [FK_Pratiche_TipologiePratica]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Consulenze_TipologiePratica')
			  AND parent_object_id = OBJECT_ID(N'dbo.Consulenze')
)
    ALTER TABLE [dbo].[Consulenze] DROP CONSTRAINT [FK_Consulenze_TipologiePratica]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'TipologiePratica')  
	DROP TABLE [dbo].[TipologiePratica]
GO

CREATE TABLE [dbo].[TipologiePratica]
(
    [IdTipologiaPratica]        INTEGER			  NOT NULL IDENTITY(1,1),
	[Descrizione] 		        NVARCHAR (50)     NOT NULL
    CONSTRAINT [PK_TipologiePratica] PRIMARY KEY CLUSTERED ([IdTipologiaPratica]),

);

-- Reinserimento FK precedentemente cancellata 
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Pratiche')  
	ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_TipologiePratica]
								  FOREIGN KEY ([IdTipologiaPratica]) REFERENCES [dbo].[TipologiePratica] ([IdTipologiaPratica])
								  ON DELETE NO ACTION;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Consulenze')  
	ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_TipologiePratica]
									FOREIGN KEY ([IdTipologiaPratica]) REFERENCES [dbo].[TipologiePratica] ([IdTipologiaPratica])
									ON DELETE NO ACTION;

