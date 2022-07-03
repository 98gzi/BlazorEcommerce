namespace Ecommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductListAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategoryListAsync(string categoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProduct(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
    }
}
