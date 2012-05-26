CREATE TABLE [dbo].[NewsRate] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [AuthorId]   INT NOT NULL,
    [NewsId]     INT NOT NULL,
    [IsPositive] BIT NOT NULL
);

