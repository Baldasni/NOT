
USE [aspnet-MDC]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Consulenze')  
	DROP TABLE [dbo].[Consulenze];
GO

CREATE TABLE [dbo].[Consulenze]
(
    [IdConsulenza]          UNIQUEIDENTIFIER  NOT NULL,
    [IdSocio]               UNIQUEIDENTIFIER      NULL,
    [DataConsulenza]        DATE              NOT NULL,
    [IdTipologiaPratica]    INTEGER			  NOT NULL,
    [DescrizioneConsulenza] NVARCHAR (200)    NOT NULL,
    [IdTipologiaContatto]   INTEGER			      NULL,
	[Nominativo] 		    NVARCHAR (50)         NULL,
	[Email] 			    NVARCHAR (50)         NULL,
	[IdComune] 			    INTEGER               NULL
    CONSTRAINT [PK_Consulenze] PRIMARY KEY CLUSTERED ([IdConsulenza])
);
GO

CREATE INDEX [IX_Consulenze_IdSocio] ON [dbo].[Consulenze] ([IdSocio]);
GO

ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_Soci]
								    FOREIGN KEY ([IdSocio]) REFERENCES [dbo].[Soci] ([IdSocio])
								    ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_TipologiePratica]
									FOREIGN KEY ([IdTipologiaPratica]) REFERENCES [dbo].[TipologiePratica] ([IdTipologiaPratica])
									ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_TipologieContatto]
									FOREIGN KEY ([IdTipologiaContatto]) REFERENCES [dbo].[TipologieContatto] ([IdTipologiaContatto])
									ON DELETE NO ACTION;
GO

ALTER TABLE [dbo].[Consulenze] ADD CONSTRAINT [FK_Consulenze_Comuni]
									FOREIGN KEY ([IdComune]) REFERENCES [dbo].[Comuni] ([IdComune])
									ON DELETE NO ACTION;
GO