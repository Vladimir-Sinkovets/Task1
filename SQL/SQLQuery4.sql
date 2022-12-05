USE [TestTask]
GO

CREATE PROCEDURE Task_1 AS SELECT SUM(CAST(IntegerNumber AS bigint))
	FROM [dbo].[Entries]
UNION
SELECT PERCENTILE_CONT(0.5)
	WITHIN GROUP (ORDER BY	FractionalNumber)
	OVER ()
	FROM [dbo].[Entries]
GO