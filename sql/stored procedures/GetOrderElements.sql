USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[GetOrderElements]    Script Date: 17.12.2022 20:00:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderElements]
	@IDInvoice numeric
AS
select 
	b.IDProduct,
	c.ProductName,
	c.ProductDescription,
	c.NetPrice,
	c.GrossPrice,
	b.Quantity
	from [WarehouseManagerDB].[dbo].[INVOICES] a	
	left join [WarehouseManagerDB].[dbo].[ORDERS] b on a.IDInvoice = b.IDInvoice
	left join [WarehouseManagerDB].[dbo].[PRODUCTS] c on b.IDProduct = c.IDProduct
	where a.IDInvoice = @IDInvoice;
