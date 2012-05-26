ALTER TABLE [dbo].[ContractorCategories]
    ADD CONSTRAINT [FK_ContractorCategories_SubCategories] FOREIGN KEY ([SubcategoryId]) REFERENCES [dbo].[SubCategories] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

