ALTER TABLE [dbo].[EventCardCompany]
    ADD CONSTRAINT [FK_EventCardCompany_ContractorCategories] FOREIGN KEY ([ContractorId], [SubcategoryId]) REFERENCES [dbo].[ContractorCategories] ([ContractorId], [SubcategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

