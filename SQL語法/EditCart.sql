DELIMITER //

#DROP PROCEDURE IF EXISTS usp_EditCart;
#加入/刪除購物車;

CREATE PROCEDURE usp_EditCart(IN CId int,IN PId int, IN Qua int,IN Status nvarchar(3) )
BEGIN
	IF Status = 'Add' Then
		INSERT INTO Cart(CustomerId,ProductId,Quantity)
		Values(CId,PId,Qua);
		
	END IF;

	IF Status = 'Del' Then
		DELETE FROM Cart
		where CustomerId = CId and ProductId = PId;
	END IF;
	
END //


DELIMITER ;
