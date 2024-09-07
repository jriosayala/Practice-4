-- Create the Purchases table
CREATE TABLE Purchases (
   PurchaseID INT PRIMARY KEY,
   ProductID INT,
   PurchaseDate DATE,
   QuantityPurchased INT,
   PurchasePrice DECIMAL(10, 2),
   FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Insert 10 records into the Purchases table
INSERT INTO Purchases (PurchaseID, ProductID, PurchaseDate, QuantityPurchased, PurchasePrice)
VALUES
(1, 2, '2024-09-01', 20, 25.99),
(2, 3, '2024-09-02', 15, 35.99),
(3, 4, '2024-09-03', 18, 45.99),
(4, 5, '2024-09-04', 22, 55.99),
(5, 6, '2024-09-05', 30, 65.99),
(6, 7, '2024-09-06', 25, 75.99),
(7, 2, '2024-09-07', 17, 25.99),
(8, 3, '2024-09-08', 19, 35.99),
(9, 4, '2024-09-09', 21, 45.99),
(10, 5, '2024-09-10', 23, 55.99);