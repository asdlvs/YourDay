ALTER TABLE [dbo].[Media]
    ADD CONSTRAINT [FK_Media_EventCardCompany] FOREIGN KEY ([RelationId]) REFERENCES [dbo].[EventCardCompany] ([RelationKey]) ON DELETE NO ACTION ON UPDATE NO ACTION;

