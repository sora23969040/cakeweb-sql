DELIMITER //

#DROP PROCEDURE IF EXISTS usp_GetProduct;

CREATE PROCEDURE usp_GetProduct (IN categoryIn varchar(100))
BEGIN
	
	SELECT ProductId,ProductName,Category,Price,StockQuantity
	FROM Products 
	where (categoryIn = '' OR Category = categoryIn) AND ProductStatus = 1 /*未輸入類別時帶出全部資料*/
	Order by CreatedAt;
	
END //


DELIMITER ;
 