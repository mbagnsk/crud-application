USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[AddOrder]    Script Date: 05.12.2022 20:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddOrder]
	@IDInvoice numeric,
	@IDProduct numeric,
	@Quantity numeric
AS

INSERT INTO [WarehouseManagerDB].[dbo].[ORDERS]
VALUES(@IDInvoice, @IDProduct, @Quantity)