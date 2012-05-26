CREATE TABLE [dbo].[Media] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (150)  NOT NULL,
    [Type]         INT             NULL,
    [Description]  NVARCHAR (1000) NULL,
    [RelationId]   VARCHAR (17)    NULL,
    [RelationType] INT             NULL
);

