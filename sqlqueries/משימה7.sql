SELECT fname, lname, Id FROM [dbo].[UserDatabase] 
WHERE (gender = 'Male' AND DATEDIFF(YEAR, date, GETDATE()) > 30)
OR (gender = 'Female' AND DATEDIFF(YEAR, date, GETDATE()) < 20)
ORDER BY date DESC;