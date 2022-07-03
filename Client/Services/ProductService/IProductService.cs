namespace Ecommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanges;
        List<Product> Products { get; set; }
        string Message { get; set; }
        Task GetProducts(string? categoryUrl);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
