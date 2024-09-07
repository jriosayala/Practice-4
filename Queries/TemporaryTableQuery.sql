-- Create the temporary table
CREATE TABLE #SalesSummary (
   ProductID INT,
   ProductName VARCHAR(255),
   SalesStatus VARCHAR(255)
);

-- Insert data into the temporary table
INSERT INTO #SalesSummary (ProductID, ProductName, SalesStatus)
SELECT 
   p.ProductID,
   p.ProductName,
   CASE 
       WHEN SUM(s.QuantitySold) IS NULL THEN 'unsold product'
       ELSE 'number of sales: ' + CAST(SUM(s.QuantitySold) AS VARCHAR(50))
   END AS SalesStatus
FROM 
   Products p
LEFT JOIN 
   Sales s ON p.ProductID = s.ProductID
GROUP BY 
   p.ProductID, p.ProductName;

-- SELECT * FROM dbo.#SalesSummary
--DROP TABLE #SalesSummary;