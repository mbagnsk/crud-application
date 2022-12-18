USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 18.12.2022 11:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
	@ProductName nvarchar(100), 
	@ProductDescription nvarchar(100),
	@NetPrice numeric(13, 2),
	@GrossPrice numeric(13, 2),
	@PriceActiveFrom datetime,
	@PriceActiveTo datetime
AS
	INSERT INTO WarehouseManagerDB.dbo.PRODUCTS(ProductName, ProductDescription, NetPrice, GrossPrice, PriceActiveFrom, PriceActiveTo)
	VALUES(@ProductName, @ProductDescription, @NetPrice, @GrossPrice, @PriceActiveFrom, @PriceActiveTo)