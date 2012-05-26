ALTER TABLE [dbo].[EventCardCompany]
    ADD CONSTRAINT [FK_EventCardCompany_EventCardCategories] FOREIGN KEY ([EventCardId], [SubcategoryId]) REFERENCES [dbo].[EventCardCategories] ([EventCardId], [SubcategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

