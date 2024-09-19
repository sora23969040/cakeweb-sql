DELIMITER //

#DROP PROCEDURE IF EXISTS usp_GetProductDescription;

CREATE PROCEDURE usp_GetProductDescription (IN Id varchar(100))
BEGIN
	SELECT ProductId,ProductName,Price,StockQuantity,Description
	From Products
	where ProductId = Id;
	
END //


DELIMITER ;
