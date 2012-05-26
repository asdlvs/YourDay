CREATE TABLE [dbo].[UserActivities] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [UserId]      INT      NOT NULL,
    [EventStatus] INT      NOT NULL,
    [DateTime]    DATETIME NULL
);

