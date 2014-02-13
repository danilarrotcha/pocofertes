USE [master]
GO

/****** Object: Table [dbo].[OfferNotes] Script Date: 2/13/2014 9:48:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[OfferNotes];


GO
CREATE TABLE [dbo].[OfferNotes] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [OfferID] INT            NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL
);


