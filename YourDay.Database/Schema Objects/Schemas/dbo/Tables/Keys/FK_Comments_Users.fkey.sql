﻿ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [FK_Comments_Users] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

