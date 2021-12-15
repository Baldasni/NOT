
USE [aspnet-MDC]
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Rinnovi_Soci')
			  AND parent_object_id = OBJECT_ID(N'dbo.Rinnovi')
)
    ALTER TABLE [dbo].[Rinnovi] DROP CONSTRAINT [FK_Rinnovi_Soci];
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Pratiche_Soci')
			  AND parent_object_id = OBJECT_ID(N'dbo.Pratiche')
)
    ALTER TABLE [dbo].[Pratiche] DROP CONSTRAINT [FK_Pratiche_Soci];
GO

IF EXISTS (SELECT * 
		 	 FROM sys.foreign_keys 
		    WHERE object_id = OBJECT_ID(N'dbo.FK_Consulenze_Soci')
			  AND parent_object_id = OBJECT_ID(N'dbo.Consulenze')
)
    ALTER TABLE [dbo].[Consulenze] DROP CONSTRAINT [FK_Consulenze_Soci];
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Soci')  
	DROP TABLE [dbo].[Soci];
GO

CREATE TABLE [dbo].[Soci] (
    [IdSocio]            UNIQUEIDENTIFIER NOT NULL,
    [CodifeFiscale]      NCHAR (16)       NULL,
    [Nome]               NVARCHAR (50)    NOT NULL,
    [Cognome]            NVARCHAR (50)    NULL,
    [DataNascita]        DATE             NULL,
    [IdComuneNascita]    INTEGER          NULL,
    [Sesso]              NCHAR (1)        NULL,
    [DataIscrizione]     DATE             NOT NULL,
    [Email]              NVARCHAR (50)    NULL,
    [Telefono1]          NVARCHAR (50)    NULL,
    [Telefono2]          NVARCHAR (50)    NULL,
    [IndirizzoResidenza] NVARCHAR (50)    NULL,
    [IdComuneResidenza]  INTEGER		  NULL,
    [Cap]                NCHAR (5)        NULL
    CONSTRAINT [PK_Socio] PRIMARY KEY CLUSTERED ([IdSocio] ASC)
);
GO

CREATE NONCLUSTERED INDEX [IX_Soci_Email]
    ON [dbo].[Soci]([Email] ASC);
GO

ALTER TABLE [dbo].[Soci] ADD CONSTRAINT [FK_Soci_Comuni_N]
							  FOREIGN KEY ([IdComuneNascita]) REFERENCES [dbo].[Comuni] ([IdComune])
							  ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Soci] ADD CONSTRAINT [FK_Soci_Comuni_R]
							  FOREIGN KEY ([IdComuneResidenza]) REFERENCES [dbo].[Comuni] ([IdComune])
							  ON DELETE NO ACTION;
GO

-- Reinserimento FK precedentemente cancellata 
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Rinnovi')  
	ALTER TABLE [dbo].[Rinnovi] ADD CONSTRAINT [FK_Rinnovi_Soci]
								 FOREIGN KEY ([IdSocio]) REFERENCES [dbo].[Soci] ([IdSocio])
								 ON DELETE NO ACTION;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Pratiche')  
	ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_Soci]
								  FOREIGN KEY ([IdSocio]) REFERENCES [dbo].[Soci] ([IdSocio])
								  ON DELETE NO ACTION;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Consulenze')  
	ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_Soci]
								    FOREIGN KEY ([IdSocio]) REFERENCES [dbo].[Soci] ([IdSocio])
								    ON DELETE NO ACTION;
GO
