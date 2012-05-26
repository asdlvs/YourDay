CREATE TABLE [dbo].[EventCards] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (150)  NOT NULL,
    [Creator]           INT             NOT NULL,
    [Date]              DATE            NOT NULL,
    [Type]              INT             NOT NULL,
    [StartTime]         NVARCHAR (50)   NULL,
    [EndTime]           NVARCHAR (50)   NULL,
    [Description]       NVARCHAR (MAX)  NULL,
    [WhoSee]            INT             NOT NULL,
    [ShowToEventAgency] BIT             NOT NULL,
    [ShowToContractors] BIT             NOT NULL,
    [Budjet]            DECIMAL (18, 2) NOT NULL
);

