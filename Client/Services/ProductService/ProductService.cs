

namespace Ecommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient HttpClient;

        public ProductService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public List<Product> Products { get; set; } = new();

        public event Action ProductsChanges;

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var productsResult = await HttpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");

            return productsResult;
        }

        public async Task GetProducts(string? categoryUrl)
        {
            var result = categoryUrl == null ? 
                await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
                await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");


            if (result != null && result.Data != null)
                Products = result.Data;

            ProductsChanges.Invoke();
        }
    }
}
