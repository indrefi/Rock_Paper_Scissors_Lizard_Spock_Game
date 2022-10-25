/*
Deployment script for RPSSLDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "RPSSLDB"
:setvar DefaultFilePrefix "RPSSLDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO

/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
BEGIN TRAN

SET QUOTED_IDENTIFIER ON;
GO

SET ANSI_NULLS ON;
GO

SET ANSI_PADDING ON;
GO

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
GO

--   _________      .__                                  
--  /   _____/ ____ |  |__   ____   _____ _____    ______
--  \_____  \_/ ___\|  |  \_/ __ \ /     \\__  \  /  ___/
--  /        \  \___|   Y  \  ___/|  Y Y  \/ __ \_\___ \ 
-- /_______  /\___  >___|  /\___  >__|_|  (____  /____  >
--         \/     \/     \/     \/      \/     \/     \/ 

IF NOT EXISTS (SELECT 0
               FROM INFORMATION_SCHEMA.SCHEMATA 
               WHERE schema_name='Game')
BEGIN
  EXEC sp_executesql N'CREATE SCHEMA Game';
END

-- ___________     ___.   .__                 
-- \__    ___/____ \_ |__ |  |   ____   ______
--   |    |  \__  \ | __ \|  | _/ __ \ /  ___/
--   |    |   / __ \| \_\ \  |_\  ___/ \___ \ 
--   |____|  (____  /___  /____/\___  >____  >
--                \/    \/          \/     \/ 

-- ORDER IS IMPORTANT
IF NOT EXISTS (SELECT 0 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'Game' 
           AND TABLE_NAME = 'Choise')
BEGIN
    CREATE TABLE [Game].[Choise]
    (
	    [ID] INT NOT NULL PRIMARY KEY, 
        [Name] NVARCHAR(12) NOT NULL,
        CONSTRAINT [CK_Game_Choise_Name_Length] CHECK (LEN(Name) <= 12)
    )
END;
IF NOT EXISTS (SELECT 0 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'Game' 
           AND TABLE_NAME = 'Player')
BEGIN
    CREATE TABLE [Game].[Player]
    (
	    [ID] INT NOT NULL PRIMARY KEY IDENTITY, 
        [Name] NVARCHAR(12) NOT NULL,
        CONSTRAINT [CK_Game_Player_Name_Length] CHECK (LEN(Name) <= 12)
    )
END;
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

-- ___________                   __  .__                      
-- \_   _____/_ __  ____   _____/  |_|__| ____   ____   ______
--  |    __)|  |  \/    \_/ ___\   __\  |/  _ \ /    \ /  ___/
--  |     \ |  |  /   |  \  \___|  | |  (  <_> )   |  \\___ \ 
--  \___  / |____/|___|  /\___  >__| |__|\____/|___|  /____  >
--      \/             \/     \/                    \/     \/ 



-- __________                                .___                           
-- \______   \_______  ____   ____  ____   __| _/_ _________   ____   ______
--  |     ___/\_  __ \/  _ \_/ ___\/ __ \ / __ |  |  \_  __ \_/ __ \ /  ___/
--  |    |     |  | \(  <_> )  \__\  ___// /_/ |  |  /|  | \/\  ___/ \___ \ 
--  |____|     |__|   \____/ \___  >___  >____ |____/ |__|    \___  >____  >
--                               \/    \/     \/                  \/     \/ 


-- ____   ____.__                     
-- \   \ /   /|__| ______  _  ________
--  \   Y   / |  |/ __ \ \/ \/ /  ___/
--   \     /  |  \  ___/\     /\___ \ 
--    \___/   |__|\___  >\/\_//____  >
--                    \/           \/ 



-- ________          __          
-- \______ \ _____ _/  |______   
--  |    |  \\__  \\   __\__  \  
--  |    `   \/ __ \|  |  / __ \_
-- /_______  (____  /__| (____  /
--         \/     \/          \/ 
MERGE INTO [Game].[Choise] AS TARGET
USING (
		  VALUES 
		  (1,'rock'), 
		  (2,'paper'),
		  (3,'scissors'),
		  (4,'lizard'),
		  (5,'spock')
	  ) AS SOURCE ([ID],[Name])
ON TARGET.[ID] = SOURCE.[ID]

WHEN NOT MATCHED 
THEN
    INSERT ([ID],[Name]) VALUES (SOURCE.[ID], SOURCE.[Name])

WHEN NOT MATCHED BY SOURCE
THEN DELETE;

MERGE INTO [Game].[GameResult] AS TARGET
USING (
		  VALUES 
		  (1,'win'), 
		  (2,'lose'),
		  (3,'tie')
	  ) AS SOURCE ([ID],[Name])
ON TARGET.[ID] = SOURCE.[ID]

WHEN NOT MATCHED 
THEN
    INSERT ([ID],[Name]) VALUES (SOURCE.[ID], SOURCE.[Name])

WHEN NOT MATCHED BY SOURCE
THEN DELETE;

MERGE INTO [Game].[Player] AS TARGET
USING (
		  VALUES 
		  ('player1'), 
		  ('player2'),
		  ('computer')
	  ) AS SOURCE ([Name])
ON TARGET.[Name] = SOURCE.[Name]

WHEN NOT MATCHED 
THEN
    INSERT ([Name]) VALUES (SOURCE.[Name])

WHEN NOT MATCHED BY SOURCE
THEN DELETE;


--    _____                 __    
--   /     \   ____   ____ |  | __
--  /  \ /  \ /  _ \_/ ___\|  |/ /
-- /    Y    (  <_> )  \___|    < 
-- \____|__  /\____/ \___  >__|_ \
--         \/            \/     \/

GO

COMMIT TRAN
GO

GO
PRINT N'Update complete.';


GO
