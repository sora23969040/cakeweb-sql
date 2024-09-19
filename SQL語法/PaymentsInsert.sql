DELIMITER //

/*#DROP PROCEDURE IF EXISTS usp_PaymentsInsert;*/

CREATE PROCEDURE usp_PaymentsInsert (IN OId int,IN PAmount decimal(18,2),IN PMethod varchar(50))
BEGIN
	INSERT INTO Payment(OrderId,PaymentDate,PaymentAmount,PaymentMethod,PaymentStatus,CreatedAt)
	VALUES(OrderID,DATE_ADD(NOW(), INTERVAL 8 HOUR),PAmount,PMethod,"",DATE_ADD(NOW(), INTERVAL 8 HOUR));
	
END //


DELIMITER ;
