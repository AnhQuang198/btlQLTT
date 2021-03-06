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

ALTER TABLE tblClassStudent
ADD CONSTRAINT fk_contrain_delete_class
 FOREIGN KEY (classId)
 REFERENCES tblClass (id)
ON DELETE CASCADE;

CREATE TABLE tblTeacher (
	id INT PRIMARY KEY IDENTITY (1, 1),
	name VARCHAR (50) NOT NULL,
	userId INT NOT NULL,
	FOREIGN KEY (userId) REFERENCES tblUser (id)
);

CREATE TABLE tblCompany (
	id INT PRIMARY KEY IDENTITY (1, 1),
	name VARCHAR (50) NOT NULL,
	phone VARCHAR (20) NOT NULL,
	address VARCHAR (50) NOT NULL,
	teacherId INT NOT NULL,
	FOREIGN KEY (teacherId) REFERENCES tblTeacher (id)
);

CREATE TABLE tblStudentCompany (
	id INT PRIMARY KEY IDENTITY (1, 1),
	studentId INT NOT NULL,
	companyId INT NOT NULL,
	timeStart DATETIME,
	timeEnd DATETIME,
	position VARCHAR(50),
	specialized VARCHAR(50),
	FOREIGN KEY (studentId) REFERENCES tblStudent (id),
	FOREIGN KEY (companyId) REFERENCES tblCompany (id)
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

CREATE PROCEDURE sp_register_teacher
	@username VARCHAR(50),
	@password VARCHAR (50),
    @role VARCHAR(20),
    @status BIT,
    @name VARCHAR(50)
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
		INSERT INTO tblTeacher(name, userId) VALUES (@name, SCOPE_IDENTITY())
	END
	SELECT @ReturnCode as ReturnValue
END
GO

--

CREATE PROCEDURE sp_lock_account_teacher
	@teacherId INT,
	@status VARCHAR(50)
AS
BEGIN
	DECLARE @userId INT
	SELECT @userId = userId
	FROM tblTeacher WHERE id = @teacherId
	BEGIN
		UPDATE tblUser SET status = @status WHERE id = @userId
	END
END
GO

--exec sp_lock_account_teacher 1, 'true'

CREATE PROCEDURE sp_lock_account_student
	@studentId INT,
	@status VARCHAR(50)
AS
BEGIN
	DECLARE @userId INT
	SELECT @userId = userId
	FROM tblStudent WHERE id = @studentId
	BEGIN
		UPDATE tblUser SET status = @status WHERE id = @userId
	END
END
GO

--exec sp_lock_account_student 2, 0

CREATE PROCEDURE sp_delete_student
	@studentId INT
AS
	DELETE FROM tblStudent WHERE id = @studentId
GO

CREATE PROCEDURE sp_login
	@username VARCHAR(50),
	@password VARCHAR(50)
AS
BEGIN
	DECLARE @status BIT
	DECLARE @role VARCHAR(50)
	SELECT @status = status FROM tblUser WHERE username = @username AND password =@password
	IF @status = 1
	BEGIN
		SELECT @role = role FROM tblUser WHERE username = @username AND password = @password;
	END
	ELSE
	BEGIN
		SET @role = 'none'
	END
	SELECT @role as role
END
GO

exec sp_login 'quang123', '123456'

CREATE PROCEDURE sp_login_return_id
	@username VARCHAR(50),
	@password VARCHAR(50)
AS
	SELECT id FROM tblUser WHERE username = @username AND password = @password
GO

CREATE PROCEDURE sp_add_class
	@name VARCHAR(50),
	@svMin INT,
	@svMax INT,
	@gvName VARCHAR(50),
	@time DATETIME
AS
	INSERT INTO tblClass(name, gvName, svRegMin, svRegMax, timeline) VALUES (@name, @gvName, @svMin, @svMax, @time)
GO

--

CREATE PROCEDURE sp_edit_class
	@id INT,
	@name VARCHAR(50),
	@svMin INT,
	@svMax INT,
	@gvName VARCHAR(50),
	@time DATETIME
AS
	UPDATE tblClass SET name = @name, svRegMin = @svMin, svRegMax = @svMax, gvName = @gvName, timeline = @time
GO

CREATE PROCEDURE sp_get_student
	@userId INT
AS
	SELECT id FROM tblStudent WHERE userId = @userId
GO

--exec sp_get_student 7

CREATE PROCEDURE sp_add_student_class
	@studentId INT,
	@classId INT
AS
	INSERT INTO tblClassStudent(classId, studentId) VALUES (@classId, @studentId)
	UPDATE tblClass SET svJoined = svJoined + 1 WHERE id = @classId
GO


--exec sp_login_return_id 'quang123', '123456'

CREATE PROCEDURE sp_delete_class
	@classId INT
AS
	DELETE FROM tblClass WHERE id = @classId
GO

--exec sp_delete_class 1

CREATE PROCEDURE sp_edit_teacher
	@id INT,
	@name VARCHAR(50),
	@password VARCHAR(50)
AS
	DECLARE @userId INT
	SELECT @userId = userId FROM tblTeacher WHERE id = @id
	BEGIN
		UPDATE tblTeacher SET name = @name WHERE id = @id
		UPDATE tblUser SET password = @password WHERE id = @userId
	END
GO

--exec sp_edit_teacher 1, 'quang', '123123'

CREATE PROCEDURE sp_edit_password
	@userId INT,
	@password VARCHAR(50)
AS
	UPDATE tblUser SET password = @password WHERE id = @userId
GO

--

CREATE PROCEDURE sp_add_company
	@name VARCHAR(50),
	@phone VARCHAR(50),
	@address VARCHAR(50),
	@userId INT
AS
	DECLARE @teacherId INT
	SELECT @teacherId = id FROM tblTeacher WHERE userId = @userId
	BEGIN
		INSERT INTO tblCompany(name, phone, address, teacherId) VALUES (@name, @phone, @address, @teacherId)
	END
GO

--

CREATE PROCEDURE sp_edit_company
	@name VARCHAR(50),
	@phone VARCHAR(50),
	@address VARCHAR(50),
	@id INT
AS
	UPDATE tblCompany SET name = @name, phone = @phone, address = @address WHERE id = @id
GO

--

CREATE PROCEDURE sp_add_student_company
	@companyId INT,
	@userId INT,
	@timeStart DATETIME,
	@timeEnd DATETIME,
	@position VARCHAR(50),
	@specialized VARCHAR(50)
AS
	DECLARE @studentId INT
	SELECT @studentId = id FROM tblStudent WHERE userId = @userId
	BEGIN
		INSERT INTO tblStudentCompany(studentId, companyId, timeStart, timeEnd, position, specialized) VALUES (@studentId, @companyId, @timeStart, @timeEnd, @position, @specialized)		
	END
GO

--

CREATE PROCEDURE sp_check_regis_class
	@studentId INT,
	@classId INT
AS
	SELECT COUNT(id) FROM tblClassStudent WHERE classId = @classId AND studentId = @studentId	
GO

--exec sp_check_regis_class 3,6

CREATE PROCEDURE sp_del_company
	@companyId INT
AS
	DELETE FROM tblCompany WHERE id = @companyId
GO

CREATE VIEW view_class
AS
	SELECT id AS 'ID', name AS 'Tên lớp', gvName AS 'Giảng viên', svRegMin AS 'Tối thiểu', svRegMax AS 'Tối đa', svJoined AS 'Đã đăng ký', timeline AS 'Lịch học'
FROM tblClass

CREATE VIEW view_teacher
AS
	SELECT tblTeacher.id AS 'ID', name AS 'Tên GV', username AS 'Tài khoản', status 'Trạng thái' FROM tblTeacher INNER JOIN tblUser ON tblTeacher.userId = tblUser.id;
--select * from view_teacher

CREATE VIEW view_student
AS
	SELECT tblStudent.id AS 'ID', name AS 'Tên Sinh Viên', svCode AS 'Mã Sinh Viên', username AS 'Tài khoản', status 'Trạng thái' FROM tblStudent INNER JOIN tblUser ON tblStudent.userId = tblUser.id;


CREATE VIEW view_company
AS
	SELECT id AS 'ID', name AS 'Tên Công Ty', phone AS 'Số Điện Thoại', address AS 'Địa Chỉ' FROM tblCompany