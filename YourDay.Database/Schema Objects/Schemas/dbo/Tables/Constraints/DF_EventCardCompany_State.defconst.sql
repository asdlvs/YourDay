ALTER TABLE [dbo].[EventCardCompany]
    ADD CONSTRAINT [DF_EventCardCompany_State] DEFAULT ((1)) FOR [State];

