CREATE TABLE [dbo].[PlayerToPastTeams]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Player_id] INT NOT NULL REFERENCES dbo.playerInfo(Id), 
    [Team_id] INT NOT NULL REFERENCES dbo.Teams(Id)
)
