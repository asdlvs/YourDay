ALTER TABLE [dbo].[UserActivities]
    ADD CONSTRAINT [FK_UserActivities_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

