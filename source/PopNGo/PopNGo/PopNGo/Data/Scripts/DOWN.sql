USE [PopNGoDB];

-- Drop the foreign key constraints
ALTER TABLE [EventHistory] DROP CONSTRAINT FK_EventHistory_UserID;
ALTER TABLE [EventHistory] DROP CONSTRAINT FK_EventHistory_EventID;

ALTER TABLE [FavoriteEvents] DROP CONSTRAINT FK_FavoriteEvents_BookmarkListID;
ALTER TABLE [FavoriteEvents] DROP CONSTRAINT FK_FavoriteEvents_EventID;

ALTER TABLE [BookmarkList] DROP CONSTRAINT FK_BookmarkList_UserID;

-- Drop the tables
DROP TABLE [PG_User];
DROP TABLE [TAG];
DROP TABLE [FavoriteEvents];
DROP TABLE [BookmarkList];
DROP TABLE [EventHistory];
DROP TABLE [Event];

-- If you also want to drop the database, uncomment the following line
-- DROP DATABASE [PopNGoDB];
