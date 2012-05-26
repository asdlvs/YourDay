ALTER TABLE [dbo].[EventCardCategories]
    ADD CONSTRAINT [FK_EventCardCategories_EventCards] FOREIGN KEY ([EventCardId]) REFERENCES [dbo].[EventCards] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

