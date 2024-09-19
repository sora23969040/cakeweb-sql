DELIMITER //

#DROP PROCEDURE IF EXISTS usp_GetOrderDetail;

CREATE PROCEDURE usp_GetOrderDetail(IN PId int,IN Status varchar(50))

BEGIN
	
	SELECT o.OrderId,oi.ProductId ,oi.Quantity ,oi.UnitPrice ,oi.TotalPrice,o.OrderDate,o.ShipDate,o.ShippingAddress,o.OrderStatus 
	FROM Orders o left join OrderItems oi on o.OrderId = oi.OrderId 
	WHERE oi.ProductId =PId and (Status = '' or  o.OrderStatus = Status);
	
	
END //


DELIMITER ;