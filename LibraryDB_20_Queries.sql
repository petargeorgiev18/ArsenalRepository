CREATE DATABASE LibraryDB_20

CREATE TABLE Readers
(
	[ReaderId] INT PRIMARY KEY IDENTITY,
	[ReaderName] NVARCHAR(50) NOT NULL
)

CREATE TABLE Libraries
(
	[LibraryId] INT PRIMARY KEY IDENTITY,
	[LibraryName] NVARCHAR(100) NOT NULL
)

CREATE TABLE Books
(
	[BookId] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(80) NOT NULL,
	[LibraryId] INT,
	FOREIGN KEY ([LibraryId]) REFERENCES Libraries([LibraryId]) ON DELETE SET DEFAULT
)

CREATE TABLE Loans
(
	[ReaderId] INT REFERENCES Readers([ReaderId]) ON DELETE CASCADE,
	[BookId] INT REFERENCES Books([BookId]) ON DELETE SET NULL,
	[LoanDate] DATE NOT NULL
)

INSERT INTO Readers (ReaderName) VALUES
(N'����� ������'),
(N'����� �������'),
(N'������ ��������'),
(N'����� ��������');

INSERT INTO Libraries (LibraryName) VALUES
(N'��������� ����������'),
(N'������� ����������'),
(N'�������������� ����������');

INSERT INTO Books (Title, LibraryId) VALUES
(N'1984', 1),
(N'������������ � ���������', 2),
(N'���� �����', 3),
(N'���� ����� ������', 1);

INSERT INTO Loans (ReaderId, BookId, LoanDate) VALUES
(1, 1, '2023-05-10'),
(2, 2, '2023-06-15'),
(3, 3, '2023-07-20'),
(4, 4, '2023-08-25');

DELETE FROM Readers WHERE ReaderId = 1;

DELETE FROM Books WHERE Title = N'������������ � ���������';

INSERT INTO Books (Title, LibraryId)
SELECT N'����� � ���', LibraryId FROM Libraries 
WHERE LibraryName = N'�������������� ����������';

UPDATE Books 
SET LibraryId = 1 
WHERE LibraryId = 3;

DELETE FROM Libraries WHERE LibraryId = 3;