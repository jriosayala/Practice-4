public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int productId);
}