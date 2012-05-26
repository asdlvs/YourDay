ALTER TABLE [dbo].[EventCards]
    ADD CONSTRAINT [FK_EventCards_Users] FOREIGN KEY ([Creator]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

