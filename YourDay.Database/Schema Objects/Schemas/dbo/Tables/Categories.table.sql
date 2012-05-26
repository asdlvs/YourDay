CREATE TABLE [dbo].[Categories] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [Title]  NVARCHAR (150)  NOT NULL,
    [Weight] DECIMAL (18, 4) NOT NULL
);

