CREATE DATABASE PlayerTeamData;

USE PlayerTeamData;

USE [PlayerTeamData]
GO

/****** Object: Table [dbo].[playerInfo] Script Date: 3/8/2019 1:16:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[playerInfo] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (255) NOT NULL,
    [MiddleName]   VARCHAR (255) NULL,
    [LastName]     VARCHAR (255) NOT NULL,
    [DateOfBirth]  DATE          NOT NULL,
    [HeightInches] TINYINT       NOT NULL,
    [JerseyNumber] TINYINT       NOT NULL
);

USE [PlayerTeamData]
GO

/****** Object: Table [dbo].[PlayerToPastTeams] Script Date: 3/8/2019 1:17:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerToPastTeams]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Player_id] INT NOT NULL REFERENCES dbo.playerInfo(Id) ON DELETE CASCADE ON UPDATE CASCADE, 
    [Team_id] INT NOT NULL REFERENCES dbo.Teams(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

USE [PlayerTeamData]
GO

/****** Object: Table [dbo].[PlayerToTeam] Script Date: 3/8/2019 1:17:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerToTeam]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [player_id] INT NOT NULL UNIQUE REFERENCES dbo.playerInfo(Id) ON DELETE CASCADE ON UPDATE CASCADE, 
    [team_id] INT NOT NULL REFERENCES dbo.Teams(Id) ON DELETE CASCADE ON UPDATE CASCADE
);


USE [PlayerTeamData]
GO

/****** Object: Table [dbo].[Teams] Script Date: 3/8/2019 1:17:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Teams] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [TeamLocation] VARCHAR (255) NULL,
    [TeamName]     VARCHAR (255) NOT NULL
);




