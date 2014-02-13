USE [master]
GO

/****** Object: Table [dbo].[OfferStatus] Script Date: 2/13/2014 9:48:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[OfferStatus];


GO
CREATE TABLE [dbo].[OfferStatus] (
    [OfferStatusID] INT           NOT NULL,
    [Description]   NVARCHAR (50) NOT NULL
);


