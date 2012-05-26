CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50)  NULL,
    [LastName]     NVARCHAR (50)  NULL,
    [Login]        NVARCHAR (50)  NULL,
    [EMail]        NVARCHAR (150) NULL,
    [AvatarOffset] NVARCHAR (50)  NULL,
    [IsDeleted]    BIT            NOT NULL
);

