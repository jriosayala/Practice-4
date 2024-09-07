CREATE PROCEDURE UpdateProduct
    @ProductID INT,
    @ProductName VARCHAR(255),
    @Description VARCHAR(255),
    @Price DECIMAL(10, 2),
    @StockQuantity INT
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Description = @Description,
        Price = @Price,
        StockQuantity = @StockQuantity,
        ModifiedDate = GETDATE()
    WHERE ProductID = @ProductID;
END;
