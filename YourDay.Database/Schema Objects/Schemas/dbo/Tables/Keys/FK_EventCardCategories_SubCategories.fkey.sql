ALTER TABLE [dbo].[EventCardCategories]
    ADD CONSTRAINT [FK_EventCardCategories_SubCategories] FOREIGN KEY ([SubcategoryId]) REFERENCES [dbo].[SubCategories] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

