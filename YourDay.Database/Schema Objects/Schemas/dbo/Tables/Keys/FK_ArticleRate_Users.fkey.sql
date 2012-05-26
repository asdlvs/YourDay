ALTER TABLE [dbo].[ArticleRate]
    ADD CONSTRAINT [FK_ArticleRate_Users] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

