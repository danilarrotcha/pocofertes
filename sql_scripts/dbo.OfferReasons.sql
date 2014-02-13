USE [master]
GO

/****** Object: Table [dbo].[OfferReasons] Script Date: 2/13/2014 9:48:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[OfferReasons];


GO
CREATE TABLE [dbo].[OfferReasons] (
    [ReasonID]    INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (250) NOT NULL
);


