CREATE TABLE PRODUCTS (
	IDProduct NUMERIC NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ProductName VARCHAR(100) NOT NULL,
	ProductDescription VARCHAR(100),
	NetPrice NUMERIC(13,2) NOT NULL,
	GrossPrice NUMERIC(13,2) NOT NULL,
	PriceActiveFrom DATETIME NOT NULL,
	PriceActiveTo DATETIME NOT NULL
);