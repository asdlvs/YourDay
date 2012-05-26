CREATE TABLE [dbo].[MediaRate] (
    [Id]                      INT IDENTITY (1, 1) NOT NULL,
    [EventCardCompanyMediaId] INT NOT NULL,
    [Author]                  INT NOT NULL,
    [IsPositive]              BIT NOT NULL
);

