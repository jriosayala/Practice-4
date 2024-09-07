CREATE VIEW SoldAndPurchasedProducts AS
SELECT 
   'Sale' AS TransactionType,
   s.SaleID AS TransactionID,
   p.ProductID,
   p.ProductName,
   p.Description,
   s.SaleDate AS TransactionDate,
   s.QuantitySold AS Quantity,
   s.SalePrice AS Price
FROM 
   Sales s
JOIN 
   Products p ON s.ProductID = p.ProductID

UNION ALL

SELECT 
   'Purchase' AS TransactionType,
   pu.PurchaseID AS TransactionID,
   p.ProductID,
   p.ProductName,
   p.Description,
   pu.PurchaseDate AS TransactionDate,
   pu.QuantityPurchased AS Quantity,
   pu.PurchasePrice AS Price
FROM 
   Purchases pu
JOIN 
   Products p ON pu.ProductID = p.ProductID;