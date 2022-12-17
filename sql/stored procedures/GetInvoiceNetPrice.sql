USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[GetInvoices]    Script Date: 17.12.2022 17:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInvoiceNetPrice]
	@IDInvoice numeric
AS
select sum(c.GrossPrice * b.Quantity) 
from [WarehouseManagerDB].[dbo].[INVOICES] a
left join [WarehouseManagerDB].[dbo].[ORDERS] b on a.IDInvoice = b.IDInvoice
left join [WarehouseManagerDB].[dbo].[PRODUCTS] c on b.IDProduct = c.IDProduct
where a.OrderDatetime > c.PriceActiveFrom and a.OrderDatetime < c.PriceActiveTo and a.IDInvoice = @IDInvoice;