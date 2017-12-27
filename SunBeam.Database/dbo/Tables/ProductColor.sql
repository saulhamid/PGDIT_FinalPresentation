CREATE TABLE [dbo].[ProductColor] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Code]           NVARCHAR (20)  NULL,
    [Name]           NVARCHAR (200) NULL,
    [Remarks]        NVARCHAR (500) NULL,
    [IsActive]       BIT            NULL,
    [IsArchive]      BIT            NULL,
    [CreatedBy]      NVARCHAR (20)  NULL,
    [CreatedAt]      NVARCHAR (14)  NULL,
    [CreatedFrom]    NVARCHAR (50)  NULL,
    [LastUpdateBy]   NVARCHAR (20)  NULL,
    [LastUpdateAt]   NVARCHAR (14)  NULL,
    [LastUpdateFrom] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED ([Id] ASC)
);

