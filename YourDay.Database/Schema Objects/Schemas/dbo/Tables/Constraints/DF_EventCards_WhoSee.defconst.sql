ALTER TABLE [dbo].[EventCards]
    ADD CONSTRAINT [DF_EventCards_WhoSee] DEFAULT ((1)) FOR [WhoSee];

