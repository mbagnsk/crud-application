USE [WarehouseManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[AddInvoice]    Script Date: 04.12.2022 21:49:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddInvoice]
	@IDClient numeric,
	@OrderDatetime datetime
AS

DECLARE	@IDInvoice numeric
DECLARE	@DueDate datetime
DECLARE	@PaymentDate datetime
DECLARE	@PaymentAmount numeric
DECLARE	@OrderActive bit


set @DueDate = DATEADD(DAY, 31, @OrderDatetime)
set @PaymentDate = 0
set @PaymentAmount = 0
set @OrderActive = 1

INSERT INTO [dbo].INVOICES([IDClient],[OrderDatetime], [DueDate], [PaymentDate], [PaymentAmount], [OrderActive])
VALUES (@IDClient, @OrderDatetime, @DueDate, @PaymentDate, @PaymentAmount, @OrderActive)

set @IDInvoice = @@IDENTITY
return @IDInvoice