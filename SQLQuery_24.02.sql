CREATE DATABASE CarsShowroom;

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY,
    CategoryName VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Engines (
    EngineID INT PRIMARY KEY IDENTITY,
    EngineType VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY,
    Brand VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    CategoryID INT,
    EngineID INT,
    Color VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (EngineID) REFERENCES Engines(EngineID)
);

CREATE TABLE Clients (
    ClientID INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Phone VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY,
    CarID INT,
    ClientID INT,
    SaleDate DATE NOT NULL,
    FOREIGN KEY (CarID) REFERENCES Cars(CarID),
    FOREIGN KEY (ClientID) REFERENCES Clients(ClientID)
);

INSERT INTO Categories (CategoryName) VALUES
('Ван'), ('Джип'), ('Кабрио'), ('Комби'), ('Купе'),
('Миниван'), ('Пикап'), ('Седан'), ('Стреч лимузина'), ('Хечбек');

INSERT INTO Engines (EngineType) VALUES
('Бензинов'), ('Дизелов'), ('Електрически'), ('Хибриден'), ('Plug-In Хибрид');

INSERT INTO Cars (Brand, Model, CategoryID, EngineID, Color, Year, Price) VALUES
('VW', 'Golf', 1, 1, 'Черен', 2022, 20000),
('Audi', 'A3', 2, 2, 'Сив', 2021, 25000),
('BMW', '3 Series', 2, 1, 'Бял', 2020, 30000),
('Mercedes-Benz', 'C-Class', 2, 1, 'Бял', 2022, 35000),
('Toyota', 'Corolla', 1, 3, 'Сив', 2021, 22000),
('Audi', 'A5', 1, 1, 'Черен', 2020, 32000),
('BMW', '6 Series', 1, 2, 'Черен', 2019, 35000),
('Audi', 'A8', 3, 1, 'Черен мат', 2023, 75000),
('Mercedes-Benz', 'G 500', 2, 3, 'Черен', 2022, 68000),
('Peugeot', '308', 1, 2, 'Син', 2022, 23000);

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Иван', 'Иванов', '0888123456'),
('Петър', 'Петров', '0899123456'),
('Георги', 'Георгиев', '0877123456'),
('Мартин', 'Маринов', '0885123456'),
('Алекс', 'Александров', '0897123456'),
('Борис', 'Борисов', '0886123456'),
('Кирил', 'Кирилов', '0876123456'),
('Даниел', 'Данев', '0896123456'),
('Стоян', 'Стоянов', '0884123456'),
('Николай', 'Николов', '0875123456');

INSERT INTO Sales (CarID, ClientID, SaleDate) VALUES
(6, 8, '2022-01-16'),
(2, 3, '2022-02-09'),
(5, 1, '2022-11-30'),
(7, 4, '2022-04-19'),
(1, 6, '2023-05-21');

SELECT * FROM Cars;

SELECT * FROM Cars WHERE [Year] < 2020;

SELECT Model, Color, [Year], Price FROM Cars WHERE Brand = 'Audi';

SELECT Brand, Model, [Year], Price FROM Cars WHERE EngineID = 1;

SELECT Brand, Model, [Year], Price FROM Cars WHERE CategoryID = 1;

SELECT * FROM Cars WHERE Color IN ('Черен', 'Син');

SELECT TOP 1 Brand, Model, [Year], Price FROM Cars ORDER BY Price ASC;

SELECT Brand, Model, Color, [Year], Price FROM Cars WHERE EngineID = 1 ORDER BY Price DESC;

SELECT Brand, Model, ct.CategoryName, [Year], Price FROM Cars as c
JOIN Categories as ct ON c.CategoryID = ct.CategoryID 
WHERE ct.CategoryName = 'Ван';

SELECT cl.FirstName, cl.LastName, c.Brand, c.Model, c.Color, c.Price 
FROM Sales as s 
JOIN Clients as cl ON s.ClientID = cl.ClientID 
JOIN Cars as c ON s.CarID = c.CarID 
ORDER BY c.Brand ASC, c.Price DESC;

SELECT c.Brand, c.Model, c.Year, c.Price, ct.CategoryName 
FROM Cars as c
JOIN Categories as ct ON c.CategoryID = ct.CategoryID 
WHERE ct.CategoryName = 'Джип' AND c.Price BETWEEN 20000 AND 30000;

SELECT cl.FirstName, cl.LastName, c.Brand, c.Model, c.Color, c.Price 
FROM Sales as s
JOIN Clients as cl ON s.ClientID = cl.ClientID 
JOIN Cars as c ON s.CarID = c.CarID 
WHERE c.Color = 'Черен' 
ORDER BY c.Price ASC;

SELECT ct.CategoryName 
FROM Categories as ct
LEFT JOIN Cars as c ON ct.CategoryID = c.CategoryID 
WHERE c.CarID IS NULL;

SELECT cl.FirstName, cl.LastName, s.SaleDate 
FROM Clients as cl
LEFT JOIN Sales as s ON cl.ClientID = s.ClientID;

SELECT cl.FirstName, cl.LastName 
FROM Clients as cl
LEFT JOIN Sales as s ON cl.ClientID = s.ClientID 
WHERE s.SaleID IS NULL;