ALTER TABLE [dbo].[Media]
    ADD CONSTRAINT [FK_EventCardCompanyMedia_MediaType] FOREIGN KEY ([Type]) REFERENCES [dbo].[MediaType] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

