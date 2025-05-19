UPDATE [dbo].[UserDatabase] 
SET fname = fname + '_Minor' 
WHERE DATEDIFF(YEAR, date, GETDATE()) < 18;