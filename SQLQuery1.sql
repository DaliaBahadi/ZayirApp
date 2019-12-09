/*
	Course:			BBIS 3301
	Project Name:	Zayir Database
	Date:			Spring 2018-2019 / fall 2019-2020
	Authors:		Hoda Amanullah Khuja
					Dalia Bahadibajaba
					Hanouf Al Salahi
					Ateqa Bin Mahfodh
*/

-- Create Zayir Database
CREATE DATABASE ZayirDatabase;
GO

-- Make Zayir the current database
USE ZayirDatabase;
GO

-- Create the visitor table
CREATE TABLE Visitor (
	VisitorId				INT PRIMARY KEY IDENTITY(1,1),
	FirstName				NVARCHAR(max)	NOT NULL,
	FatherName				NVARCHAR(max),
	GrandfatherName			NVARCHAR(max),
	LastName				NVARCHAR(max)	NOT NULL,
	BirthDate				DATE,			
	Mobile					NVARCHAR(max)	NOT NULL,
	Gender					INT,			-- Enum
	Email					NVARCHAR(max),	-- nvarchar
	Company					NVARCHAR(max),
	JobTitle				NVARCHAR(max),
	ImageFile				NVARCHAR(max),	
	CarLicencePlate			NVARCHAR(max),
	IsBlacklisted			BIT,				
	[Language]				INT,	
	AcceptSMSNotification	BIT,				
	AcceptEmailNotification	BIT,				
	ClearanceLevel			INT,			-- Enum	
	Note					NVARCHAR(max),
);
GO

-- Create the department table
CREATE TABLE Department (
	DepartmentId	INT PRIMARY KEY IDENTITY(1,1),
	[Name]			NVARCHAR(max)	NOT NULL
);
GO

-- Create the Contact table
CREATE TABLE Contact (
	ContactId 				INT PRIMARY KEY IDENTITY(1,1),
	FirstName				NVARCHAR(max)	NOT NULL,
	LastName 				NVARCHAR(max)	NOT NULL,
	Email					NVARCHAR(max)	NOT NULL, 
	Mobile 					NVARCHAR(max)	NOT NULL,
	[Language] 				INT,			
	Gender					INT,	
	AcceptSMSNotification	BIT,	
	AcceptEmailNotification	BIT,	
	DepartmentId			INT FOREIGN KEY REFERENCES Department(DepartmentId)	NOT NULL,

	StudentId		INT,

	EmployeeId		INT,
	PhoneExtention	NVARCHAR(max),		
	OfficeNumber	NVARCHAR(max),
	--EmployeeType	INT	NOT NULL

	ContactType		INT NOT NULL -- Include staff, faculty, student
);
GO

-- Create a Registration table in the database
CREATE TABLE Registration (
	RegistrationId			INT PRIMARY KEY IDENTITY(1,1),
	[Status]				INT	NOT NULL,
	RegistrationDateTime	DATETIME2		NOT NULL,
	ExpiryDateTime			DATETIME2,
	VisitDateTime			DATETIME2		NOT NULL,
	ContactId				INT FOREIGN KEY REFERENCES Contact(ContactId) NOT NULL,
	VisitorId				INT FOREIGN KEY REFERENCES Visitor(VisitorId) NOT NULL
	--VisitId					INT FOREIGN KEY REFERENCES Visit(VisitId) -- For one-to-one
);
GO

-- Create a Document table in the database
CREATE TABLE Document (
	DocumentId		INT PRIMARY KEY IDENTITY(1,1),
	DocumentNumber	NVARCHAR(max)	NOT NULL,
	ExpiryDate		DATE			NOT NULL,
	DocumentFile	NVARCHAR(max),
	DocumentType	INT,
	VisitorId		INT FOREIGN KEY REFERENCES Visitor(VisitorId) NOT NULL
);
GO

-- Create a Gate table in the database
CREATE TABLE Gate (
	GateId				INT PRIMARY KEY IDENTITY(1,1),
	[Name]				NVARCHAR(max) NOT NULL,
	[Description]		NVARCHAR(max),
	EvacuationDetails	NVARCHAR(max),
	EvacuationPlanFile	NVARCHAR(max) 
);
GO

-- Create a Event table in the database	
CREATE TABLE Event (
	EventId			INT PRIMARY KEY  IDENTITY(1,1),
	[Name]			NVARCHAR(max)	NOT NULL,
	StartDateTime	DATETIME2	NOT NULL,	
	EndDateTime		DATETIME2	NOT NULL,
	[Description]	NVARCHAR(max)
);
GO

-- Create a Badge table in the database
CREATE TABLE Badge (	
	BadgeId		INT PRIMARY KEY IDENTITY(1,1),		
	Note		NVARCHAR(max),
);
GO

-- Create a Agreement table in the database
CREATE TABLE Agreement (
	AgreementId		INT PRIMARY KEY IDENTITY(1,1),		
	Title			NVARCHAR(max)	NOT NULL,
	Content			NVARCHAR(max),
	AgreementFile 	NVARCHAR(max),
	NeedSignature	BIT,
	NeedAgreement	BIT	
);
GO

-- Create a Message table in the database
CREATE TABLE Message (
	MessageId		INT PRIMARY KEY IDENTITY(1,1),
	[Language]		INT	,
	Content			NVARCHAR(max)	NOT NULL
);
GO

-- Create a Delivery table in the database
CREATE TABLE Delivery (
	DeliveryId			INT PRIMARY KEY IDENTITY(1,1),
	ReciptionDateTime	DATETIME2	NOT NULL,
	PickupDateTime		DATETIME2	NOT NULL,
	[Description]		NVARCHAR(max),
	ContactId			INT FOREIGN KEY REFERENCES Contact(ContactId)	NOT NULL,
	VisitorId			INT FOREIGN KEY REFERENCES Visitor(VisitorId)	NOT NULL,
	RegistrarId			INT FOREIGN KEY REFERENCES Contact(ContactId)	NOT NULL
);
GO

-- Create a Visit table in the database
CREATE TABLE Visit (
	VisitId			INT PRIMARY KEY IDENTITY(1,1),
	SignInDateTime	DATETIME2		NOT NULL,
	SignOutDateTime	DATETIME2,
	[Description]	NVARCHAR(max),
	[Status]		INT	NOT NULL,
	VisitType		INT	NOT NULL,
	ValidityInDays	INT, --Integer
	GateId			INT FOREIGN KEY REFERENCES Gate(GateId)			NOT NULL,
	EventId			INT FOREIGN KEY REFERENCES Event(EventId),
	BadgeId			INT FOREIGN KEY REFERENCES Badge(BadgeId),
	VisitorId		INT FOREIGN KEY REFERENCES Visitor(VisitorId)	NOT NULL,
	ContactId		INT FOREIGN KEY REFERENCES Contact(ContactId)	NOT NULL,
	RegistrationId	INT FOREIGN KEY REFERENCES Registration(RegistrationId),
	RegistrarId		INT FOREIGN KEY REFERENCES Contact(ContactId)	NOT NULL
);
GO

-- Create a VisitAgreement table in the database
CREATE TABLE VisitAgreement (
	VisitAgreementId	INT PRIMARY KEY IDENTITY(1,1),
	Agreed				BIT,		
	Signed				BIT, 
	SignatureFile		NVARCHAR(max),		
	AgreementId			INT FOREIGN KEY REFERENCES Agreement(AgreementId)	NOT NULL,
	VisitId				INT FOREIGN KEY REFERENCES Visit(VisitId)			NOT NULL
);
GO

-- Create a Notification table in the database
CREATE TABLE Notification (
	NotificationId			INT PRIMARY KEY IDENTITY(1,1),
	NotificationDateTime	DATETIME2 NOT NULL,
	NotificationType		INT	NOT NULL,
	ContactId				INT FOREIGN KEY REFERENCES Contact(ContactId)	NOT NULL,	
	DeliveryId				INT FOREIGN KEY REFERENCES Delivery(DeliveryId)	NOT NULL,
	VisitId					INT FOREIGN KEY REFERENCES Visit(VisitId)		NOT NULL,
	VisitorId				INT FOREIGN KEY REFERENCES Visitor(VisitorId)	NOT NULL
);
GO

-- Insert data into the visitor table
INSERT INTO Visitor VALUES
	('Sara',		'Khalid',	'Fahad',	'Al-Ghamdi',	'1989-09-12',	'00966506080679', 1, 'saahmed@gmail.com',	'BMW Company',			'Engineering',		'Documents/images/image1.jpg',	'3926-RDQ',		1,	1,	1,	1,	1,		'This Is A note'),
	('Lina',		'Khaled',	NULL,		'Al Harbi',		'1999-05-10',	'00966508780543', 1,	'likhaled@gmail.com',	'BMS University',		'Lecturer',			'Documents/images/image2.jpg',	'1547-UYG',	0,	1,	1,	1,	1,		'This Is A note'),
	('Omar',		'Saeed',	'Mohammed',	'Al Otaibi',	'1980-07-08',	'00966554953541',2,	'omsaeed@gmail.com',	'BMS University',		'Supervisor',		'Documents/images/image3.jpg',	'3091-JHY',		1,	1,	1,	1,	2,		'This Is A note'),
	('Huda',		'Samer',	NULL,		'Omar',			'1988-05-02',	'00966559764211', 1,	'husamer@gmail.com',	'Almarai Company',		'Manager',			'Documents/images/image4.jpg',	'8254-ABE',	1,	1,	1,	1,	1,		'This Is A note'),
	('Ghada',	'Amer',		'Ahmed',	'Al Jaldi',		'1979-02-02',	'00966534561236', 1,	'ghamer@gmail.com',		'Dar Al quran School',	'History teacher',	'Documents/images/image5.jpg',	'9201-GAV',		0,	1,	1,	1,	1,		'This Is A note'),
	('Dalal',	NULL,		'Mustafa',	'Abbas',		'1996-12-06',	'00966522568709', 1,	'damohammed@gmail.com',	'Tasty Burger',			'Cook',				'Documents/images/image6.jpg',	'5139-NKF',		0,	1,	1,	1,	2,		'This Is A note'),
	('Hatem',	'Tamer',	'Maher',	'Al Zahrani',	'1977-07-11',	'00966509323541', 2,	'hatamer@gmail.com',	'Flowers Company',		'Designer',			'Documents/images/image7.jpg',	'2681-HSY',		0,	1,	1,	1,	1,		'This Is A note'),
	('Fareed',	'Moalem',	NULL,		'Al Shareef',	'1968-10-01',	'00966508523765', 2,	'famoalem@gmail.com',	'FM Company',			'CEO',				'Documents/images/image8.jpg',	'3986-CDZ',		0,	2,	1,	1,	3,		'This Is A note'),
	('Amira',	'Maher',	'Fahad',	'Bugshan',		'1997-12-09',	'00966508577664', 1,	'ammaher@gmail.com',	'Effat University',		'Student',			'Documents/images/image9.jpg',	'6578-WOM',		0,	2,	1,	1,	3,		'This Is A note'),
	('Turkey',	'Abdullah',	'Meshari',	'Gahtani',		'1993-12-09',	'00966596458662', 2,	'tuabdullah@gmail.com',	'King Abdulaziz University',	'Lecturer',	'Documents/images/image10.jpg',	'4256-SBE',		0,	2,	1,	1,	1,		'This Is A note'),
	('Saeed',	'Saleh',	'Mohammed',	'Hamdan',		'1993-12-09',	'00966596450062', 2,	'shamdan@gmail.com',	'King Abdulaziz University',	'Lecturer',	'Documents/images/image11.jpg',	'4346-SDE',		0,	2,	1,	1,	1,		'This Is A note'),
	('Sara',		'Omar',		'Ali',		'Harthie',		'1993-12-09',	'00966500458662', 1,	'sharthie@gmail.com',	'Effat University',				'Lecturer',	'Documents/images/image12.jpg',	'4278-MBG',	0,	2,	1,	1,	1,		'This Is A note');

GO

--Insert data into Department Table
INSERT INTO Department VALUES
	('Business Department'),
	('Health Department'),
	('Law Department'),
	('Design Department');
GO

--Insert data into Contact Table
INSERT INTO Contact VALUES
	('Inaas',	'Ali'   ,	'iali@dah.edu.sa'   ,	'00966509388338', 1, 1, 1, 1, 1, NULL,		1001, 232, 210, 1),
	('Sanaa',	'Askool',	'saskool@dah.edu.sa',	'00966444589241', 1, 1, 1, 1, 4, NULL,		1002, 233, 319, 1),
	('Hatem',	'Khalid',	'hkhalid@dah.edu.sa',	'00966758443395', 2, 2, 1, 0, 2, NULL,		1003, 262, 366, 1),
	('Saleh',	'Fares' ,	'sfares@dah.edu.sa' ,	'00966334558126', 1, 2, 0, 0, 1, NULL,		1004, 243, 324, 1),
	('Nuha',	'Ahmed',	'nahmed@dah.edu.sa',	'00966474632475', 1, 1, 1, 1, 4, NULL,		1005, 126, 153, 1),
	('Abdullah','Alrajhi',	'aalrajhi@dah.edu.sa',	'00966979089241', 1, 2,	1, 1, 4, NULL,		1006, 145, 154, 1),
	('Farah',	'Abbass',	'fabbass@dah.edu.sa',	'00966449564201', 2, 1, 1, 1, 1, NULL,		1007, 159, 023, 1),
	('Hanaa',	'Abdulaziz','habdulaziz@dah.edu.sa','00966987475157', 2, 1, 1, 1, 2, NULL,		1008, 246, 024, 1),
	('Hanan',	'Abdullah',	'habdullah@dah.edu.sa',	'00966987845157', 2, 1, 0, 1, 2, NULL,		1009, 266, 027,	2),
	('Lina',	'Hisham',	'lhisham@dah.edu.sa',	'00966974102157', 2, 1, 1, 1, 2, 1810023,	NULL, NULL, NULL, 3),
	('Nora',	'AlHadi',	'halhadi@dah.edu.sa',	'00966978452198', 2, 1, 0, 1, 2, 1610103,	NULL, NULL, NULL, 3);

GO

---------------------------------------------
-- Combine student and employee into contact
---------------------------------------------

--Insert data into Student table
--INSERT INTO Student VALUES
	--(1620039),
	--(1610045),
	--(1710009),
	--(1810023);
--GO

--Insert data into Employee table
--INSERT INTO Employee VALUES
	--(1001, 232, 210, 1),
	--(1002, 233, 319, 1),
	--(1003, 262, 366, 1),
	--(1004, 243, 324, 1);
--GO

-- Insert data into the Registration table
INSERT INTO Registration VALUES
	(1,	'2019-05-02 15:15:22', '2019-05-09 15:15:22',	'2019-05-05 03:15:22',	1,	1),
	(1,	'2019-06-22 02:10:11', '2019-06-29 02:10:11',	'2019-06-23 01:17:27',	2,	2),
	(1,	'2019-08-12 14:19:12', '2019-08-19 12:19:12',	'2019-08-12 04:11:08',	3,	3),
	(1,	'2019-08-12 14:19:12', '2019-08-19 12:19:12',	'2019-08-12 04:11:08',	1,	5),
	(1,	'2019-02-03 12:19:12', '2019-02-10 12:19:12',	'2019-02-03 05:10:16',	4,	4),
	(1,	'2019-09-03 12:19:12', '2019-09-10 12:19:12',	'2019-09-13 05:10:16',	4,	6),
	(1,	'2019-09-12 13:19:12', '2019-09-10 12:19:12',	'2019-09-11 05:10:16',	1,	7),
	(1,	'2019-08-20 11:19:12', '2019-08-10 12:19:12',	'2019-08-14 05:10:16',	2,	8),
	(1,	'2019-09-13 16:19:12', '2019-09-10 12:19:12',	'2019-09-12 05:10:16',	3,	9),
	(2,	'2019-07-17 09:19:12', '2019-07-10 12:19:12',	'2019-07-11 05:10:16',	4,	10),
	(2,	'2019-09-09 14:19:12', '2019-09-10 12:19:12',	'2019-09-12 05:10:16',	1,	11),
	(2,	'2019-08-03 11:19:12', '2019-08-10 12:19:12',	'2019-08-17 05:10:16',	2,	2);
GO

-- Insert data into the Document table
INSERT INTO Document VALUES
	('1120245688',	'2020-02-03','Documents/Document1.jpg',	1,	1),
	('1120976588',	'2021-06-03','Documents/Document2.jpg',	1,	2),
	('1120765432',	'2019-09-03','Documents/Document3.jpg',	1,	3),
	('1129876543',	'2019-12-03','Documents/Document4.jpg',	1,	4),
	('1120765949',	'2020-10-03','Documents/Document5.jpg',	1,	5),
	('2157755442',	'2025-12-03','Documents/Document6.jpg',	1,	6),
	('MW126534565',	'2026-01-03','Documents/Document7.jpg',	2,	7),
	('NHL12579087',	'2020-03-03','Documents/Document8.jpg',	2,	8),
	('XS1234567',	'2024-01-03','Documents/Document9.jpg',	3,	9),
	('31195855',	'2023-02-03','Documents/Document10.jpg',3, 10);
GO

-- Insert data into the Gate table
INSERT INTO Gate VALUES
	('Prince Bandar bin Sultan Gate',	'This gate is located behind the building',			'Use the stairs instead of the elevator', 'Documents/EvacuationPlan1.jpg'),
	('Gate Number 4',					'Gate 4 is located behind the building',			'Use the stairs instead of the elevator', 'Documents/EvacuationPlan2.jpg'),
	('Gate Number 1',					'Gate 1 is located in front of the the building',	'Use the stairs instead of the elevator', 'Documents/EvacuationPlan3.jpg'),
	('Gate Number 3',					'Gate 3 is located in the left side of the building','Use the stairs instead of the elevator', 'Documents/EvacuationPlan4.jpg');
GO

-- Insert data into the	Event table
INSERT INTO Event VALUES
	('Graduation Ceremony',	'2019-11-25 19:10:30',	'2019-11-27 22:00:00',	'The graduation ceremony of undergraduate students year 2018-2019'),
	('DAH Bazar',			'2019-12-29 10:00:30',	'2019-12-30 16:00:00',	'DAH Bazar happens yearly at Dar Al-Hekma University and takes place at the atrium and garden area'),
	('Library Day',			'2019-05-06 09:30:55',	'2019-05-06 16:00:05',	'An introductory day for library services takes place in the atrium'),
	('Fashion Show',		'2019-04-12 18:30:55',	'2019-04-12 21:00:05',	'The yearly fashion show of DAH fashion design graduate');
GO

-- Insert data into the	Badge table
INSERT INTO Badge VALUES
	('This is a note'),
	(NULL),
	('This visitor is VIP'),
	('If you find this badge, please return it to Lost and Found in the ground floor');
GO

-- Insert data into the	Agreement table
INSERT INTO Agreement VALUES
	('DAH Smoking Policy',	'Smoking is not allowed inside the campus',							'Documents/AgreementFile1.jpg',	1,	1),
	('DAH Clothes Policy',	'Dress appropriately. Short skirts and dresses are not allowed.',	'Documents/AgreementFile2.jpg',	1,	1),
	('DAH Places Policy',	'Labs and Red carpet area are not allowed to be entered',			'Documents/AgreementFile3.jpg',	0,	1),
	('DAH Library Policy',	'Food and drinks are not allowed inside the library',				'Documents/AgreementFile4.jpg',	0,	0);
GO

--Insert data into Message table
INSERT INTO Message VALUES
	(2, 'Please Clear The Campuse'),
	(2, 'This is a test MESSAGE'),
	(1 , N'الرجاء اخلاء المبنى'),
	(1 , N'هذه رسالة  تجربة ');
GO

-- Insert data into Delivery table
INSERT INTO Delivery VALUES
	('2018-10-30 12:10:30', '2018-10-30 12:30:00', 'Food Delivery', 3, 1, 2),
	('2018-11-01 10:00:04', '2018-11-01 11:45:09', 'Noon Delivery', 3, 2, 2),
	('2018-11-01 10:15:00', '2018-11-01 10:16:03', 'Book Delivery', 4, 3, 1),
	('2018-11-02 14:22:44', '2018-11-02 15:03:45', 'Food Delivery', 4, 4, 1);
GO

-- Insert data into the Visit table
INSERT INTO Visit  VALUES
	('2019-10-15 12:10:30',	'2019-10-21 15:00:40',	'The graduation ceremony of business school',	1,	1, 7,	2,	1,		NULL,	1,	1,	1,	2),
	('2019-10-15 12:10:31',	'2019-11-27 14:00:00',	NULL,											1,	2, 3,	2,	NULL,	NULL,	2,	2,	3,	2),
	('2019-12-29 10:15:30',	'2019-12-29 13:30:50',	NULL,											2,	1, 1,	2,	2,		NULL,	4,	3,	4,	2),
	('2019-11-25 11:10:30',	NULL,					NULL,											2,	2, 1,	1,	NULL,	1,		5,	2,	2,	2),
	('2019-12-29 10:15:30',	'2019-12-29 13:30:50',	NULL,											2,	2, 5,	1,	NULL,	4,		3,	4,	5,	1),
	('2019-10-29 15:15:30',	'2019-10-29 16:30:50',	NULL,											2,	2, 1,	1,	NULL,	NULL,	6,	2,	6,	1),
	('2019-10-12 10:12:30',	'2019-10-12 13:00:50',	NULL,											2,	2, 1,	1,	NULL,	2,		7,	2,	7,	1),
	('2019-10-13 11:25:30',	'2019-10-15 14:30:50',	NULL,											2,	2, 3,	1,	NULL,	NULL,	8,	2,	8,	1),
	('2019-10-07 10:08:30',	'2019-10-07 15:10:50',	NULL,											2,	2, 1,	1,	NULL,	3,		9,	3,	9,	2),
	('2019-10-01 10:15:30',	'2019-10-01 11:30:50',	NULL,											2,	2, 1,	1,	NULL,	NULL,	10,	2,	10,	2),
	('2019-10-05 12:15:30',	'2019-10-05 13:20:50',	NULL,											2,	2, 1,	1,	NULL,	NULL,	3,	2,	11,	2),
	('2019-10-09 09:15:30',	'2019-10-09 12:30:50',	NULL,											2,	2, 1,	1,	NULL,	NULL,	12,	4,	12,	1);
GO

-- Insert data into the	VisitAgreement table
INSERT INTO VisitAgreement VALUES
	(1,	1,	'Documents/SignatureFile1.jpg',	1,	1),
	(0,	0,	'Documents/SignatureFile2.jpg',	2,	2),
	(0,	0,	'Documents/SignatureFile3.jpg',	1,	3),
	(1,	0,	'Documents/SignatureFile4.jpg',	2,	4),
	(1,	0,	'Documents/SignatureFile5.jpg',	2,	5);
GO

-- Insert data into Notification Table
INSERT INTO Notification VALUES
	('2018-10-30 12:15:00', 1, 1, 1, 1, 1),
	('2018-11-01 10:05:09', 1, 3, 2, 2, 2),
	('2018-11-01 10:20:15', 2, 4, 3, 3, 3),
	('2018-11-02 14:26:08', 2, 2, 4, 4, 4);
GO