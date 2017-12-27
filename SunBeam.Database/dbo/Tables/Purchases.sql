CREATE TABLE [dbo].[Purchases] (
    [Id]             INT             NOT NULL,
    [InvoiecNo]      NVARCHAR (200)  NULL,
    [SupplierId]     INT             NULL,
    [EmployeeId]     INT             NULL,
    [Date]           NVARCHAR (50)   NULL,
    [Discount]       DECIMAL (18, 2) NULL,
    [CouponName]     NVARCHAR (100)  NULL,
    [CouponAmunt]    DECIMAL (18, 2) NULL,
    [Remarks]        NVARCHAR (500)  NULL,
    [IsActive]       BIT             NULL,
    [IsArchive]      BIT             NULL,
    [CreatedBy]      NVARCHAR (50)   NULL,
    [CreatedAt]      NVARCHAR (50)   NULL,
    [CreatedFrom]    NVARCHAR (50)   NULL,
    [LastUpdateBy]   NVARCHAR (50)   NULL,
    [LastUpdateAt]   NVARCHAR (50)   NULL,
    [LastUpdateFrom] NVARCHAR (50)   NULL,
    CONSTRAINT [PK_Purchases] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ__Purchase__3214EC06CB33F1A6] UNIQUE NONCLUSTERED ([Id] ASC),
    CONSTRAINT [UQ__Purchase__B358CA759092066F] UNIQUE NONCLUSTERED ([InvoiecNo] ASC)
);

