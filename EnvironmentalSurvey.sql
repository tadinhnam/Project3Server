USE master
GO

DROP DATABASE IF EXISTS EnvironmentalSurvey
CREATE DATABASE EnvironmentalSurvey
GO

USE EnvironmentalSurvey
GO

CREATE TABLE Account(
Id INT IDENTITY PRIMARY KEY,
UserName NVARCHAR(50),
[Password] NVARCHAR(250),
IdPeople NVARCHAR(250),
Class NVARCHAR(50),
[Date] DATE,
[Role] NVARCHAR(50),
[Status] BIT
)
GO

CREATE TABLE Survey(
Id INT IDENTITY PRIMARY KEY,
[NAME] NVARCHAR(50),
[Description] NVARCHAR(500),
Updated DATE,
[Status] BIT
)
GO

CREATE TABLE Question(
Id INT IDENTITY PRIMARY KEY,
Question NVARCHAR(250),
Updated DATE,
[Status] BIT
)
GO

CREATE TABLE QuestionSurvey
(
IdQuestion INT CONSTRAINT FK_QS_Question FOREIGN KEY(IdQuestion) REFERENCES Question(Id),
IdSurvey INT CONSTRAINT FK_QS_Survey FOREIGN KEY(IdSurvey) REFERENCES Survey(Id),
Updated DATE,
[Status] BIT,
PRIMARY KEY(IdQuestion,IdSurvey)
)
GO

CREATE TABLE Answer(
Id INT IDENTITY PRIMARY KEY,
IdQuestion INT CONSTRAINT FK_Answer_Question FOREIGN KEY(IdQuestion) REFERENCES Question(Id),
Answer NVARCHAR(250),
Updated DATE,
[Status] BIT
)
GO



CREATE TABLE Score(
IdAcc INT CONSTRAINT FK_Score_Account FOREIGN KEY(IdAcc) REFERENCES Account(Id),
IdSurvey INT CONSTRAINT FK_Score_Survey FOREIGN KEY(IdSurvey) REFERENCES Survey(Id),
Score INT,
[Status] BIT,
PRIMARY KEY(IdAcc, IdSurvey)
)
GO

CREATE TABLE AllPeople(
IdPerson NVARCHAR(250) PRIMARY KEY,
[NAME] NVARCHAR(100),
Img NVARCHAR(250),
DOB DATE,
Gender BIT,
Position NVARCHAR(50),
Class NVARCHAR(50)
)
GO

CREATE TABLE Topic(
Id INT IDENTITY PRIMARY KEY,
Topic NVARCHAR(50),
[Status] BIT
)
GO
CREATE TABLE Seminar(
Id INT IDENTITY PRIMARY KEY,
IdTopic INT CONSTRAINT FK_Seminar_Topic FOREIGN KEY(IdTopic) REFERENCES Topic(Id),
Img NVARCHAR(250),
[Name] NVARCHAR(250),
Presenters NVARCHAR(250) CONSTRAINT FK_Seminar_AllPeople FOREIGN KEY(Presenters) REFERENCES AllPeople(IdPerson),
TimeStart TIME,
TimeEnd TIME,
[Day] DATE,
Place NVARCHAR(50),
Maximum INT,
NumberOfParticipants INT,
[Descriptoin] NVARCHAR(500),
[Status] BIT
)
GO

CREATE TABLE Img(
Id INT IDENTITY PRIMARY KEY,
[Path] NVARCHAR(250),
IdSeminar INT CONSTRAINT FK_Img_Serminar FOREIGN KEY(IdSeminar) REFERENCES Seminar(Id)
)
GO

CREATE TABLE Performer(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(100),
Gender BIT,
DOB DATE,
Img NVARCHAR(250),
[Status] BIT
)
GO

CREATE TABLE RegisterSeminar(
IdAcc INT CONSTRAINT FK_RegisterSeminar_Account FOREIGN KEY(IdAcc) REFERENCES Account(Id),
IdSeminar INT CONSTRAINT FK_RegisterSeminar_Seminar FOREIGN KEY(IdSeminar) REFERENCES Seminar(Id),
[Status] BIT
PRIMARY KEY(IdAcc, IdSeminar)
)
GO
CREATE TABLE PerformenSeminar(
IdPerforment INT CONSTRAINT FK_PerformenSeminar_Performer FOREIGN KEY(IdPerforment) REFERENCES Performer(Id),
IdSeminar INT CONSTRAINT FK_PerformenSeminar_Seminar FOREIGN KEY(IdSeminar) REFERENCES Seminar(Id),
[Status] BIT,
PRIMARY KEY (IdPerforment, IdSeminar)
)
GO

INSERT INTO Account
VALUES('account1','123','people1', 'class1', '2021-12-20','sv',1),
('account2','123','people2', 'class1', '2021-12-20','sv',1),
('account3','123','people3', 'class1', '2021-12-20','gv',1),
('account4','123','people4', 'class1', '2021-12-20','sv',0);
GO

INSERT INTO Topic
VALUES('Topic1',1),
('Topic3',1),
('Topic2',1),
('Topic4',1);
GO

INSERT INTO AllPeople
VALUES ('people1', 'TL1', 'img','2000-06-29',1,'sv','class1'),
('people2', 'TL2', 'img','2000-06-29',1,'nv',null),
('people3', 'TL3', 'img','2000-06-29',1,'gv',null),
('people4', 'TL4', 'img','2000-06-29',1,'sv','class1');
GO

INSERT INTO Seminar
VALUES (1,'img','seminar 1','people1', '08:00:00', '09:00:00','2021-06-06','HCM',100,50,'seminar 1',1),
(1,'img','seminar 1','people2', '08:00:00', '09:00:00','2021-07-06','HCM',100,50,'seminar 1',1),
(1,'img','seminar 1','people1', '08:00:00', '09:00:00','2021-05-06','HCM',100,50,'seminar 1',1),
(1,'img','seminar 1','people3', '08:00:00', '09:00:00','2021-06-06','HCM',100,50,'seminar 1',0),
(1,'img','seminar 1','people1', '08:00:00', '09:00:00','2021-06-11','HCM',100,50,'seminar 1',1);
GO
