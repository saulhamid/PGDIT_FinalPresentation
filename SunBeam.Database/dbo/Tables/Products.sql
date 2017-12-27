CREATE TABLE [dbo].[Products] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (200)  NULL,
    [Code]                NVARCHAR (20)   NULL,
    [UOMId]               INT             NULL,
    [ProductBrandId]      INT             NULL,
    [ProductCatagoriesId] INT             NULL,
    [ProductColorId]      INT             NULL,
    [ProductSizeId]       INT             NULL,
    [ProductTypeId]       INT             NULL,
    [SupplierId]          INT             NULL,
    [MinimumStock]        INT             NULL,
    [OtherCost]           DECIMAL (18, 2) NULL,
    [Discount]            DECIMAL (18, 2) NULL,
    [UnitePrice]          DECIMAL (18, 2) NULL,
    [Quantity]            DECIMAL (18, 2) NULL,
    [OpeningQuantity]     DECIMAL (18, 2) NULL,
    [Remarks]             NVARCHAR (500)  NULL,
    [IsActive]            BIT             NULL,
    [IsArchive]           BIT             NULL,
    [CreatedBy]           NVARCHAR (20)   NULL,
    [CreatedAt]           NVARCHAR (14)   NULL,
    [CreatedFrom]         NVARCHAR (50)   NULL,
    [LastUpdateBy]        NVARCHAR (20)   NULL,
    [LastUpdateAt]        NVARCHAR (14)   NULL,
    [LastUpdateFrom]      NVARCHAR (50)   NULL,
    CONSTRAINT [PK_Products_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [Name]
    ON [dbo].[Products]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [Name1]
    ON [dbo].[Products]([IsArchive] ASC);

