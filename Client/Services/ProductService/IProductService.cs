namespace Ecommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanges;
        List<Product> Products { get; set; }
        Task GetProducts(string? categoryUrl);
        Task<ServiceResponse<Product>> GetProduct(int productId);

    }
}
