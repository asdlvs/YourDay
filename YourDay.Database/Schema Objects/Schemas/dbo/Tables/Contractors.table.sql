CREATE TABLE [dbo].[Contractors] (
    [Id]          INT             NOT NULL,
    [Site]        NVARCHAR (50)   NULL,
    [VK]          NVARCHAR (50)   NULL,
    [Facebook]    NVARCHAR (50)   NULL,
    [Twitter]     NVARCHAR (50)   NULL,
    [Description] NVARCHAR (1500) NULL,
    [Additional]  NVARCHAR (1500) NULL,
    [City]        INT             NULL,
    [Activate]    BIT             NOT NULL,
    [Phone]       NVARCHAR (50)   NULL
);

