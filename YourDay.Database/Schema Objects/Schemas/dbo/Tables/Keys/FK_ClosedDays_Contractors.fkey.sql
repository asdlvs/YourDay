ALTER TABLE [dbo].[ClosedDays]
    ADD CONSTRAINT [FK_ClosedDays_Contractors] FOREIGN KEY ([ContractorId]) REFERENCES [dbo].[Contractors] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

