ALTER TABLE [dbo].[Contractors]
    ADD CONSTRAINT [FK_Contractors_Users] FOREIGN KEY ([Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

