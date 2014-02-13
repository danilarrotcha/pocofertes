USE [master]
GO

/****** Object: Table [dbo].[Managers] Script Date: 2/13/2014 9:47:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Managers];


GO
CREATE TABLE [dbo].[Managers] (
    [ManagerID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [SurName]   NVARCHAR (50) NOT NULL
);


