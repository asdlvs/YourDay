ALTER TABLE [dbo].[SubCategories]
    ADD CONSTRAINT [FK_SubCategories_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

