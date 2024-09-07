CREATE PROCEDURE GetProduct
    @ProductID INT
AS
BEGIN
    SELECT ProductID, ProductName, Description, Price, StockQuantity, ModifiedDate
    FROM Products
    WHERE ProductID = @ProductID;
END;
