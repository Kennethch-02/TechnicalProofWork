-- -----------------------------------------------------
-- Table catalog_UserType
-- -----------------------------------------------------
CREATE TABLE catalog_UserType (
  Id INT NOT NULL IDENTITY(1,1),
  Detail VARCHAR(100) NOT NULL,
  [Date] DATETIME NOT NULL DEFAULT GETDATE(),
  UpdateDate DATETIME NOT NULL DEFAULT GETDATE(),
  [State] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (Id),
  UNIQUE (Detail)
);
-- -----------------------------------------------------
-- Table Person
-- -----------------------------------------------------
CREATE TABLE catalog_IdType (
  Id INT NOT NULL IDENTITY(1,1),
  Detail VARCHAR(100) NOT NULL,
  [Date] DATETIME NOT NULL DEFAULT GETDATE(),
  UpdateDate DATETIME NOT NULL DEFAULT GETDATE(),
  [State] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (Id),
  UNIQUE (Detail)
);

CREATE TABLE Person (
  Id VARCHAR(50) NOT NULL,
  IdType_Id INT NOT NULL,
  [Name] VARCHAR(45) NOT NULL,
  FirstLastName VARCHAR(45) NOT NULL,
  SecondLastName VARCHAR(45) NOT NULL,
  PRIMARY KEY (Id),
FOREIGN KEY (IdType_Id) REFERENCES catalog_IdType (Id)
);

-- -----------------------------------------------------
-- Table User
-- -----------------------------------------------------
CREATE TABLE [User] (
  [Name] NVARCHAR(150) NOT NULL,
  [Password] NVARCHAR(150) NOT NULL,
  UserType_Id INT NOT NULL,
  Person_Id VARCHAR(50) NOT NULL,
  [Date] DATETIME NOT NULL DEFAULT GETDATE(),
  UpdateDate DATETIME NOT NULL DEFAULT GETDATE(),
  [State] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY ([Name]),
  FOREIGN KEY (UserType_Id) REFERENCES catalog_UserType (Id),
  FOREIGN KEY (Person_Id) REFERENCES Person (Id)
);

-- -----------------------------------------------------
-- Table catalog_SoftSkills
-- -----------------------------------------------------
CREATE TABLE catalog_SoftSkills (
  Id INT NOT NULL IDENTITY(1,1),
  Detail VARCHAR(100) NOT NULL,
  [Date] DATETIME NOT NULL DEFAULT GETDATE(),
  UpdateDate DATETIME NOT NULL DEFAULT GETDATE(),
  [State] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (Id),
  UNIQUE (Detail) 
);

-- -----------------------------------------------------
-- Table catalog_RegexType
-- -----------------------------------------------------
CREATE TABLE catalog_RegexType (
  Id INT NOT NULL IDENTITY(1,1),
  Detail VARCHAR(100) NOT NULL,
  Regex VARCHAR(200) NOT NULL,
  [Date] DATETIME NOT NULL DEFAULT GETDATE(),
  UpdateDate DATETIME NOT NULL DEFAULT GETDATE(),
  [State] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (Id),
  UNIQUE (Detail)
);

-- -----------------------------------------------------
-- Table catalog_ContactType
-- -----------------------------------------------------
CREATE TABLE catalog_ContactType (
  Id INT NOT NULL IDENTITY(1,1),
  RegexType_Id INT NOT NULL,
  Detail VARCHAR(100) NOT NULL,
  [Date] DATETIME NOT NULL DEFAULT GETDATE(),
  UpdateDate DATETIME NOT NULL DEFAULT GETDATE(),
  [State] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (Id),
  UNIQUE (Detail),
  FOREIGN KEY (RegexType_Id) REFERENCES catalog_RegexType (Id)
);

-- -----------------------------------------------------
-- Table Contact
-- -----------------------------------------------------
CREATE TABLE Contact (
  Data VARCHAR(300) NOT NULL,
  Person_Id VARCHAR(50) NOT NULL,
  [Date] DATETIME NOT NULL DEFAULT GETDATE(),
  UpdateDate DATETIME NOT NULL DEFAULT GETDATE(),  
  [State] BIT NOT NULL DEFAULT 1,
  ContactType_Id INT NOT NULL,
  PRIMARY KEY (Data, Person_Id),
  FOREIGN KEY (Person_Id) REFERENCES Person (Id),
  FOREIGN KEY (ContactType_Id) REFERENCES catalog_ContactType (Id)
);
GO
-- -----------------------------------------------------
-- Table User_has_SoftSkills
-- -----------------------------------------------------
CREATE TABLE User_has_SoftSkills (
  User_Name NVARCHAR(150) NOT NULL,
  SoftSkills_Id INT NOT NULL,
  [State] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (User_Name, SoftSkills_Id),
  FOREIGN KEY (User_Name) REFERENCES [User]([Name]),
  FOREIGN KEY (SoftSkills_Id) REFERENCES catalog_SoftSkills (Id)
);
GO
-- Views
-- Inserts
INSERT INTO catalog_RegexType (Detail, Regex) VALUES ('Email', '^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$'), ('Phone', '^\d{8}$');
INSERT INTO catalog_UserType (Detail) VALUES ('Admin'), ('Consultant');
INSERT INTO catalog_IdType (Detail) VALUES ('National'), ('International');
INSERT INTO catalog_SoftSkills (Detail) VALUES ('Teamwork'), ('Leadership'), ('Problem Solving'), ('Communication'), ('Adaptability'), ('Work Ethic'), ('Time Management'), ('Critical Thinking'), ('Conflict Resolution'), ('Creativity');
INSERT INTO catalog_ContactType (RegexType_Id, Detail) VALUES (1, 'Email'), (2, 'Phone');
INSERT INTO Person (Id, IdType_Id, [Name], FirstLastName, SecondLastName) VALUES ('12345678', 1, 'Juan', 'Perez', 'Gonzalez');
INSERT INTO Person (Id, IdType_Id, [Name], FirstLastName, SecondLastName) VALUES ('KJA5485564', 2, 'Rostock', 'Ola', 'Li');
INSERT INTO [User] ([Name], [Password], UserType_Id, Person_Id) VALUES ('Admin', 'Admin', 1, '12345678');
INSERT INTO [User] ([Name], [Password], UserType_Id, Person_Id) VALUES ('notAdmin', 'notAdmin', 2, 'KJA5485564');
INSERT INTO Contact ([Data], Person_Id, ContactType_Id) VALUES ('12345678', '12345678', 2);
INSERT INTO Contact ([Data], Person_Id, ContactType_Id) VALUES ('test@gmail.com', '12345678', 1);
INSERT INTO Contact ([Data], Person_Id, ContactType_Id) VALUES ('88888888', 'KJA5485564', 2);
INSERT INTO Contact ([Data], Person_Id, ContactType_Id) VALUES ('prueba@gmail.com', 'KJA5485564', 1);
INSERT INTO User_has_SoftSkills (User_Name, SoftSkills_Id) VALUES ('Admin', 1), ('Admin', 2), ('Admin', 3), ('Admin', 4);
INSERT INTO User_has_SoftSkills (User_Name, SoftSkills_Id) VALUES ('notAdmin', 5), ('notAdmin', 6), ('notAdmin', 7);
GO
