if not exists (
	select
		*
	from
		sysobjects
	where
		name = 'Users'
		and xtype = 'U'
) create table Users (
	ID uniqueidentifier PRIMARY KEY,
	UserName nvarchar(100) NOT NULL,
	PasswordHash nvarchar(max) NOT NULL,
	LastUpdateDate DATETIME NOT NULL,
	Ordering INT IDENTITY(1, 1) NOT NULL
) IF NOT EXISTS(
	SELECT
		*
	FROM
		sys.indexes
	WHERE
		name = 'Users_Ordering'
		AND object_id = OBJECT_ID('Users')
) BEGIN CREATE UNIQUE INDEX Users_Ordering ON Users (Ordering);

CREATE UNIQUE INDEX Users_UserName ON Users (UserName);
END


GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'Deliveries'
			AND xtype = 'U'
	) CREATE TABLE Deliveries (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[Date] DATETIME NOT NULL,
		[DistributorID] UNIQUEIDENTIFIER,
		[DistributorFullName] NVARCHAR(100),		
		[DistributorMobileNumber] NVARCHAR(100),		
		[DistributorEmail] NVARCHAR(200),		
		[DistributorCompanyName] NVARCHAR(200),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'Deliveries_Ordering'
			AND object_id = OBJECT_ID('Deliveries')
	) BEGIN CREATE UNIQUE INDEX Deliveries_Ordering ON Deliveries (Ordering);
END

GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'DeliveryProducts'
			AND xtype = 'U'
	) CREATE TABLE DeliveryProducts (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[DeliveryID] uniqueidentifier NOT NULL,
		[Name] NVARCHAR(MAX),		
		[Code] NVARCHAR(100),		
		[Description] NVARCHAR(MAX),		
		[DefaultPrice] decimal(9, 2),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
		FOREIGN KEY ([DeliveryID]) REFERENCES Deliveries(ID),
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'DeliveryProducts_Ordering'
			AND object_id = OBJECT_ID('DeliveryProducts')
	) BEGIN CREATE UNIQUE INDEX DeliveryProducts_Ordering ON DeliveryProducts (Ordering);
END

GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'Distributors'
			AND xtype = 'U'
	) CREATE TABLE Distributors (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[FullName] NVARCHAR(100),		
		[MobileNumber] NVARCHAR(100),	
		[Email] NVARCHAR(200),		
		[CompanyName] NVARCHAR(200),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'Distributors_Ordering'
			AND object_id = OBJECT_ID('Distributors')
	) BEGIN CREATE UNIQUE INDEX Distributors_Ordering ON Distributors (Ordering);
END

GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'Doctors'
			AND xtype = 'U'
	) CREATE TABLE Doctors (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[FullName] NVARCHAR(100),		
		[MobileNumber] NVARCHAR(100),		
		[PersonalNumber] NVARCHAR(200),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'Doctors_Ordering'
			AND object_id = OBJECT_ID('Doctors')
	) BEGIN CREATE UNIQUE INDEX Doctors_Ordering ON Doctors (Ordering);
END

GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'Pickings'
			AND xtype = 'U'
	) CREATE TABLE Pickings (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[Date] DATETIME NOT NULL,
		[DoctorID] UNIQUEIDENTIFIER,
		[DoctorFullName] NVARCHAR(100),		
		[DoctorMobileNumber] NVARCHAR(100),		
		[DoctorPersonalNumber] NVARCHAR(20),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'Pickings_Ordering'
			AND object_id = OBJECT_ID('Pickings')
	) BEGIN CREATE UNIQUE INDEX Pickings_Ordering ON Pickings (Ordering);
END

GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'PickingProducts'
			AND xtype = 'U'
	) CREATE TABLE PickingProducts (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[PickingID] uniqueidentifier NOT NULL,
		[Name] NVARCHAR(MAX),		
		[Code] NVARCHAR(100),		
		[Description] NVARCHAR(MAX),		
		[DefaultPrice] decimal(9, 2),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
		FOREIGN KEY ([PickingID]) REFERENCES Pickings(ID),
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'PickingProducts_Ordering'
			AND object_id = OBJECT_ID('PickingProducts')
	) BEGIN CREATE UNIQUE INDEX PickingProducts_Ordering ON PickingProducts (Ordering);
END

GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'Products'
			AND xtype = 'U'
	) CREATE TABLE Products (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[Name] NVARCHAR(MAX),		
		[Code] NVARCHAR(100),		
		[Description] NVARCHAR(MAX),		
		[DefaultPrice] decimal(9, 2),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'Products_Ordering'
			AND object_id = OBJECT_ID('Products')
	) BEGIN CREATE UNIQUE INDEX Products_Ordering ON Products (Ordering);
END

GO
	IF not exists (
		SELECT
			*
		FROM
			sysobjects
		WHERE
			NAME = 'Remainings'
			AND xtype = 'U'
	) CREATE TABLE Remainings (
		[ID] UNIQUEIDENTIFIER PRIMARY KEY,
		[ProductID] UNIQUEIDENTIFIER,
		[Name] NVARCHAR(MAX),		
		[Code] NVARCHAR(100),		
		[Description] NVARCHAR(MAX),		
		[Amount] decimal(9, 2),		
		[LastUpdateDate] DATETIME NOT NULL,
		[Ordering] INT IDENTITY(1, 1) NOT NULL
	) IF NOT EXISTS(
		SELECT
			*
		FROM
			sys.indexes
		WHERE
			name = 'Remainings_Ordering'
			AND object_id = OBJECT_ID('Remainings')
	) BEGIN CREATE UNIQUE INDEX Remainings_Ordering ON Remainings (Ordering);
END

--MIGRATIONS
GO
	-- ADD ProductID field FOR DeliveryProducts
	IF NOT EXISTS (
		SELECT
			*
		FROM
			sys.columns
		WHERE
			object_id = OBJECT_ID(N'[dbo].[DeliveryProducts]')
			AND name = 'ProductID'
	) BEGIN
ALTER TABLE
	DeliveryProducts
ADD
	ProductID UNIQUEIDENTIFIER,
	FOREIGN KEY (ProductID) REFERENCES Products(ID);
END


GO
	-- ADD  fields FOR DeliveryProducts
	IF NOT EXISTS (
		SELECT
			*
		FROM
			sys.columns
		WHERE
			object_id = OBJECT_ID(N'[dbo].[DeliveryProducts]')
			AND name = 'Price'
	) BEGIN
ALTER TABLE
	DeliveryProducts
ADD
	Price decimal(9, 2),		
	Unit nvarchar(300),
	Quantity decimal(9, 2)
END