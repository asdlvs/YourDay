ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [DF_Users_IsDeleted] DEFAULT ((0)) FOR [IsDeleted];

