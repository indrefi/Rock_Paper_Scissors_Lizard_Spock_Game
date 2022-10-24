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
