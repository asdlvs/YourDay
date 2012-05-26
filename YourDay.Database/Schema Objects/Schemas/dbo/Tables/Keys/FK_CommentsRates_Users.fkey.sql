ALTER TABLE [dbo].[CommentsRates]
    ADD CONSTRAINT [FK_CommentsRates_Users] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

