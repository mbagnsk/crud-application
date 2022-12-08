USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[GetInvoices]    Script Date: 08.12.2022 19:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInvoices]
AS
SELECT
	  a.[IDInvoice],
      a.[IDClient],
	  b.[Company],
      a.[OrderDatetime],
      a.[DueDate],
      ISNULL(a.[PaymentDate], '1900-01-01') AS 'PaymentDate',
      ISNULL(a.[PaymentAmount], 0) AS 'PaymentAmount',
      a.[OrderActive] FROM [dbo].[INVOICES] a
	  LEFT JOIN [dbo].[CUSTOMERS] b
	  ON a.IDClient = b.IDClient;