USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[GetInvoices]    Script Date: 07.12.2022 23:41:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInvoices]
AS
SELECT * FROM [dbo].[INVOICES]