USE TaskTrackerDB;

CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100),
    Description NVARCHAR(255),
    IsCompleted BIT,
    DueDate DATETIME
);

INSERT INTO Tasks (Title, Description, IsCompleted, DueDate) VALUES
('Araba', 'BMW', 0, '2026-04-06'),
('Motor', 'Yamaha', 1, '2026-04-06');