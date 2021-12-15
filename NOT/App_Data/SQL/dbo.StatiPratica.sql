USE [aspnet-MDC]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Pratiche_StatiPratica')
			  AND parent_object_id = OBJECT_ID(N'dbo.Pratiche')
)
    ALTER TABLE [dbo].[Pratiche] DROP CONSTRAINT [FK_Pratiche_StatiPratica]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'StatiPratica')  
	DROP TABLE [dbo].[StatiPratica]
GO

CREATE TABLE [dbo].[StatiPratica]
(
    [IdStatoPratica]        	INTEGER			  NOT NULL IDENTITY(1,1),
	[Descrizione] 		        NVARCHAR (50)     NOT NULL
    CONSTRAINT [PK_StatiPratica] PRIMARY KEY CLUSTERED ([IdStatoPratica])

);

-- Reinserimento FK precedentemente cancellata 
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Pratiche')  
	ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_StatiPratica]
								  FOREIGN KEY ([IdStatoPratica]) REFERENCES [dbo].[StatiPratica] ([IdStatoPratica])
								  ON DELETE NO ACTION;
GO

