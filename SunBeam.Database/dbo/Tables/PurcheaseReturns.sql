CREATE TABLE [dbo].[PurcheaseReturns] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [SupplierId]     INT             NULL,
    [EmployeeId]     INT             NULL,
    [PurchaseId]     INT             NULL,
    [Discount]       DECIMAL (18, 2) NULL,
    [TotalPaid]      DECIMAL (18, 2) NULL,
    [InvoiceNo]      NVARCHAR (50)   NULL,
    [Date]           NVARCHAR (50)   NULL,
    [Remarks]        NVARCHAR (500)  NULL,
    [IsActive]       BIT             NULL,
    [IsArchive]      BIT             NULL,
    [CreatedBy]      NVARCHAR (50)   NULL,
    [CreatedAt]      NVARCHAR (50)   NULL,
    [CreatedFrom]    NVARCHAR (50)   NULL,
    [LastUpdateBy]   NVARCHAR (50)   NULL,
    [LastUpdateAt]   NVARCHAR (50)   NULL,
    [LastUpdateFrom] NVARCHAR (50)   NULL,
    CONSTRAINT [PK_PurcheaseReturns] PRIMARY KEY CLUSTERED ([Id] ASC)
);

