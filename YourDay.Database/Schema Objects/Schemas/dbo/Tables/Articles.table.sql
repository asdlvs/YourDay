CREATE TABLE [dbo].[Articles] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (150) NOT NULL,
    [Content]  NVARCHAR (MAX) NULL,
    [AuthorId] INT            NOT NULL,
    [Image]    NVARCHAR (50)  NULL,
    [DateTime] DATETIME       NULL
);

