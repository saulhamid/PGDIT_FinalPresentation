﻿CREATE TABLE [dbo].[UOM] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Code]           NVARCHAR (20)  NULL,
    [Name]           NVARCHAR (200) NOT NULL,
    [Remarks]        NVARCHAR (500) NULL,
    [IsActive]       BIT            NULL,
    [IsArchive]      BIT            NULL,
    [CreatedBy]      NVARCHAR (50)  NULL,
    [CreatedAt]      NVARCHAR (50)  NULL,
    [CreatedFrom]    NVARCHAR (50)  NULL,
    [LastUpdateBy]   NVARCHAR (50)  NULL,
    [LastUpdateAt]   NVARCHAR (50)  NULL,
    [LastUpdateFrom] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_UOM] PRIMARY KEY CLUSTERED ([Id] ASC)
);

