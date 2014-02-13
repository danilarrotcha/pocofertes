USE [master]
GO

/****** Object: Table [dbo].[Offer] Script Date: 2/13/2014 9:48:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Offer];


GO
CREATE TABLE [dbo].[Offer] (
    [OfferID]       INT            IDENTITY (1, 1) NOT NULL,
    [OfferTypeID]   INT            NOT NULL,
    [OfferStatusID] INT            NOT NULL,
    [CreatedOn]     DATETIME2 (7)  NOT NULL,
    [FollowedOn]    DATETIME2 (7)  NULL,
    [SuccessAmount] INT            NULL,
    [ReasonID]      INT            NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [PriceAmount]   MONEY          NOT NULL,
    [CustomerID]    INT            NOT NULL,
    [ManagerID]     INT            NOT NULL
);


