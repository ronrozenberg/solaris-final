SELECT COUNT(*) AS UsersOver18 FROM [dbo].[UserDatabase] 
WHERE DATEDIFF(YEAR, date, GETDATE()) > 18;