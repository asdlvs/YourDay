CREATE TABLE [dbo].[SubCategories] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [CategoryId] INT             NOT NULL,
    [Title]      NVARCHAR (150)  NOT NULL,
    [Weight]     DECIMAL (18, 2) NULL,
    [Persons]    NVARCHAR (150)  NULL
);

