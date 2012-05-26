ALTER TABLE [dbo].[ContractorCategories]
    ADD CONSTRAINT [FK_ContractorCategories_Contractors] FOREIGN KEY ([ContractorId]) REFERENCES [dbo].[Contractors] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

