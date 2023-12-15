Create DATABASE Trivia
Go

USE Trivia
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

Create TABLE userDB (
[UserId] INT IDENTITY (1, 1) NOT NULL,
[UserMail] NVARCHAR(30) NOT NULL Unique,
[UserName] NCHAR (20) NOT NULL,
[UserRankID] INT NOT NULL,
[Score] INT NOT NULL,
[Password] NVARCHAR (20) NOT NULL,
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

INSERT INTO [subjectDB]
([SubjectID], [Subject]) VALUES
(1, 'Sport')
INSERT INTO [subjectDB]
([SubjectID], [Subject]) VALUES
(2, 'Politics')
INSERT INTO [subjectDB]
([SubjectID], [Subject]) VALUES
(3, 'History')
INSERT INTO [subjectDB]
([SubjectID], [Subject]) VALUES
(4, 'Science')
INSERT INTO [subjectDB]
([SubjectID], [Subject]) VALUES
(5, 'Ramon Highschool')
INSERT INTO [subjectDB]
([SubjectID], [Subject]) VALUES
(6, 'Invalid')
Go

INSERT INTO [userRankDB]
([UserRankID], [RankName]) VALUES
(1, 'Manager')
INSERT INTO [userRankDB]
([UserRankID], [RankName]) VALUES
(2, 'Master')
INSERT INTO [userRankDB]
([UserRankID], [RankName]) VALUES
(3, 'Rookie')
Go

INSERT INTO [questionStatusDB]
([QuestionStatusID], [Status]) VALUES
(1, 'Pending')
INSERT INTO [questionStatusDB]
([QuestionStatusID], [Status]) VALUES
(2, 'Accpted')
INSERT INTO [questionStatusDB]
([QuestionStatusID], [Status]) VALUES
(3, 'Not Accpted')
Go

INSERT INTO [userDB] ([UserMail], [UserName], [UserRankID], [Score], [Password]) VALUES 
            ('amitayzic12@gmail.com', 'amitayTHEKING ', 1, 5, 'Amitay1');

INSERT INTO [userDB] ([UserMail], [UserName], [UserRankID], [Score],[Password]) VALUES 
            ('sagidrori@gmail.com', ' sagiTHEKING ', 2, 5, 'Sagi1');

INSERT INTO [userDB] ([UserMail], [UserName], [UserRankID], [Score],[Password]) VALUES 
            ('roeydayan@gmail.com', ' RoeyTHEKING ', 2, 5, 'Dayan1');

INSERT INTO [userDB] ([UserMail], [UserName], [UserRankID], [Score],[Password]) VALUES 
            ('amithacham@gmail.com', ' amitTHEKING ', 1, 5, 'Amit1');
INSERT INTO [userDB] ([UserMail], [UserName], [UserRankID], [Score],[Password]) VALUES 
            ('a@a.com', ' a ', 1, 5, 'aa');
Go


INSERT INTO [questionsDB] 
([QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(1, 1,3, 'When was Israel establish? ', '1948', '1946','1776','1952');
INSERT INTO [questionsDB] ([QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(2, 2, 1, 'Who won the 2022 FIFA World Cup', 'Argentina', 'France','Algeria','Portugal');
INSERT INTO [questionsDB] ([QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(2, 3,4, 'What kills you first in the vaccum of space', 'Lack of oxygen', 'The cold','Your blood boiling','Radiation');
INSERT INTO [questionsDB] ([QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(3, 4,5, 'Who is the principal', 'Hannah Daldi-Mandingo', 'Raheli Lizerovitz','Alex Leorian','Smadar Vechter');
Go


select * from userDB

select * from questionsDB

select * from questionStatusDB