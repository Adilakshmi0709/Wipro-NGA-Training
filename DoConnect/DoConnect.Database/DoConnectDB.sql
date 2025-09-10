-- Create Database
CREATE DATABASE DoConnectDB;
GO

USE DoConnectDB;
GO

-- ==============================
-- Users Table
-- ==============================
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Unique Constraints
CREATE UNIQUE INDEX IX_Users_Email ON Users(Email);
CREATE UNIQUE INDEX IX_Users_Username ON Users(Username);

-- ==============================
-- Questions Table
-- ==============================
CREATE TABLE Questions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Body NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UserId INT NOT NULL,

    CONSTRAINT FK_Questions_Users FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE RESTRICT
);

-- ==============================
-- Answers Table
-- ==============================
CREATE TABLE Answers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Body NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UserId INT NOT NULL,
    QuestionId INT NOT NULL,

    CONSTRAINT FK_Answers_Users FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE RESTRICT,

    CONSTRAINT FK_Answers_Questions FOREIGN KEY (QuestionId)
        REFERENCES Questions(Id)
        ON DELETE CASCADE
);

-- ==============================
-- Images Table
-- ==============================
CREATE TABLE Images (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Url NVARCHAR(500) NOT NULL,
    QuestionId INT NULL,
    AnswerId INT NULL,

    CONSTRAINT FK_Images_Questions FOREIGN KEY (QuestionId)
        REFERENCES Questions(Id)
        ON DELETE RESTRICT,

    CONSTRAINT FK_Images_Answers FOREIGN KEY (AnswerId)
        REFERENCES Answers(Id)
        ON DELETE RESTRICT
);
