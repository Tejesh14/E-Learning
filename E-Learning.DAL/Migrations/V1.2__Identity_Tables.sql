CREATE TABLE AspNetRoles (
	Id VARCHAR(450) PRIMARY KEY NOT NULL,
	Name VARCHAR(256),
	NormalizedName VARCHAR(256),
	ConcurrencyStamp TEXT
);

CREATE TABLE AspNetUsers (
	Id VARCHAR(450) PRIMARY KEY NOT NULL,
	UserName VARCHAR(256),
	NormalizedUserName VARCHAR(256),
	Email VARCHAR(256),
	NormalizedEmail VARCHAR(256),
	EmailConfirmed BOOLEAN,
	PasswordHash TEXT,
	SecurityStamp TEXT,
	ConcurrencyStamp TEXT,
	PhoneNumber TEXT,
	PhoneNumberConfirmed BOOLEAN,
	TwoFactorEnabled BOOLEAN,
	LockoutEnd TIMESTAMPTZ,
	LockoutEnabled BOOLEAN,
	AccessFailedCount INT
);

CREATE TABLE AspNetRoleClaims (
	Id SERIAL NOT NULL PRIMARY KEY,
	RoleId VARCHAR(450) NOT NULL,
	ClaimType TEXT,
	ClaimValue TEXT,
	CONSTRAINT fk_AspNetRoleClaims_AspNetRoles FOREIGN KEY(RoleId) REFERENCES AspNetRoles(Id)
);

CREATE TABLE AspNetUserClaims (
	Id SERIAL NOT NULL PRIMARY KEY,
	UserId VARCHAR(450) NOT NULL,
	ClaimType TEXT,
	ClaimValue TEXT,
	CONSTRAINT fk_AspNetUserClaims_AspNetUsers FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id)
);

CREATE TABLE AspNetUserLogins (
	LoginProvider VARCHAR(450) NOT NULL,
	ProviderKey VARCHAR(450) NOT NULL,
	ProviderDisplayName TEXT,
	UserId VARCHAR(450) NOT NULL,
	CONSTRAINT pk_AspNetUserLogins PRIMARY KEY(LoginProvider, ProviderKey),
	CONSTRAINT fk_AspNetUserLogins_AspNetUsers FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id)
);

CREATE TABLE AspNetUserRoles (
	UserId VARCHAR(450) NOT NULL,
	RoleId VARCHAR(450) NOT NULL,
	CONSTRAINT pk_AspNetUserRoles PRIMARY KEY(UserId, RoleId),
	CONSTRAINT fk_AspNetUserRoles_AspNetRoles FOREIGN KEY(RoleId) REFERENCES AspNetRoles(Id),
	CONSTRAINT fk_AspNetUserRoles_AspNetUsers FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id)
);

CREATE TABLE AspNetUserTokens (
	UserId VARCHAR(450) NOT NULL,
	LoginProvider VARCHAR(450) NOT NULL,
	Name VARCHAR(450) NOT NULL,
	Value TEXT NOT NULL,
	CONSTRAINT pk_AspNetUserTokens PRIMARY KEY(UserId, LoginProvider, Name),
	CONSTRAINT fk_AspNetUserTokens_AspNetUsers FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id)
);