ALTER TABLE [dbo].[Security]
    ADD CONSTRAINT [DF_Security_IsApproved] DEFAULT ((0)) FOR [IsApproved];

