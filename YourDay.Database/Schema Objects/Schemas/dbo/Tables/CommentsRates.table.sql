CREATE TABLE [dbo].[CommentsRates] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ItemId]     INT NOT NULL,
    [AuthorId]   INT NOT NULL,
    [IsPositive] BIT NOT NULL
);

