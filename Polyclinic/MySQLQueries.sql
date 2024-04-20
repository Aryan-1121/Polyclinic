-- Drop the database if it exists
DROP DATABASE IF EXISTS PolyclinicDB;

-- Create the database
CREATE DATABASE PolyclinicDB;

-- Switch to the database
USE PolyclinicDB;

-- Drop tables if they exist
DROP TABLE IF EXISTS Doctors;
DROP TABLE IF EXISTS Patients;
DROP TABLE IF EXISTS Appointments;

-- Create Doctors table
CREATE TABLE Doctors (
    DoctorID CHAR(3) PRIMARY KEY,
    Specialization VARCHAR(40) NOT NULL,
    DoctorName VARCHAR(50) NOT NULL,
    Fees DECIMAL(10, 2) NOT NULL
);

-- Insert data into Doctors table
INSERT INTO Doctors (DoctorID, Specialization, DoctorName, Fees) VALUES
('D1', 'Physician', 'Jacob Johnson', 500),
('D2', 'Orthopaedics', 'Smith Garry', 600),
('D3', 'Pediatrics', 'Anna Kirsten', 500),
('D4', 'Dermatology', 'Jennifer Kane', 500);

-- Create Patients table
CREATE TABLE Patients (
    PatientID CHAR(4) PRIMARY KEY,
    PatientName VARCHAR(40) NOT NULL,
    Age TINYINT NOT NULL,
    Gender ENUM('F', 'M') NOT NULL,
    ContactNumber VARCHAR(10) NOT NULL
);

-- Insert data into Patients table
INSERT INTO Patients (PatientID, PatientName, Age, Gender, ContactNumber) VALUES
('P1', 'Laila', 26, 'F', '9999998855'),
('P2', 'Anne', 23, 'F', '9988996611'),
('P3', 'Jane', 53, 'F', '6666668855'),
('P4', 'Feroz', 18, 'M', '1199998833'),
('P5', 'Amiya', 46, 'F', '7779998822'),
('P6', 'Susan', 31, 'F', '6666668880'),
('P7', 'Leo', 69, 'M', '9999971133'),
('P8', 'Dennis', 22, 'M', '3333338855'),
('P9', 'Maybel', 33, 'F', '9944665511'),
('P10', 'Richard', 35, 'M', '8766443355');







-- Drop the existing trigger if it exists
DROP TRIGGER IF EXISTS trg_check_dateofappointment;
-- Create the trigger to enforce the check constraint
DELIMITER //
CREATE TRIGGER trg_check_dateofappointment
BEFORE INSERT ON Appointments
FOR EACH ROW
BEGIN
    IF NEW.DateofAppointment < CURDATE() THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid appointment date';
    END IF;
END;
//
DELIMITER ;







-- Create Appointments table
CREATE TABLE Appointments (
    AppointmentNo INT AUTO_INCREMENT PRIMARY KEY,
    PatientID CHAR(4),
    DoctorID CHAR(3),
    DateofAppointment DATE,
    CONSTRAINT fk_PatientID FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    CONSTRAINT fk_DoctorID FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

-- Insert data into Appointments table
INSERT INTO Appointments (PatientID, DoctorID, DateofAppointment) VALUES
('P1', 'D1', DATE_ADD(CURDATE(), INTERVAL 15 DAY)),
('P2', 'D2', DATE_ADD(CURDATE(), INTERVAL 5 DAY)),
('P1', 'D2', DATE_ADD(CURDATE(), INTERVAL 5 DAY)),
('P3', 'D3', DATE_ADD(CURDATE(), INTERVAL 10 DAY)),
('P4', 'D4', DATE_ADD(CURDATE(), INTERVAL 10 DAY)),
('P5', 'D1', DATE_ADD(CURDATE(), INTERVAL 10 DAY)),
('P6', 'D4', DATE_ADD(CURDATE(), INTERVAL 7 DAY)),
('P7', 'D3', DATE_ADD(CURDATE(), INTERVAL 5 DAY)),
('P8', 'D4', DATE_ADD(CURDATE(), INTERVAL 7 DAY)),
('P9', 'D4', DATE_ADD(CURDATE(), INTERVAL 5 DAY)),
('P10', 'D2', DATE_ADD(CURDATE(), INTERVAL 5 DAY)),
('P7', 'D3', DATE_ADD(CURDATE(), INTERVAL 2 DAY)),
('P7', 'D2', DATE_ADD(CURDATE(), INTERVAL 6 DAY)),
('P2', 'D1', DATE_ADD(CURDATE(), INTERVAL 2 DAY)),
('P5', 'D2', DATE_ADD(CURDATE(), INTERVAL 3 DAY)),
('P6', 'D4', DATE_ADD(CURDATE(), INTERVAL 15 DAY)),
('P3', 'D1', DATE_ADD(CURDATE(), INTERVAL 15 DAY)),
('P5', 'D1', DATE_ADD(CURDATE(), INTERVAL 15 DAY));

-- Select data from tables
SELECT * FROM Doctors;
SELECT * FROM Patients;
SELECT * FROM Appointments;
