USE [GameStore]
GO

INSERT INTO [dbo].[Games]
           ([Name]
           ,[Price]
           ,[Details]
           ,[ImageUrl])
     VALUES
           ('Fortnite',
           0, 
			'The battle royale game',
           'assets\Images\fortnite.jpg'),
		   ('Counter Strike', 15, '5 v 5 command game',
		   'assets\Images\cs.jpg'),
		   ('Dota 2', 5, 'MMO RPG MOBA 5 v 5 team game', 
		   'assets\Images\dota.jpg'),
		   ('Battlefiled', 25, 'The path in the military world', 
		   'assets\Images\battlefield.jpg'),
		   ('Among us', 10, 'The funny game for you and your friends', 
		   'assets\Images\among.jpg'),
		   ('GTA V', 36, 'The open world game about USA gangster life', 
		   'assets\Images\gta.jpg')

GO




