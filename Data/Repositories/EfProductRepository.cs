namespace Practice_4.Data.Repositories;
public class EfProductRepository(AppDbContext context) : IProductRepository
{
    public IEnumerable<Product> GetAllProducts()
    {
        return [.. context.Products];
    }

    public void AddProduct(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        context.Products.Update(product);
        context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var product = context.Products.Find(productId);
        if (product != null)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
