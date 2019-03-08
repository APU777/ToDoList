 CREATE TABLE Account
(
	Id INT IDENTITY PRIMARY KEY,
	"Login" NVARCHAR(100) NOT NULL,
	"Password" NVARCHAR(100) NOT NULL
);

CREATE TABLE Category
(
	Id INT IDENTITY PRIMARY KEY,
	"Name" NVARCHAR(100) NOT NULL,
);

CREATE TABLE "Priority"
(
	Id INT IDENTITY PRIMARY KEY,
	"Name" NVARCHAR(10) NOT NULL
);

CREATE TABLE Task
(
	Id INT IDENTITY PRIMARY KEY,
	"Name" NVARCHAR(100) NOT NULL,
	Objective NTEXT NOT NULL,
	StartDate NVARCHAR(20) NOT NULL,
	EndDate NVARCHAR(20) NOT NULL,
	IdAccount INT NOT NULL
	FOREIGN KEY (IdAccount) REFERENCES Account (Id) ON DELETE CASCADE,
	IdCategory INT NOT NULL
	FOREIGN KEY (IdCategory) REFERENCES Category (Id) ON DELETE CASCADE,
	IdPriority INT NOT NULL
	FOREIGN KEY (IdPriority) REFERENCES "Priority" (Id) ON DELETE CASCADE 
);


INSERT INTO Category
	("Name")
VALUES
	('Study'),
	('Work'),
	('Home'),
	('Hobby'),
	('Holiday'),
	('Weekend'),
	('Free Time')

INSERT INTO "Priority"
	("Name")
VALUES
	('Low'),
	('Normal'),
	('High')



