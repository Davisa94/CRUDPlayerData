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


 -- ============================================
 -- Mysql database 
 -- ============================================

 CREATE TABLE `PlayerTeamData`.`playerInfo` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(255) NOT NULL,
  `MiddleName` VARCHAR(255) NOT NULL,
  `LastName` VARCHAR(255) NOT NULL,
  `DateOfBirth` DATE NOT NULL,
  `HeightInches` TINYINT NOT NULL,
  `JerseyNumber` TINYINT NOT NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `PlayerTeamData`.`Teams` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `TeamLocation` VARCHAR(255) NOT NULL,
  `TeamName` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `PlayerToTeam` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `player_id` int(11) NOT NULL,
  `team_id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `PTT_player_id_idx` (`player_id`),
  KEY `PTT_team_id_idx` (`team_id`),
  CONSTRAINT `PTT_player_id` FOREIGN KEY (`player_id`) REFERENCES `playerInfo` (`Id`),
  CONSTRAINT `PTT_team_id` FOREIGN KEY (`team_id`) REFERENCES `Teams` (`Id`)
);

CREATE TABLE `PlayerTeamData`.`PlayerToPastTeams` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Player_id` INT NOT NULL,
  `Team_id` INT NOT NULL,
  PRIMARY KEY (`Id`, `Player_id`),
  INDEX `PTPT_player_id_idx` (`Player_id` ASC) VISIBLE,
  INDEX `PTPT_team_id_idx` (`Team_id` ASC) VISIBLE,
  CONSTRAINT `PTPT_player_id`
    FOREIGN KEY (`Player_id`)
    REFERENCES `PlayerTeamData`.`playerInfo` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `PTPT_team_id`
    FOREIGN KEY (`Team_id`)
    REFERENCES `PlayerTeamData`.`Teams` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
