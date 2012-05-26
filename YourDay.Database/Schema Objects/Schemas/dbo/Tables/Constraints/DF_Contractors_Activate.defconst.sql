ALTER TABLE [dbo].[Contractors]
    ADD CONSTRAINT [DF_Contractors_Activate] DEFAULT ((1)) FOR [Activate];

