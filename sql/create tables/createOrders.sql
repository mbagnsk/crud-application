CREATE TABLE WarehouseManagerDB.dbo.ORDERS (
	IDInvoice NUMERIC NOT NULL FOREIGN KEY REFERENCES WarehouseManagerDB.dbo.INVOICES(IDInvoice),
	IDProduct NUMERIC NOT NULL FOREIGN KEY REFERENCES WarehouseManagerDB.dbo.PRODUCTS(IDProduct),
	Quantity NUMERIC NOT NULL
);