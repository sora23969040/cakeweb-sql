DELIMITER //

/*#DROP PROCEDURE IF EXISTS usp_Shipping;*/

CREATE PROCEDURE usp_Shipping (IN SId int,IN OId int,IN SMethod varchar(100),IN TrackNumber varchar(100),IN SCost decimal(18,2),
							   IN SDate datetime,IN DDate datetime,IN SStatus varchar(50), IN Status varchar(3))
BEGIN
	
	IF Status = 'Add' THEN
	INSERT INTO Shipping(OrderId,ShippingMethod,TrackingNumber,ShppingCost,ShippedDate,ShippingStatus,CreatedAt)
	VALUES(OId,SMethod,TrackNumber,SCost,SDate,'已付款未寄送',DATE_ADD(NOW(), INTERVAL 8 HOUR));
	
	END IF;

	IF Status = 'Upd' THEN
	
	UPDATE Shipping 
	SET TrackingNumber = TrackNumber,DeliveredDate =DDate ,ShippingStatus =SStatus,UpdatedAt =DATE_ADD(NOW(), INTERVAL 8 HOUR)
	where ShippingId =SId;

	END IF;

	IF Status = 'Del' THEN
	
	UPDATE Shipping 
	SET ShippingStatus ='取消'
	where ShippingId = SId;

	END IF;

END //


DELIMITER ;