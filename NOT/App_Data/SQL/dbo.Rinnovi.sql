
USE [aspnet-MDC]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Rinnovi')  
	DROP TABLE [dbo].[Rinnovi];
GO

CREATE TABLE [dbo].[Rinnovi]
(
    [IdRinnovo]          UNIQUEIDENTIFIER NOT NULL,
    [IdSocio]            UNIQUEIDENTIFIER NOT NULL,
    [Data]               DATE             NOT NULL,
    [Anno 1]             CHAR(4)              NULL,
    [Anno 2]             CHAR(4)              NULL,
    [Quota iscrizione]   REAL			  NOT NULL
    CONSTRAINT [PK_Rinnovi] PRIMARY KEY CLUSTERED ([IdRinnovo]),
);
GO

CREATE INDEX [IX_Rinnovi_IdSocio] ON [dbo].[Rinnovi] ([IdSocio]);
GO

ALTER TABLE [dbo].[Rinnovi] ADD CONSTRAINT [FK_Rinnovi_Soci]
								 FOREIGN KEY ([IdSocio]) REFERENCES [dbo].[Soci] ([IdSocio])
								 ON DELETE NO ACTION;
GO
