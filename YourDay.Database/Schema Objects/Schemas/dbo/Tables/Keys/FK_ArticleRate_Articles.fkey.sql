ALTER TABLE [dbo].[ArticleRate]
    ADD CONSTRAINT [FK_ArticleRate_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

