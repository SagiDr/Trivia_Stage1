Create DATABASE Trivia
Go

USE Trivia
Go

Create TABLE userDB (
[UserId] INT IDENTITY (1, 1) NOT NULL,
[UserMail] NVARCHAR(30) NOT NULL Unique,
[UserName] NCHAR (20) NOT NULL,
[UserRankID] INT,
[Score] int,
Primary Key ([USerID])
CONSTRAINT [PK_userDB] PRIMARY KEY CLUSTERED ([UserId] ASC),

);
Go

Create TABLE QuestDB (


);
Go

Create TABLE SubjectDB (


);
Go

Create TABLE UserRankDB (


);
Go

Create TABLE QuestionStatusDB (

);
Go