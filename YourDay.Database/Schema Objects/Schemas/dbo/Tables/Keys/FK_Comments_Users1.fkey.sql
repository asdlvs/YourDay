ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [FK_Comments_Users1] FOREIGN KEY ([ReceiverId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

