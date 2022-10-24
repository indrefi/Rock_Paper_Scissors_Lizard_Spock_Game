IF NOT EXISTS (SELECT 0 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'Game' 
           AND TABLE_NAME = 'Scoreboard')
BEGIN
    CREATE TABLE [Game].[Scoreboard]
    (
	    [ID] INT NOT NULL PRIMARY KEY IDENTITY, 
        [FirstPlayerID] INT NOT NULL,
        [SecondPlayerID] INT NOT NULL,
        [FirstPlayerChoiseID] INT NOT NULL,
        [SecondPlayerChoiseID] INT NOT NULL,
        [GameResultID] INT NOT NULL,
        [CreatedAt] DATETIME NOT NULL,
        CONSTRAINT [FK_Player_FirstPlayerID] FOREIGN KEY ([FirstPlayerID]) REFERENCES [Game].[Player]([ID]),
        CONSTRAINT [FK_Player_SecondPlayerID] FOREIGN KEY ([SecondPlayerID]) REFERENCES [Game].[Player]([ID]),
        CONSTRAINT [FK_Choise_FirstPlayerID] FOREIGN KEY ([FirstPlayerChoiseID]) REFERENCES [Game].[Choise]([ID]),
        CONSTRAINT [FK_Choise_SecondPlayerID] FOREIGN KEY ([SecondPlayerChoiseID]) REFERENCES [Game].[Choise]([ID]),
        CONSTRAINT [FK_GameResult_GameResultID] FOREIGN KEY ([GameResultID]) REFERENCES [Game].[GameResult]([ID])
    )
END
ELSE
BEGIN
    IF NOT EXISTS(SELECT 1 FROM SYS.COLUMNS 
                    WHERE NAME = N'CreatedAt'
                    AND OBJECT_ID = Object_ID(N'Game.Scoreboard'))
    BEGIN    
        ALTER TABLE [Game].[Scoreboard] ADD [CreatedAt] DATETIME NOT NULL;
    END
END