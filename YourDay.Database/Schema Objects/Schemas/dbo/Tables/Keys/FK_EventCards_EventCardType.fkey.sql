ALTER TABLE [dbo].[EventCards]
    ADD CONSTRAINT [FK_EventCards_EventCardType] FOREIGN KEY ([Type]) REFERENCES [dbo].[EventCardType] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

