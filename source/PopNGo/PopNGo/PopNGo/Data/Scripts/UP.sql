-- CREATE DATABASE [PopNGoDB];

USE [PopNGoDB];

CREATE TABLE [PG_User] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [ASPNETUserID] NVARCHAR(255) NOT NULL
);

CREATE TABLE [FavoriteEvents] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [BookmarkListID] INTEGER NOT NULL,
  [EventID] INTEGER NOT NULL
);

CREATE TABLE [BookmarkList] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [UserID] INTEGER NOT NULL,
  [Title] NVARCHAR(128) NOT NULL,
)

CREATE TABLE [EventHistory] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [UserID] INTEGER NOT NULL,
  [EventID] INTEGER NOT NULL,
  [ViewedDate] DATETIME NOT NULL
);

CREATE TABLE [Event] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [ApiEventID] NVARCHAR(255) NOT NULL,
  [EventDate] DATETIME NOT NULL,
  [EventName] NVARCHAR(255) NOT NULL,
  [EventDescription] NVARCHAR(1000) NOT NULL,
  [EventLocation] NVARCHAR(255) NOT NULL,
  [EventImage] NVARCHAR(255)
);

CREATE TABLE [Tag] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(255) NOT NULL,
  [BackgroundColor] NVARCHAR(255) NOT NULL,
  [TextColor] NVARCHAR(255) NOT NULL
);

CREATE TABLE [ScheduledNotification] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [UserID] INTEGER NOT NULL,
  [Time] DATETIME NOT NULL,
  [Type] NVARCHAR(255) NOT NULL
);

ALTER TABLE [EventHistory] ADD CONSTRAINT FK_EventHistory_UserID FOREIGN KEY ([UserID]) REFERENCES [PG_User] ([ID]);
ALTER TABLE [EventHistory] ADD CONSTRAINT FK_EventHistory_EventID FOREIGN KEY ([EventID]) REFERENCES [Event] ([ID]);

ALTER TABLE [FavoriteEvents] ADD CONSTRAINT FK_FavoriteEvents_EventID FOREIGN KEY ([EventID]) REFERENCES [Event] ([ID]);
ALTER TABLE [FavoriteEvents] ADD CONSTRAINT FK_FavoriteEvents_BookmarkListID FOREIGN KEY ([BookmarkListID]) REFERENCES [BookmarkList] ([ID]);

ALTER TABLE [ScheduledNotification] ADD CONSTRAINT FK_ScheduledNotification_UserID FOREIGN KEY ([UserID]) REFERENCES [PG_User] ([ID]);
