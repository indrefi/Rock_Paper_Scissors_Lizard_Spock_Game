﻿
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

:r .\Schemas\Game.sql

-- ___________     ___.   .__                 
-- \__    ___/____ \_ |__ |  |   ____   ______
--   |    |  \__  \ | __ \|  | _/ __ \ /  ___/
--   |    |   / __ \| \_\ \  |_\  ___/ \___ \ 
--   |____|  (____  /___  /____/\___  >____  >
--                \/    \/          \/     \/ 

-- ORDER IS IMPORTANT
:r .\Tables\Choise.sql
:r .\Tables\Player.sql
:r .\Tables\GameResult.sql

:r .\Tables\Scoreboard.sql

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
:r .\Data\SeedChoise.sql
:r .\Data\SeedGameResult.sql
:r .\Data\SeedPlayer.sql

--    _____                 __    
--   /     \   ____   ____ |  | __
--  /  \ /  \ /  _ \_/ ___\|  |/ /
-- /    Y    (  <_> )  \___|    < 
-- \____|__  /\____/ \___  >__|_ \
--         \/            \/     \/

GO

COMMIT TRAN
