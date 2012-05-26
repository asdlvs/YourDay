CREATE TABLE [dbo].[Comments] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [AuthorId]    INT             NOT NULL,
    [ReceiverId]  INT             NULL,
    [DateTime]    DATETIME        NOT NULL,
    [Text]        NVARCHAR (1500) NULL,
    [Type]        INT             NOT NULL,
    [RelationId]  INT             NOT NULL,
    [AlreadyRead] BIT             NOT NULL
);

