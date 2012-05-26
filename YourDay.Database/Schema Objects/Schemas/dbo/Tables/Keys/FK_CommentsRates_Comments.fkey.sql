ALTER TABLE [dbo].[CommentsRates]
    ADD CONSTRAINT [FK_CommentsRates_Comments] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Comments] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

