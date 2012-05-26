ALTER TABLE [dbo].[Media]
    ADD CONSTRAINT [FK_Media_MediaType] FOREIGN KEY ([RelationType]) REFERENCES [dbo].[MediaType] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

