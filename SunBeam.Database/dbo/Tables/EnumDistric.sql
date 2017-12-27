CREATE TABLE [dbo].[EnumDistric] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (200) NOT NULL,
    [CountryId]      INT            NOT NULL,
    [DivisionId]     INT            NOT NULL,
    [Remarks]        NVARCHAR (500) NULL,
    [IsActive]       BIT            NOT NULL,
    [IsArchive]      BIT            NOT NULL,
    [CreatedBy]      NVARCHAR (50)  NOT NULL,
    [CreatedAt]      NVARCHAR (50)  NOT NULL,
    [CreatedFrom]    NVARCHAR (50)  NOT NULL,
    [LastUpdateBy]   NVARCHAR (50)  NOT NULL,
    [LastUpdateAt]   NVARCHAR (50)  NOT NULL,
    [LastUpdateFrom] NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_EnumDistric] PRIMARY KEY CLUSTERED ([Id] ASC)
);

