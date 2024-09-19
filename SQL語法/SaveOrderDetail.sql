DELIMITER //

/*#DROP PROCEDURE IF EXISTS usp_SaveOrderDetail;*/

CREATE PROCEDURE usp_SaveOrderDetail (IN CId int,
									  IN shipdate datetime,
									  IN Address varchar(200),
									  IN Amount decimal(18,2))
BEGIN
	INSERT INTO Orders(CustomerId,OrderDate,ShipDate,ShippingAddress,TotalAmount,OrderStatus,CreatedAt)
	VALUES(CId,DATE_ADD(NOW(), INTERVAL 8 HOUR),shipdate,Address,Amount,"",DATE_ADD(NOW(), INTERVAL 8 HOUR));
	
	/*取得最新一筆的自增值(AUTO_INCREMENT)*/
	SET @newestID = LAST_INSERT_ID();
	
	Insert Into OrderItems(OrderId,ProductId,Quantity,UnitPrice,TotalPrice)
	Select @newestID,ProductId,Quantity,Price, Quantity  * Price
	FROM Cart C left join Products P on C.ProductId = P.ProductId 
	where C.CustomerId  = CId;

	DELETE FROM Cart
	where CustomerId = CId;
 
	
	
END //


DELIMITER ;


