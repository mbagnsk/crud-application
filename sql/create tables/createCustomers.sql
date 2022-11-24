CREATE TABLE CUSTOMERS (
    IDCustomer numeric NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Company VARCHAR(100) NOT NULL,
	Nip numeric NOT NULL UNIQUE,
	Street VARCHAR(50) NOT NULL,
	BuildingNumber numeric NOT NULL,
	LocalNumber numeric,
	City VARCHAR(50) NOT NULL,
	ZIPCode VARCHAR(6) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	PhoneNumber numeric  NOT NULL
);