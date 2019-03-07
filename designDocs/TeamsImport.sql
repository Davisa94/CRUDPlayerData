BULK
INSERT dbo.Teams
FROM 'D:\Documents\Projects\PlayerData\CRUDPlayerData\designDocs\teams.csv'
WITH (
FIELDTERMINATOR =',',
ROWTERMINATOR = '\n'
);
