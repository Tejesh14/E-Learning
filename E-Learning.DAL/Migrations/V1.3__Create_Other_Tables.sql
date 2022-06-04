CREATE TABLE CHATS (
	Id VARCHAR(450) PRIMARY KEY  NOT NULL,
	SendFrom TEXT,
	SendTo TEXT,
	Message TEXT,
	SendAt TIMESTAMP NOT NULL
);

CREATE TABLE FACULTIES (
	Id varchar(450) PRIMARY KEY NOT NULL,
	Name TEXT NOT NULL,
	Email TEXT NOT NULL,
	DateOfBirth timestamp NOT NULL,
	ContactNumber varchar(10) NOT NULL,
	Age INT NOT NULL,
	FathersName varchar(50) NOT NULL,
	MothersName varchar(50) NOT NULL,
	Address TEXT NOT NULL,
	Username varchar(50) NOT NULL,
	Subject VARCHAR(450) NOT NULL
);

CREATE TABLE PROJECTS (
	Id varchar(450) PRIMARY KEY NOT NULL,
	ProjectName TEXT NOT NULL,
	FileNameAssigned TEXT NOT NULL,
	FileTypeAssigned TEXT NOT NULL,
	AssignBy varchar(50) NOT NULL,
	AssignedAt TIMESTAMP NOT NULL,
	FileNameSubmitted TEXT,
	FileTypeSubmitted TEXT,
	SubmittedAt TIMESTAMP,
	AssignTo varchar(50) NOT NULL
);

CREATE TABLE RESOURCES (
	Id varchar(450) PRIMARY KEY NOT NULL,
	Heading TEXT NOT NULL,
	Body TEXT NOT NULL,
	Time TIMESTAMP NOT NULL
);

CREATE TABLE CALENDARS (
	Id varchar(450) PRIMARY KEY NOT NULL,
	Event TEXT NOT NULL,
	Date TIMESTAMP NOT NULL,
	LoggedUser VARCHAR(50) NOT NULL
);