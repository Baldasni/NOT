
USE [aspnet-MDC]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Pratiche')  
	DROP TABLE [dbo].[Pratiche];
GO

CREATE TABLE [dbo].[Pratiche]
(
    [IdPratica]            UNIQUEIDENTIFIER NOT NULL,
    [IdSocio]              UNIQUEIDENTIFIER NOT NULL,
    [IdSportello]          INTEGER			NOT NULL,
    [DataPratica]          DATE             NOT NULL,
    [IdTipologiaPratica]   INTEGER			NOT NULL,
    [DescrizionePratica]   NVARCHAR (200)   NOT NULL,
    [IdStatoPratica]       INTEGER			NOT NULL,
	[DescrizioneRiscontro] NVARCHAR (200)       NULL
    CONSTRAINT [PK_Pratiche] PRIMARY KEY CLUSTERED ([IdPratica])
);
GO

CREATE INDEX [IX_Pratiche_IdSocio] ON [dbo].[Pratiche] ([IdSocio]);
GO

ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_Soci]
								  FOREIGN KEY ([IdSocio]) REFERENCES [dbo].[Soci] ([IdSocio])
								  ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_Sportelli]
								  FOREIGN KEY ([IdSportello]) REFERENCES [dbo].[Sportelli] ([IdSportello])
								  ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_TipologiePratica]
								  FOREIGN KEY ([IdTipologiaPratica]) REFERENCES [dbo].[TipologiePratica] ([IdTipologiaPratica])
								  ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Pratiche] ADD CONSTRAINT [FK_Pratiche_StatiPratica]
								  FOREIGN KEY ([IdStatoPratica]) REFERENCES [dbo].[StatiPratica] ([IdStatoPratica])
								  ON DELETE NO ACTION;
GO