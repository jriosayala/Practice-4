using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        var productRepository = new ProductRepository(context);

        while (true)
        {
            Console.WriteLine("Please type in the number of the activity to be performed:");
            Console.WriteLine("Press the 1 key to get the data from the products table.");
            Console.WriteLine("Press the 2 key to request the creation of a new product.");
            Console.WriteLine("Press the 3 key to filter the information by text or ID from the product table.");
            Console.WriteLine("Press the 4 key to group the sales by day and sort them by sales number from highest to lowest.");
            Console.WriteLine("Press the 5 key to get the product and sales information for the month using line joins.");
            Console.WriteLine("Press the 6 key to get products with no sales or purchases.");
            Console.WriteLine("Press the 7 key to perform the sum of the products sold in the month.");
            Console.WriteLine("Press the 0 key to exit.");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var products = productRepository.GetAllProducts();
                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.ProductID}: {product.ProductName} - {product.Description} - {product.Price} - {product.StockQuantity}");
                    }
                    break;

                case "2":
                    Console.WriteLine("Enter Product Name:");
                    var productName = Console.ReadLine();
                    Console.WriteLine("Enter Description:");
                    var description = Console.ReadLine();
                    Console.WriteLine("Enter Price:");
                    var price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Stock Quantity:");
                    var stockQuantity = int.Parse(Console.ReadLine());

                    var newProduct = new Product
                    {
                        ProductName = productName,
                        Description = description,
                        Price = price,
                        StockQuantity = stockQuantity,
                        ModifiedDate = DateTime.Now
                    };

                    productRepository.AddProduct(newProduct);
                    Console.WriteLine("Product added successfully.");
                    break;

                case "3":
                    Console.WriteLine("Enter text or ID to filter:");
                    var searchText = Console.ReadLine();
                    var filteredProducts = productRepository.FilterProducts(searchText);
                    foreach (var product in filteredProducts)
                    {
                        Console.WriteLine($"{product.ProductID}: {product.ProductName} - {product.Description} - {product.Price} - {product.StockQuantity}");
                    }
                    break;

                case "4":
                    Console.WriteLine("Enter start date (yyyy-MM-dd):");
                    var startDateInput = Console.ReadLine();
                    Console.WriteLine("Enter end date (yyyy-MM-dd):");
                    var endDateInput = Console.ReadLine();
                    if (DateTime.TryParseExact(startDateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate) &&
                    DateTime.TryParseExact(endDateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                    {
                        var groupedSales = productRepository.GroupSalesByDay(startDate, endDate);
                        foreach (var group in groupedSales)
                        {
                            Console.WriteLine($"{group.Key}: {group.Sum(s => s.QuantitySold)} sales");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please use yyyy-MM-dd");
                    }
                    break;

                case "5":
                    Console.WriteLine("Enter month (1-12):");
                    var month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter year:");
                    var year = int.Parse(Console.ReadLine());
                    var productSalesInfo = productRepository.GetProductAndSalesInfoForMonth(month, year);
                    foreach (var info in productSalesInfo)
                    {
                        Console.WriteLine($"{info.ProductName} - {info.QuantitySold} sold on {info.SaleDate}");
                    }
                    break;

                case "6":
                    var unsoldProducts = productRepository.GetProductsWithNoSalesOrPurchases();
                    foreach (var product in unsoldProducts)
                    {
                        Console.WriteLine($"{product.ProductID}: {product.ProductName} - {product.Description} - {product.Price} - {product.StockQuantity}");
                    }
                    break;

                case "7":
                    Console.WriteLine("Enter month (1-12):");
                    month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter year:");
                    year = int.Parse(Console.ReadLine());
                    var totalSold = productRepository.GetSumOfProductsSoldInMonth(month, year);
                    Console.WriteLine($"Total products sold in {month}/{year}: {totalSold}");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
