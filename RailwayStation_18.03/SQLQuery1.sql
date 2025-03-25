CREATE DATABASE RailwayStationDB;

CREATE TABLE Trains
(
	[id] INT PRIMARY KEY IDENTITY,
	[train_number] VARCHAR(10) UNIQUE NOT NULL,
	[capacity] INT NOT NULL
)

CREATE TABLE [Routes]
(
	[id] INT PRIMARY KEY IDENTITY,
	[train_id] INT REFERENCES Trains([id]),
	[departure_station] VARCHAR(100) NOT NULL,
	[arrival_station] VARCHAR(100) NOT NULL,
	[departure_time] DATETIME NOT NULL,
	[arrival_time] DATETIME NOT NULL
)

CREATE TABLE [Tracks]
(
	[id] INT PRIMARY KEY IDENTITY,
	[station_name] VARCHAR(100) NOT NULL,
	[track_number] INT UNIQUE NOT NULL,
	[train_id] INT REFERENCES Trains([id])
)

CREATE TABLE [Tickets]
(
	[id] INT PRIMARY KEY IDENTITY,
	[passenger_name] VARCHAR(100) NOT NULL,
	[train_id] INT REFERENCES Trains([id]) NOT NULL,
	[route_id] INT REFERENCES [Routes]([id]) NOT NULL,
	[seat_number] VARCHAR(10) NOT NULL,
	[price] DECIMAL(10,2) NOT NULL
)

CREATE TABLE [Employees]
(
	[id] INT PRIMARY KEY IDENTITY,
	[name] VARCHAR(100) NOT NULL,
	[position] VARCHAR(50) NOT NULL,
	[train_id] INT REFERENCES Trains([id])
)

INSERT INTO Trains (train_number, capacity) VALUES
('EXP100', 300),
('REG200', 150),
('FRT300', 500);

INSERT INTO [Routes] (train_id, departure_station, arrival_station, departure_time, arrival_time) VALUES
(1, 'Sofia', 'Varna', '2025-03-16 08:00:00', '2025-03-16 14:30:00'),
(2, 'Sofia', 'Plovdiv', '2025-03-16 09:30:00', '2025-03-16 11:00:00'),
(3, 'Burgas', 'Ruse', '2025-03-16 10:00:00', '2025-03-16 18:00:00');

INSERT INTO Tracks (station_name, track_number, train_id) VALUES
('Central Station Sofia', 1, 1),
('Central Station Sofia', 2, 2),
('Plovdiv Station', 3, NULL),
('Varna Station', 4, 3);

INSERT INTO Tickets (passenger_name, train_id, route_id, seat_number, price) VALUES
('John Smith', 1, 1, '12A', 45.50),
('Emma Johnson', 2, 2, '8B', 15.00),
('George Brown', 3, 3, '5C', 60.00),
('Sophia Wilson', 1, 1, '7D', 45.50);

INSERT INTO Employees (name, position, train_id) VALUES
('Michael Davis', 'Train Driver', 1),
('James Miller', 'Conductor', 2),
('Robert Taylor', 'Operator', NULL),
('William Anderson', 'Train Driver', 3);