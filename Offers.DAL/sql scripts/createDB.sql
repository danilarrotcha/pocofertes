CREATE TABLE [dbo].[Agency] (
    [Id]   INT         NOT NULL,
    [Name] NCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Company] (
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    [CIF]  NCHAR (9)      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[OfferReasons] (
    [Id]          INT            NOT NULL,
    [Description] NVARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[OfferStatus] (
    [IdStatus]    INT           NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdStatus] ASC)
);


CREATE TABLE [dbo].[OfferType] (
    [IdType]      INT           NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdType] ASC)
);


CREATE TABLE [dbo].[UserType] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Client] (
    [Id]        INT           NOT NULL,
    [IdCompany] INT           NOT NULL,
    [JoinedOn]  DATETIME2 (7) NOT NULL,
    [LeavedOn]  DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_ToCompany] FOREIGN KEY ([IdCompany]) REFERENCES [dbo].[Company] ([Id])
);

CREATE TABLE [dbo].[Offer] (
    [Id]            INT            NOT NULL,
    [IdOfferType]   INT            NOT NULL,
    [IdOfferStatus] INT            NOT NULL,
    [CreatedOn]     DATETIME2 (7)  NOT NULL,
    [FollowedOn]    DATETIME2 (7)  NULL,
    [SuccessAmount] INT            NULL,
    [IdReason]      INT            NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offer_ToOfferType] FOREIGN KEY ([IdOfferType]) REFERENCES [dbo].[OfferType] ([IdType]),
    CONSTRAINT [FK_Offer_ToOfferStatus] FOREIGN KEY ([IdOfferStatus]) REFERENCES [dbo].[OfferStatus] ([IdStatus]),
    CONSTRAINT [FK_Offer_ToReason] FOREIGN KEY ([IdReason]) REFERENCES [dbo].[OfferReasons] ([Id])
);


CREATE TABLE [dbo].[User] (
    [Id]         INT         NOT NULL,
    [IdUserType] INT         NOT NULL,
    [Name]       NCHAR (30)  NOT NULL,
    [Surname]    NCHAR (50)  NOT NULL,
    [Email]      NCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_ToUserType] FOREIGN KEY ([IdUserType]) REFERENCES [dbo].[UserType] ([Id])
);


CREATE TABLE [dbo].[OfferUsers] (
    [IdOffer]    INT NOT NULL,
    [IdUser]     INT NOT NULL,
    [IdUserType] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdOffer] ASC),
    CONSTRAINT [FK_OfferUsers_ToOffer] FOREIGN KEY ([IdOffer]) REFERENCES [dbo].[Offer] ([Id]),
    CONSTRAINT [FK_OfferUsers_ToUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_OfferUsers_ToUserType] FOREIGN KEY ([IdUserType]) REFERENCES [dbo].[UserType] ([Id])
);

CREATE TABLE [dbo].[AgencyUsers] (
    [IdAgency]   INT NOT NULL,
    [IdUser]     INT NOT NULL,
    [IdUserType] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdAgency] ASC),
    CONSTRAINT [FK_AgencyUsers_ToAgency] FOREIGN KEY ([IdAgency]) REFERENCES [dbo].[Agency] ([Id]),
    CONSTRAINT [FK_AgencyUsers_ToUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_AgencyUsers_ToUserType] FOREIGN KEY ([IdUserType]) REFERENCES [dbo].[UserType] ([Id]),
    CONSTRAINT [CK_AgencyUsers_IdUserType] CHECK ([IdUserType]=(1) OR [IdUserType]=(2))
);


CREATE TABLE [dbo].[CompanyUsers] (
    [IdCompany]  INT NOT NULL,
    [IdUser]     INT NOT NULL,
    [IdUserType] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCompany] ASC),
    CONSTRAINT [FK_CompanyUsers_ToCompany] FOREIGN KEY ([IdCompany]) REFERENCES [dbo].[Company] ([Id]),
    CONSTRAINT [FK_CompanyUsers_ToUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [CK_CompanyUsers_IdUserType] CHECK ([IdUserType]=(0))
);

CREATE TABLE [dbo].[OfferNotes] (
    [Id]      INT            NOT NULL,
    [IdOffer] INT            NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OfferNotes_ToOffer] FOREIGN KEY ([IdOffer]) REFERENCES [dbo].[Offer] ([Id])
);



INSERT INTO [dbo].[OfferReasons] ([Id], [Description]) VALUES (0, N'Fee added ');
INSERT INTO [dbo].[OfferReasons] ([Id], [Description]) VALUES (1, N'Consultation services ');
INSERT INTO [dbo].[OfferReasons] ([Id], [Description]) VALUES (2, N'Income management');
INSERT INTO [dbo].[OfferReasons] ([Id], [Description]) VALUES (3, N'complete Accounting');
INSERT INTO [dbo].[OfferReasons] ([Id], [Description]) VALUES (4, N'multiservice');

INSERT INTO [dbo].[OfferStatus] ([IdStatus], [Description]) VALUES (0, N'Pending to validate');
INSERT INTO [dbo].[OfferStatus] ([IdStatus], [Description]) VALUES (1, N'Validated');
INSERT INTO [dbo].[OfferStatus] ([IdStatus], [Description]) VALUES (2, N'Pending to accept');
INSERT INTO [dbo].[OfferStatus] ([IdStatus], [Description]) VALUES (3, N'Accepted');
INSERT INTO [dbo].[OfferStatus] ([IdStatus], [Description]) VALUES (4, N'Refused');

INSERT INTO [dbo].[OfferType] ([IdType], [Description]) VALUES (0, N'Cuota');
INSERT INTO [dbo].[OfferType] ([IdType], [Description]) VALUES (1, N'Service');
INSERT INTO [dbo].[OfferType] ([IdType], [Description]) VALUES (2, N'Potential Client');

INSERT INTO [dbo].[UserType] ([Id], [Name]) VALUES (0, N'Customer');
INSERT INTO [dbo].[UserType] ([Id], [Name]) VALUES (1, N'Trading');
INSERT INTO [dbo].[UserType] ([Id], [Name]) VALUES (2, N'Manager');

