namespace Practice_4.Data.Repositories;
using System.Data;
using Microsoft.Data.SqlClient;

public class AdoProductRepository(string connectionString) : IProductRepository
{
    private readonly string _connectionString = connectionString;

    public IEnumerable<Product> GetAllProducts()
    {
        var products = new List<Product>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using var command = new SqlCommand("GetProducts", connection);
            command.CommandType = CommandType.StoredProcedure;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    Description = (string)reader["Description"],
                    Price = (decimal)reader["Price"],
                    StockQuantity = (int)reader["StockQuantity"],
                    ModifiedDate = (DateTime)reader["ModifiedDate"]
                });
            }
        }
        return products;
    }

    public void AddProduct(Product product)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("AddProduct", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ProductName", product.ProductName);
        command.Parameters.AddWithValue("@Description", product.Description);
        command.Parameters.AddWithValue("@Price", product.Price);
        command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
        command.ExecuteNonQuery();
    }

    public void UpdateProduct(Product product)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("UpdateProduct", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ProductID", product.ProductID);
        command.Parameters.AddWithValue("@ProductName", product.ProductName);
        command.Parameters.AddWithValue("@Description", product.Description);
        command.Parameters.AddWithValue("@Price", product.Price);
        command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
        command.ExecuteNonQuery();
    }

    public void DeleteProduct(int productId)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("DeleteProduct", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ProductID", productId);
        command.ExecuteNonQuery();
    }
}
