CREATE TABLE Students (
	Id varchar(450) PRIMARY KEY NOT NULL,
	Name TEXT NOT NULL,
	Email TEXT NOT NULL,
	DateOfBirth timestamp NOT NULL,
	ContactNumber varchar(10) NOT NULL,
	Age INT NOT NULL,
	FathersName varchar(50) NOT NULL,
	MothersName varchar(50) NOT NULL,
	Address TEXT NOT NULL,
	Username varchar(50) NOT NULL
);