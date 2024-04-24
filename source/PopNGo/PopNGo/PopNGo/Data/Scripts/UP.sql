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
  [EventDate] DATETIME,
  [EventName] NVARCHAR(255),
  [EventDescription] NVARCHAR(MAX),
  [EventLocation] NVARCHAR(255),
  [EventImage] NVARCHAR(MAX),
  [EventOriginalLink] NVARCHAR(MAX),
  [Latitude] DECIMAL(9, 6),
  [Longitude] DECIMAL(9, 6),
  [VenuePhoneNumber] NVARCHAR(255),
  [VenueName] NVARCHAR(255),
  [VenueRating] DECIMAL(2, 1),
  [VenueWebsite] NVARCHAR(255),
);

CREATE TABLE [TicketLink] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [EventID] INTEGER NOT NULL,
  [Source] NVARCHAR(255),
  [Link] NVARCHAR(255)
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

CREATE TABLE [WeatherForecast] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [WeatherId] INTEGER NOT NULL,
  [Date] DATETIME NOT NULL,
  [Condition] NVARCHAR(255) NOT NULL,
  [MinTemp] FLOAT NOT NULL,
  [MaxTemp] FLOAT NOT NULL,
  [CloudCover] FLOAT NOT NULL,
  [PrecipitationType] NVARCHAR(255) NOT NULL,
  [PrecipitationAmount] FLOAT NOT NULL,
  [PrecipitationChance] FLOAT NOT NULL,
  [Humidity] FLOAT NOT NULL,
);

CREATE TABLE [Weather] (
  [ID] INTEGER PRIMARY KEY IDENTITY(1, 1),
  [Latitude] DECIMAL(9, 6) NOT NULL,
  [Longitude] DECIMAL(9, 6) NOT NULL,
  [DateCached] DATETIME NOT NULL,
)

ALTER TABLE [EventHistory] ADD CONSTRAINT FK_EventHistory_UserID FOREIGN KEY ([UserID]) REFERENCES [PG_User] ([ID]);
ALTER TABLE [EventHistory] ADD CONSTRAINT FK_EventHistory_EventID FOREIGN KEY ([EventID]) REFERENCES [Event] ([ID]);

ALTER TABLE [FavoriteEvents] ADD CONSTRAINT FK_FavoriteEvents_EventID FOREIGN KEY ([EventID]) REFERENCES [Event] ([ID]);
ALTER TABLE [FavoriteEvents] ADD CONSTRAINT FK_FavoriteEvents_BookmarkListID FOREIGN KEY ([BookmarkListID]) REFERENCES [BookmarkList] ([ID]);

ALTER TABLE [TicketLink] ADD CONSTRAINT FK_TicketLink_EventID FOREIGN KEY ([EventID]) REFERENCES [Event] ([ID]);

ALTER TABLE [ScheduledNotification] ADD CONSTRAINT FK_ScheduledNotification_UserID FOREIGN KEY ([UserID]) REFERENCES [PG_User] ([ID]);

ALTER TABLE [WeatherForecast] ADD CONSTRAINT FK_WeatherForecast_WeatherId FOREIGN KEY ([WeatherId]) REFERENCES [Weather] ([ID]);
