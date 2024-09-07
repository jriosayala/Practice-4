SELECT 
    pu.PurchaseID,
    pu.ProductID,
    p.ProductName,
    pu.PurchaseDate,
    pu.QuantityPurchased,
    pu.PurchasePrice
FROM 
    Purchases pu
JOIN 
    Products p ON pu.ProductID = p.ProductID
WHERE 
    p.ProductName LIKE 'L%';
