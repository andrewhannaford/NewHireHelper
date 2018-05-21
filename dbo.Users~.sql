CREATE TABLE [dbo].[Users]
(
    [userID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [emailAddress] NCHAR(50) NULL, 
    [name] NCHAR(50) NULL, 
    [title] NCHAR(50) NULL
)
