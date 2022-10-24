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
