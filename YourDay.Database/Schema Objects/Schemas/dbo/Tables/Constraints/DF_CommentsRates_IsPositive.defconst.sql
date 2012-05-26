ALTER TABLE [dbo].[CommentsRates]
    ADD CONSTRAINT [DF_CommentsRates_IsPositive] DEFAULT ((0)) FOR [IsPositive];

