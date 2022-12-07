USE [WarehouseManagerDB]
USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[GetInvoices]    Script Date: 07.12.2022 21:59:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetInvoices]
AS
SELECT
	  [IDInvoice],
      [IDClient],
      [OrderDatetime],
      [DueDate],
      ISNULL([PaymentDate], '1900-01-01') AS 'PaymentDate',
      ISNULL([PaymentAmount], 0) AS 'PaymentAmount',
      [OrderActive] FROM [dbo].[INVOICES]