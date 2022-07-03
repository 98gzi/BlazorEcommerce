

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
        public string Message { get; set; } = "Loading Product...";

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

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await HttpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchSuggestions/{searchText}");

            return result.Data;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            if (Products.Count == 0)
            {
                Message = "No products found.";
            }

            ProductsChanges.Invoke();
        }
    }
}
