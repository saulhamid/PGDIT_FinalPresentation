CREATE TABLE [dbo].[UserRoles] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [BranchId]   INT            NOT NULL,
    [UserInfoId] NVARCHAR (128) NULL,
    [RoleInfoId] NVARCHAR (128) NULL,
    [IsArchived] BIT            NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

