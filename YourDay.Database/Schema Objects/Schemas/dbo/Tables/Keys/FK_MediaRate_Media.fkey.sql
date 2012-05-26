ALTER TABLE [dbo].[MediaRate]
    ADD CONSTRAINT [FK_MediaRate_Media] FOREIGN KEY ([EventCardCompanyMediaId]) REFERENCES [dbo].[Media] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

