ALTER TABLE [dbo].[Contractors]
    ADD CONSTRAINT [FK_Contractors_Cities] FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

