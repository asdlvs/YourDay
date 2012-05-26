CREATE TABLE [dbo].[ArticleRate] (
    [Id]         INT NOT NULL,
    [AuthorId]   INT NOT NULL,
    [IsPositive] BIT NOT NULL,
    [ArticleId]  INT NOT NULL
);

