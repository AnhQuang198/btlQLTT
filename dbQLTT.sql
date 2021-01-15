CREATE DATABASE QLTT

USE QLTT

CREATE TABLE tblUser (
    id INT PRIMARY KEY IDENTITY (1, 1),
    username VARCHAR (50) UNIQUE NOT NULL,
    password VARCHAR (50) NOT NULL,
    role VARCHAR(20),
    status BIT
);

CREATE TABLE tblStudent (
	id INT PRIMARY KEY IDENTITY (1, 1),
	svCode VARCHAR (50) NOT NULL,
	name VARCHAR (50) NOT NULL,
	userId INT NOT NULL,
	FOREIGN KEY (userId) REFERENCES tblUser (id)
);

CREATE TABLE tblClass (
    id INT PRIMARY KEY IDENTITY (1, 1),
    name VARCHAR (50) NOT NULL,
    timeline DATETIME,
    svRegMax INT NOT NULL,
    svRegMin INT NOT NULL,
    svJoined INT DEFAULT 0,
    gvName VARCHAR (50) NOT NULL
);

CREATE TABLE tblClassStudent (
    id INT PRIMARY KEY IDENTITY (1, 1),
    studentId INT NOT NULL,
    classId INT NOT NULL,
    FOREIGN KEY (studentId) REFERENCES tblStudent (id),
    FOREIGN KEY (classId) REFERENCES tblClass (id)
);

CREATE TABLE tblTeacher (
	id INT PRIMARY KEY IDENTITY (1, 1),
	name VARCHAR (50) NOT NULL,
	userId INT NOT NULL,
	FOREIGN KEY (userId) REFERENCES tblUser (id)
);


CREATE PROCEDURE sp_register
	@username VARCHAR(50),
	@password VARCHAR (50),
    @role VARCHAR(20),
    @status BIT,
    @name VARCHAR(50),
    @svCode VARCHAR(50)
AS
BEGIN
	DECLARE @Count INT
	DECLARE @ReturnCode INT
	
	SELECT @Count = COUNT(username) 
	FROM tblUser WHERE username = @username 
	IF @Count > 0
	BEGIN
		SET @ReturnCode = -1
	END
	ELSE
	BEGIN
		SET @ReturnCode = 1
		INSERT INTO tblUser(username, password, role, status) VALUES (@username, @password, @role, @status)
		INSERT INTO tblStudent(svCode, name, userId) VALUES (@svCode, @name, SCOPE_IDENTITY())
	END
	SELECT @ReturnCode as ReturnValue
END
GO

--exec sp_register 'quang123456', '123456', 'USER', true, 'quang', '16A10010256'

CREATE PROCEDURE sp_login
	@username VARCHAR(50),
	@password VARCHAR(50)
AS
	SELECT role FROM tblUser WHERE username = @username AND password = @password;
GO

--exec sp_login 'quang123', '123456'

CREATE VIEW view_class
AS
	SELECT name AS 'Tên lớp', gvName AS 'Giảng viên', svRegMin AS 'Tối thiểu', svRegMax AS 'Tối đa', svJoined AS 'Đã đăng ký', timeline AS 'Lịch học'
FROM tblClass