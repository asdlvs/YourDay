CREATE TABLE [dbo].[Security] (
    [Id]         INT              NOT NULL,
    [Password]   VARBINARY (MAX)  NULL,
    [Salt]       UNIQUEIDENTIFIER NULL,
    [IsApproved] BIT              NOT NULL
);

