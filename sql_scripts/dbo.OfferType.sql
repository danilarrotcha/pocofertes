USE [master]
GO

/****** Object: Table [dbo].[OfferType] Script Date: 2/13/2014 9:48:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[OfferType];


GO
CREATE TABLE [dbo].[OfferType] (
    [OfferTypeID] INT           NOT NULL,
    [Description] NVARCHAR (50) NOT NULL
);


