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
