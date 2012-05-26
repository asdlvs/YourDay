ALTER TABLE [dbo].[EventCards]
    ADD CONSTRAINT [DF_EventCards_Budjet] DEFAULT ((0)) FOR [Budjet];

