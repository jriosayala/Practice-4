CREATE PROCEDURE AddProduct
    @ProductName VARCHAR(255),
    @Description VARCHAR(255),
    @Price DECIMAL(10, 2),
    @StockQuantity INT
AS
BEGIN
    INSERT INTO Products (ProductName, Description, Price, StockQuantity, ModifiedDate)
    VALUES (@ProductName, @Description, @Price, @StockQuantity, GETDATE());
END;