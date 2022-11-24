CREATE PROCEDURE AddClient
	@Company nvarchar(100), 
	@Nip numeric,
	@Street nvarchar(50),
	@BuildingNubmer numeric,
	@LocalNumber numeric,
	@City nvarchar(50),
	@ZIPCode nvarchar(6),
	@Email nvarchar(50),
	@PhoneNumber numeric
AS
INSERT INTO WarehouseManagerDB.dbo.Customers (Company, Nip, Street, BuildingNumber, LocalNumber, City, ZIPCode, Email, PhoneNumber)
VALUES(@Company, @Nip, @Street, @BuildingNumber, @LocalNumber, @City, @ZIPCode, @Email, @PhoneNumber)
GO

--execute WarehouseManagerDB.dbo.AddClient @Company = 'Politechnika Wrocławska', @Nip = 8960005851, @Street = 'wybrzeże Wyspiańskiego' , @BuildingNumer = 27, 
--@LocalNumber = NULL, @City = 'Wrocław', @ZIPCode = '50-370', @Email = 'pwr@pwr.edu.pl', @PhoneNumber = 48713202905;

--execute WarehouseManagerDB.dbo.AddClient @Company = 'Makro', @Nip = 5220002860, @Street = 'Al. Krakowska' , @Buildi--ngNumer = 61, 
--@LocalNumber = 1, @City = 'Warszawa', @ZIPCode = '02-183', @Email = 'makro@makro.edu.pl', @PhoneNumber = 487012775559;