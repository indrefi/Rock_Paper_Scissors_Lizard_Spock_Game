IF NOT EXISTS (SELECT 0 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'Game' 
           AND TABLE_NAME = 'GameResult')
BEGIN
    CREATE TABLE [Game].[GameResult]
    (
	    [ID] INT NOT NULL PRIMARY KEY, 
        [Name] NVARCHAR(12) NOT NULL,
        CONSTRAINT [CK_Game_GameResult_Name_Length] CHECK (LEN(Name) <= 12)
    )
END;