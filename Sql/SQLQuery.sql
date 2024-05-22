IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'rooms')
	CREATE TABLE dbo.Rooms(
			room_id INT IDENTITY(1,1) NOT NULL,
			room_number INT NOT NULL,
			room_type NVARCHAR(30) NOT NULL,
			price_per_night MONEY NOT NULL,
			availability BIT NOT NULL,
			CONSTRAINT PK_rooms_id_room PRIMARY KEY(room_id)
	)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'customers')
	CREATE TABLE dbo.Customers(
			 customer_id INT IDENTITY(1,1) NOT NULL,
			 full_name NVARCHAR(50) NOT NULL,
			 email NVARCHAR(30) NOT NULL,
			 phone_number NVARCHAR(20) NOT NULL,
			 CONSTRAINT PK_customers_id_customer PRIMARY KEY(customer_id)
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'bookings')
	CREATE TABLE dbo.Bookings(
			 booking_id INT IDENTITY(1,1) NOT NULL,
			 customer_id INT NOT NULL,
			 room_id INT NOT NULL,
			 check_in_date DATE NOT NULL,
			 check_out_date DATE NOT NULL,
			 CONSTRAINT PK_bookings_id_booking PRIMARY KEY(booking_id),
			 CONSTRAINT FK_bookings_id_customer
				FOREIGN KEY (customer_id) REFERENCES dbo.Customers (customer_id),
			 CONSTRAINT FK_bookings_id_room
				FOREIGN KEY (room_id) REFERENCES dbo.Rooms (room_id)
	)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'roomFacilities')
	CREATE TABLE dbo.RoomFacilities(
			 facility_id INT IDENTITY(1,1) NOT NULL,
			 facility_name NVARCHAR(30) NOT NULL,
			 CONSTRAINT PK_roomFacilities_id_facility PRIMARY KEY(facility_id)
	)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'roomFacilitiesMapping')
	CREATE TABLE dbo.RoomFacilitiesMapping(
			 room_id INT NOT NULL,
			 facility_id INT NOT NULL,
			 CONSTRAINT PK_roomFacilitiesMapping_id_roomFacilitiesMapping PRIMARY KEY(room_id, facility_id),
			 CONSTRAINT FK_roomFacilitiesMapping_id_room
				FOREIGN KEY (room_id) REFERENCES dbo.Rooms(room_id),
			 CONSTRAINT FK_roomFacilitiesMapping_id_roomFacilities
				FOREIGN KEY (facility_id) REFERENCES dbo.RoomFacilities(facility_id)
	)

INSERT INTO Rooms (room_number, room_type, price_per_night, availability)
VALUES
    (101, N'Одноместный', 1500.00, 1),
    (102, N'Одноместный', 1500.00, 0),
    (103, N'Одноместный', 1500.00, 1),
    (201, N'Двухместный', 3000.00, 1),
    (202, N'Двухместный', 3000.00, 0),
    (203, N'Двухместный', 3000.00, 1),
    (301, N'Люкс', 5000.00, 1),
    (302, N'Люкс', 5000.00, 0),
    (303, N'Люкс', 5000.00, 1),
    (401, N'Делюкс', 10000.00, 1),
    (402, N'Делюкс', 10000.00, 0),
    (403, N'Делюкс', 10000.00, 1);

INSERT INTO Customers (full_name, email, phone_number)
VALUES
    (N'Иванов Иван', N'ivanov@example.com', '+7 999 999-99-99'),
    (N'Сидоров Сергей', N'sydorov@example.com', '+7 888 888-88-88'),
    (N'Петров Петр', N'petrov@example.com', '+7 777 777-77-77'),
    (N'Фомин Фома', N'fomin@example.com', '+7 666 66-66-66');

INSERT INTO Bookings (customer_id, room_id, check_in_date, check_out_date)
VALUES
    (1, 2, '2024-05-20', '2024-05-31'),
    (2, 5, '2024-05-17', '2024-05-31'),
    (3, 8, '2024-05-17', '2024-05-31'),
    (4, 11, '2024-05-21', '2024-05-31');

INSERT INTO RoomFacilities (facility_name)
VALUES
    (N'Wi-Fi'),
	(N'Мини-бар'),
    (N'Кондиционер'),
    (N'Питание'),
    (N'Телевизор'),
    (N'Кофемашина');

-- Добавление данных в таблицу "RoomToFacilities"
INSERT INTO RoomFacilitiesMapping (room_id, facility_id)
VALUES
    (1, 1),
    (1, 5),
    (2, 1),
    (2, 5),
    (3, 1),
    (3, 5),
    (4, 1),
    (4, 4),
    (5, 1),
    (5, 4),
    (5, 5),
    (6, 1),
    (6, 2),
    (6, 3),
    (6, 4),
    (7, 1),
    (7, 2),
    (7, 3),
    (7, 4),
    (7, 5),
    (8, 1),
    (8, 2),
    (8, 3),
    (8, 4),
    (8, 5),
    (9, 1),
    (9, 2),
    (9, 3),
    (9, 4),
    (9, 5),
    (10, 1),
    (10, 2),
    (10, 3),
    (10, 4),
    (10, 5),
	(11, 1),
    (11, 2),
    (11, 3),
    (11, 4),
    (11, 5),
	(12, 1),
    (12, 2),
    (12, 3),
    (12, 4),
    (12, 5);

SELECT [r].[room_id] FROM rooms r
JOIN bookings b ON b.room_id = r.room_id
WHERE 
((
	GETDATE() NOT BETWEEN b.check_in_date AND b.check_out_date 
) 
OR (r.room_id NOT IN (b.room_id))) AND availability = 1

SELECT * FROM dbo.customers
WHERE full_name LIKE 'S%';

SELECT *
FROM bookings b
LEFT JOIN customers c ON b.customer_id = c.customer_id
WHERE c.email = 'petrov@example.com';

SELECT *
FROM bookings b
INNER JOIN rooms c ON b.room_id = c.room_id
WHERE c.room_id = 5;

SELECT * FROM rooms

SELECT * FROM rooms
WHERE 
(room_id IN 
(
	SELECT room_id FROM bookings b 
	WHERE '2024-05-21' NOT BETWEEN b.check_in_date AND b.check_out_date
) 
OR (room_id NOT IN (SELECT room_id FROM bookings))) AND availability = 1
