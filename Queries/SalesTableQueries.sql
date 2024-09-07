CREATE TABLE Sales (
   SaleID INT PRIMARY KEY,
   ProductID INT,
   SaleDate DATE,
   QuantitySold INT,
   SalePrice DECIMAL(10, 2),
   FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

INSERT INTO Sales (SaleID, ProductID, SaleDate, QuantitySold, SalePrice)
VALUES
(1, 2, '2024-10-01', 10, 29.99),
(2, 3, '2024-10-02', 5, 39.99),
(3, 4, '2024-10-03', 8, 49.99),
(4, 5, '2024-10-04', 12, 59.99),
(5, 2, '2024-10-05', 7, 29.99),
(6, 3, '2024-10-06', 9, 39.99),
(7, 4, '2024-10-07', 6, 49.99),
(8, 5, '2024-10-08', 11, 59.99),
(9, 2, '2024-10-09', 4, 29.99),
(10, 3, '2024-10-10', 3, 39.99);