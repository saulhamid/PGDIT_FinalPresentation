CREATE TABLE [dbo].[PurcheaseDetails] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [PurchaseId]     INT             NULL,
    [ProductId]      INT             NULL,
    [UnitePrice]     DECIMAL (18, 2) NULL,
    [Date]           NVARCHAR (50)   NULL,
    [Quantity]       DECIMAL (18, 1) NULL,
    [Discount]       DECIMAL (18, 2) NULL,
    [Slup]           DECIMAL (18, 2) NULL,
    [TotalPrice]     DECIMAL (18, 2) NULL,
    [Remarks]        NVARCHAR (500)  NULL,
    [IsActive]       BIT             NULL,
    [IsArchive]      BIT             NULL,
    [CreatedAt]      NVARCHAR (50)   NULL,
    [CreatedFrom]    NVARCHAR (50)   NULL,
    [CreatedAtBy]    NVARCHAR (50)   NULL,
    [LastUpdateBy]   NVARCHAR (50)   NULL,
    [LastUpdateAt]   NVARCHAR (50)   NULL,
    [LastUpdateFrom] NVARCHAR (50)   NULL,
    CONSTRAINT [PK_PurcheaseDetails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

