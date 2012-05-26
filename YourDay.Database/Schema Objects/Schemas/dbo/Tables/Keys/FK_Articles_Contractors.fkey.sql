ALTER TABLE [dbo].[Articles]
    ADD CONSTRAINT [FK_Articles_Contractors] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Contractors] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

