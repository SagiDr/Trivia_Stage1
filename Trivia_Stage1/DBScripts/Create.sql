Create DATABASE Trivia
Go

USE Trivia
Go

Create TABLE userDB (
[UserId] INT IDENTITY (1, 1) NOT NULL,
[UserMail] NVARCHAR(30) NOT NULL Unique,
[UserName] NCHAR (20) NOT NULL,
[UserRankID] INT NOT NULL,
[Score] INT NOT NULL,
Primary Key ([USerID]),
FOREIGN KEY ([UserRankID]) REFERENCES userRankDB([UserRankID])

);
Go

Create TABLE questionsDB (
[QuestionID] INT Identity(1,1) NOT NULL,
[QuestionStatusID] INT NOT NULL,
[USerID] int NOT NULL,
[SubjectID] int NOT NULL,
[Text] NVARCHAR(200) NOT NULL,
[CorrectAns] NVARCHAR(200) NOT NULL,
[WrongAns1] NVARCHAR(200) NOT NULL,
[WrongAns2] NVARCHAR(200) NOT NULL,
[WrongAns3] NVARCHAR(200) NOT NULL,

PRIMARY KEY ([QuestionID]),
FOREIGN KEY ([QuestionStatusID]) REFERENCES questionStatusDB([QuestionStatusID]),
FOREIGN KEY ([USerID]) REFERENCES userDB([UserId]),
FOREIGN KEY ([SubjectID]) REFERENCES subjectDB([SubjectID]),
);
Go

Create TABLE subjectDB (
[SubjectID] int NOT NULL,
[Subject] NVARCHAR(20) NOT NULL
PRIMARY KEY ([SubjectID])
);
Go

Create TABLE userRankDB (
[UserRankID] INT NOT NULL,
[RankName] NVARCHAR(20) NOT NULL
PRIMARY KEY ([UserRankID])
);
Go

Create TABLE questionStatusDB (
[QuestionStatusID] INT NOT NULL,
[Status] NVARCHAR(20) NOT NULL,
PRIMARY KEY ([QuestionStatusID])
);
Go