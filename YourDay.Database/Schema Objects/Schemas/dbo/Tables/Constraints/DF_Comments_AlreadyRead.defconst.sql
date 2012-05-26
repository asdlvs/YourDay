ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [DF_Comments_AlreadyRead] DEFAULT ((0)) FOR [AlreadyRead];

