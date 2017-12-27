CREATE TABLE [dbo].[PurcheaseReturnDetails] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [PurchaseReturnId] INT             NULL,
    [ProductId]        INT             NULL,
    [ProductName]      NVARCHAR (50)   NULL,
    [ProductCode]      NVARCHAR (50)   NULL,
    [UnitePrice]       DECIMAL (18, 2) NULL,
    [Data]             NVARCHAR (50)   NULL,
    [Quantity]         DECIMAL (18, 1) NULL,
    [Discount]         DECIMAL (18, 2) NULL,
    [TotalPrice]       DECIMAL (18, 2) NULL,
    [Remarks]          NVARCHAR (500)  NULL,
    [IsActive]         BIT             NULL,
    [IsArchive]        BIT             NULL,
    [CreatedBy]        NVARCHAR (50)   NULL,
    [CreatedAt]        NVARCHAR (50)   NULL,
    [CreatedFrom]      NVARCHAR (50)   NULL,
    [LastUpdateBy]     NVARCHAR (50)   NULL,
    [LastUpdateAt]     NVARCHAR (50)   NULL,
    [LastUpdateFrom]   NVARCHAR (50)   NULL,
    CONSTRAINT [PK__Purcheas__3214EC07AC1DED45] PRIMARY KEY CLUSTERED ([Id] ASC)
);

