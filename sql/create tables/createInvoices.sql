CREATE TABLE WarehouseManagerDB.dbo.INVOICES (
	IDInvoice NUMERIC NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDClient NUMERIC NOT NULL FOREIGN KEY REFERENCES WarehouseManagerDB.dbo.CUSTOMERS(IDClient),
	OrderDatetime DATETIME NOT NULL,
	DueDate DATE NOT NULL,
	PaymentDate DATE,
	PaymentAmount NUMERIC(13,2),
	OrderActive BIT NOT NULL
);