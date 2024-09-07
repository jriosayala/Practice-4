public class ProductRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public IEnumerable<Product> GetAllProducts()
    {
        return [.. _context.Products];
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public IEnumerable<Product> FilterProducts(string searchText)
    {
        return [.. _context.Products.Where(p => p.ProductName.Contains(searchText) || p.ProductID.ToString() == searchText)];
    }

    public IEnumerable<IGrouping<DateTime, Sale>> GroupSalesByDay(DateTime startDate, DateTime endDate)
    {
        return [.. _context.Sales
            .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
            .AsEnumerable() // Switch to client-side evaluation as suggested
            .GroupBy(s => s.SaleDate.Date)
            .OrderByDescending(g => g.Sum(s => s.QuantitySold))
            .ToList()];
    }

    public IEnumerable<ProductSalesInfo> GetProductAndSalesInfoForMonth(int month, int year)
    {
        return _context.Sales
            .Where(s => s.SaleDate.Month == month && s.SaleDate.Year == year)
            .Join(_context.Products, s => s.ProductID, p => p.ProductID, (s, p) => new ProductSalesInfo {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                SaleDate = s.SaleDate,
                QuantitySold = s.QuantitySold,
                SalePrice = s.SalePrice
            })
            .ToList();
    }

    public IEnumerable<Product> GetProductsWithNoSalesOrPurchases()
    {
        var productsWithSales = _context.Sales.Select(s => s.ProductID).Distinct();
        var productsWithPurchases = _context.Purchases.Select(p => p.ProductID).Distinct();
        var productIds = productsWithSales.Union(productsWithPurchases);

        return [.. _context.Products.Where(p => !productIds.Contains(p.ProductID))];
    }

    public int GetSumOfProductsSoldInMonth(int month, int year)
    {
        return _context.Sales
            .Where(s => s.SaleDate.Month == month && s.SaleDate.Year == year)
            .Sum(s => s.QuantitySold);
    }
}
