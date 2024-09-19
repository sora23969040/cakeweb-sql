DELIMITER //

#DROP PROCEDURE IF EXISTS usp_EditCustomers;

CREATE PROCEDURE usp_EditCustomers(IN I_FName varchar(50),IN I_LName varchar(50),IN I_Email varchar(100),IN I_Phone varchar(15)
								  ,IN I_Address varchar(200),IN I_City varchar(100),IN I_Country varchar(100),IN CId int)

BEGIN
	
	UPDATE Customers 
	SET FirstName = I_FName,
		LastName = I_LName,
		Email = I_Email,
		Phone = I_phone,
		Address= I_Address,
		City = I_City,
		Country = I_Country
	WHERE CustomerId = CId;


END //


DELIMITER ;