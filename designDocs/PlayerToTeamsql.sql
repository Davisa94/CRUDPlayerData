CREATE TABLE [dbo].[PlayerToTeam]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [player_id] INT NOT NULL UNIQUE REFERENCES dbo.playerInfo(Id), 
    [team_id] INT NOT NULL
)
