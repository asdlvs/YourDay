CREATE TABLE [dbo].[News] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (150)  NULL,
    [Content]  NVARCHAR (1500) NULL,
    [Image]    NVARCHAR (50)   NULL,
    [DateTime] DATETIME        NULL
);

