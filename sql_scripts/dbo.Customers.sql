USE [master]
GO

/****** Object: Table [dbo].[Customers] Script Date: 2/13/2014 9:47:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Customers];


GO
CREATE TABLE [dbo].[Customers] (
    [CustomerID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [SurName]    NVARCHAR (50) NOT NULL,
    [IsClient]   BIT           NOT NULL
);


