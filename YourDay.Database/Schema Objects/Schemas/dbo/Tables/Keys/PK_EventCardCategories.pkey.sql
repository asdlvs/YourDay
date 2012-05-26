﻿ALTER TABLE [dbo].[EventCardCategories]
    ADD CONSTRAINT [PK_EventCardCategories] PRIMARY KEY CLUSTERED ([EventCardId] ASC, [SubcategoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
