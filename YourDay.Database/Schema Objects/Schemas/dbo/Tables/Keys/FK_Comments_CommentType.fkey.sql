ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [FK_Comments_CommentType] FOREIGN KEY ([Type]) REFERENCES [dbo].[CommentType] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

