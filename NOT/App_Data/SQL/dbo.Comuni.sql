USE [aspnet-MDC]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Consulenze_Comuni')
			  AND parent_object_id = OBJECT_ID(N'dbo.Consulenze')
)
    ALTER TABLE [dbo].[Consulenze] DROP CONSTRAINT [FK_Consulenze_Comuni]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Soci_Comuni_N')
			  AND parent_object_id = OBJECT_ID(N'dbo.Soci')
)
    ALTER TABLE [dbo].[Soci] DROP CONSTRAINT [FK_Soci_Comuni_N]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Soci_Comuni_R')
			  AND parent_object_id = OBJECT_ID(N'dbo.Soci')
)
    ALTER TABLE [dbo].[Soci] DROP CONSTRAINT [FK_Soci_Comuni_R]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Comuni')  
	DROP TABLE [dbo].[Comuni]
GO

CREATE TABLE [dbo].[Comuni]
(
    [IdComune]        			INTEGER  NOT NULL IDENTITY(1,1),
    [IdProvincia]     			INTEGER  NOT NULL DEFAULT 0,
	[Descrizione] 		        NVARCHAR (50)     NOT NULL
    CONSTRAINT [PK_Comuni] PRIMARY KEY CLUSTERED ([IdComune])

);

ALTER TABLE [dbo].[Comuni] ADD CONSTRAINT [FK_Comuni_Province]
								FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[Province] ([IdProvincia])
								ON DELETE NO ACTION;
GO

-- Reinserimento FK precedentemente cancellata 
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Consulenze')  
	ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_Comuni]
									FOREIGN KEY ([IdComune]) REFERENCES [dbo].[Comuni] ([IdComune])
									ON DELETE NO ACTION;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Soci')  
	ALTER TABLE [dbo].[Soci] ADD CONSTRAINT [FK_Soci_Comuni_N]
							  FOREIGN KEY ([IdComuneNascita]) REFERENCES [dbo].[Comuni] ([IdComune])
							  ON DELETE NO ACTION;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Soci')  
	ALTER TABLE [dbo].[Soci] ADD CONSTRAINT [FK_Soci_Comuni_R]
							  FOREIGN KEY ([IdComuneResidenza]) REFERENCES [dbo].[Comuni] ([IdComune])
							  ON DELETE NO ACTION;
GO