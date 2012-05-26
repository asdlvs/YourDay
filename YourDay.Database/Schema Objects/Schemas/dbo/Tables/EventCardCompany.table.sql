CREATE TABLE [dbo].[EventCardCompany] (
    [EventCardId]   INT NOT NULL,
    [ContractorId]  INT NOT NULL,
    [SubcategoryId] INT NOT NULL,
    [State]         INT NOT NULL,
    [RelationKey]   AS  ((((CONVERT([varchar](5),[EventCardId],(0))+'|')+CONVERT([varchar](5),[ContractorId],(0)))+'|')+CONVERT([varchar](5),[SubcategoryId],(0))) PERSISTED
);

