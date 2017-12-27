CREATE TABLE [dbo].[Stocks] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [ProductId]       INT             NULL,
    [TotalPaid]       DECIMAL (18, 2) NULL,
    [TotalPrice]      DECIMAL (18, 2) NULL,
    [Quantity]        DECIMAL (18, 2) NULL,
    [GrandTotal]      DECIMAL (18, 2) NULL,
    [Date]            NVARCHAR (50)   NULL,
    [FinalUnitPrice]  DECIMAL (18, 2) NULL,
    [OpeningQuantity] DECIMAL (18, 2) NULL,
    [Remarks]         NVARCHAR (500)  NULL,
    [StockStutes]     BIT             NULL,
    [IsActive]        BIT             NULL,
    [IsArchive]       BIT             NULL,
    [CreatedBy]       NVARCHAR (50)   NULL,
    [CreatedAt]       NVARCHAR (50)   NULL,
    [CreatedFrom]     NVARCHAR (50)   NULL,
    CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED ([Id] ASC)
);

