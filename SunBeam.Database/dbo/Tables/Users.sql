CREATE TABLE [dbo].[Users] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [FullName]         NCHAR (100)   NULL,
    [UserName]         NCHAR (100)   NULL,
    [Email]            NCHAR (100)   NULL,
    [LogId]            NCHAR (50)    NULL,
    [Password]         NCHAR (50)    NULL,
    [VerificationCode] NCHAR (20)    NULL,
    [BranchId]         INT           NULL,
    [EmployeeId]       NVARCHAR (50) NULL,
    [IsAdmin]          BIT           NULL,
    [Remember]         BIT           NOT NULL,
    [IsActive]         BIT           NULL,
    [IsVerified]       BIT           NULL,
    [IsArchived]       BIT           NULL,
    [CreatedBy]        NVARCHAR (50) NULL,
    [CreatedAt]        NVARCHAR (50) NULL,
    [CreatedFrom]      VARCHAR (50)  NULL,
    [LastUpdateBy]     NVARCHAR (50) NULL,
    [LastUpdateAt]     NVARCHAR (50) NULL,
    [LastUpdateFrom]   VARCHAR (50)  NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

