INSERT INTO Products (ProductID, ProductName, Description, Price, StockQuantity)
VALUES (1, 'dotNet full master course','Master C# skills with this course', 19.99, 100);

UPDATE dbo.Product SET Price = 24.99 WHERE ProductID = 1

INSERT INTO Products (ProductID, ProductName, Description, Price, StockQuantity, ModifiedDate)
VALUES
(2, 'Wireless Mouse', 'Ergonomic wireless mouse with adjustable DPI settings', 25.99, 150, GETDATE()),
(3, 'Mechanical Keyboard', 'RGB backlit mechanical keyboard with blue switches', 89.99, 200, GETDATE()),
(4, 'Gaming Monitor', '27-inch 144Hz gaming monitor with 1ms response time', 299.99, 50, GETDATE()),
(5, 'External Hard Drive', '1TB USB 3.0 external hard drive', 59.99, 300, GETDATE()),
(6, 'Bluetooth Speaker', 'Portable Bluetooth speaker with 12-hour battery life', 45.99, 120, GETDATE()),
(7, 'Smartphone', 'Latest model smartphone with 128GB storage and 5G connectivity', 699.99, 80, GETDATE()),
(8, 'Laptop', '15.6-inch laptop with Intel i7 processor and 16GB RAM', 999.99, 40, GETDATE()),
(9, 'Wireless Earbuds', 'Noise-cancelling wireless earbuds with charging case', 129.99, 250, GETDATE()),
(10, 'Smartwatch', 'Smartwatch with heart rate monitor and GPS', 199.99, 150, GETDATE()),
(11, 'Tablet', '10-inch tablet with 64GB storage and stylus support', 329.99, 70, GETDATE());
(10, 'Product I', 'Description for Product I', 109.99, 550, GETDATE());

CREATE TRIGGER trg_UpdateModifiedDate
ON Products
AFTER UPDATE
AS
BEGIN
   SET NOCOUNT ON;
    UPDATE Products
    SET ModifiedDate = GETDATE()
    FROM Products
    INNER JOIN inserted ON Products.ProductID = inserted.ProductID;
END;
