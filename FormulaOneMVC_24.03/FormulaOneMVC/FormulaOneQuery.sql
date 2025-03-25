CREATE DATABASE FormulaOneDB;
USE FormulaOneDB;

CREATE TABLE Teams (
    team_id INT PRIMARY KEY IDENTITY,
    team_name VARCHAR(255) NOT NULL,
    country VARCHAR(100) NOT NULL,
    foundation_year INT NOT NULL
);

CREATE TABLE Drivers (
    driver_id INT PRIMARY KEY IDENTITY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    birth_date DATE NOT NULL,
    nationality VARCHAR(100) NOT NULL,
    team_id INT,
    FOREIGN KEY (team_id) REFERENCES Teams(team_id) ON DELETE SET NULL
);

CREATE TABLE Races (
    race_id INT PRIMARY KEY IDENTITY,
    race_name VARCHAR(255) NOT NULL,
    [location] VARCHAR(255) NOT NULL,
    race_date DATE NOT NULL,
    season_year INT NOT NULL
);

CREATE TABLE Race_Results (
    result_id INT PRIMARY KEY IDENTITY,
    race_id INT,
    driver_id INT,
    position INT NOT NULL,
    points DECIMAL(5,2) NOT NULL,
    laps INT NOT NULL,
    [time] TIME,
    FOREIGN KEY (race_id) REFERENCES Races(race_id) ON DELETE CASCADE,
    FOREIGN KEY (driver_id) REFERENCES Drivers(driver_id) ON DELETE CASCADE
);

INSERT INTO Teams (team_name, country, foundation_year) 
VALUES
('Mercedes', 'Germany', 1954),
('Ferrari', 'Italy', 1929),
('Red Bull Racing', 'Austria', 2005),
('McLaren', 'United Kingdom', 1963),
('Alpine', 'France', 2021);

INSERT INTO Drivers (first_name, last_name, birth_date, nationality, team_id) 
VALUES
('Lewis', 'Hamilton', '1985-01-07', 'British', 1),
('Max', 'Verstappen', '1997-09-30', 'Dutch', 3),
('Charles', 'Leclerc', '1997-10-16', 'Monégasque', 2),
('Lando', 'Norris', '1999-11-13', 'British', 4),
('Esteban', 'Ocon', '1996-09-17', 'French', 5);

INSERT INTO Races (race_name, location, race_date, season_year) 
VALUES
('Australian Grand Prix', 'Melbourne, Australia', '2025-03-15', 2025),
('Bahrain Grand Prix', 'Sakhir, Bahrain', '2025-03-22', 2025),
('Monaco Grand Prix', 'Monte Carlo, Monaco', '2025-05-26', 2025),
('British Grand Prix', 'Silverstone, UK', '2025-07-06', 2025),
('Japanese Grand Prix', 'Suzuka, Japan', '2025-10-12', 2025);

INSERT INTO Race_Results (race_id, driver_id, position, points, laps, time) 
VALUES
(1, 1, 1, 25.00, 58, '01:32:10'),
(1, 2, 2, 18.00, 58, '01:32:20'),
(2, 3, 1, 25.00, 57, '01:29:50'),
(2, 4, 3, 15.00, 57, '01:30:30'),
(3, 5, 2, 18.00, 78, '01:45:15');