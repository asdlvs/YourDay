ALTER TABLE [dbo].[Media]
    ADD CONSTRAINT [DF_EventCardCompanyMedia_Type] DEFAULT ((1)) FOR [Type];

