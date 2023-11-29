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






INSERT INTO [userDB] ([UserId], [UserMail], [UserName], [UserRankID], [Score]) VALUES (111111111,'amitayzic12@gmail.com', ' amitayTHEKING ', 0, 5);
INSERT INTO [userDB] ([UserId], [UserMail], [UserName], [UserRankID], [Score]) VALUES 
(222222222,' sagidrori@gmail.com', ' sagiTHEKING ', 1, 5);
INSERT INTO [userDB] ([UserId], [UserMail], [UserName], [UserRankID], [Score]) VALUES 
(333333333, 'roeydayan@gmail.com', ' RoeyTHEKING ', 2, 5);
INSERT INTO [userDB] ([UserId], [UserMail], [UserName], [UserRankID], [Score]) VALUES 
(444444444, 'amithacham@gmail.com', ' amitTHEKING ', 1, 5);






INSERT INTO [questionsDB] 
([QuestionID], [QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(1111, 'pending', 444444444,' History ', 'When was Israel establish? ', '1948', '1946','1776','1952');
INSERT INTO [questionsDB] ([QuestionID], [QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(2222, 'pending', 333333333,' math ', "what is a Ln? ", "A log with a e base", "monkey","modolo","a log with a 2 base");
INSERT INTO [questionsDB] ([QuestionID], [QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(3333, 'Accepted', 111111111,' History ', "When was America establish? ", 1776, 1946,1774,1952);
INSERT INTO [questionsDB] ([QuestionID], [QuestionStatusID], [UserID], [SubjectID], [Text], [CorrectAns],[WrongAns1],[WrongAns2],[WrongAns3]) VALUES 
(4444, Rejected, 222222222,' Politics ', "How many years is Bibi the prime minister of IsRAEL?  ", 16, 15,14,20);




