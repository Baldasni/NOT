
USE [aspnet-MDC]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Pratiche_Sportelli')
			  AND parent_object_id = OBJECT_ID(N'dbo.Pratiche')
)
    ALTER TABLE [dbo].[Pratiche] DROP CONSTRAINT [FK_Pratiche_Sportelli]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Sportelli')  
	DROP TABLE [dbo].[Sportelli]
GO

CREATE TABLE [dbo].[Sportelli]
(
    [IdSportello]        		INTEGER			  NOT NULL IDENTITY(1,1),
	[Descrizione] 		        NVARCHAR (50)     NOT NULL
    CONSTRAINT [PK_Sportelli] PRIMARY KEY CLUSTERED ([IdSportello]),

);

-- Reinserimento FK precedentemente cancellata 
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Pratiche')  
	ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_Sportelli]
								  FOREIGN KEY ([IdSportello]) REFERENCES [dbo].[Sportelli] ([IdSportello])
								  ON DELETE NO ACTION;
GO

