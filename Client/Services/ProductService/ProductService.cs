

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
    

        public async Task GetProducts()
        {
            var productsResult = await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");

            if (productsResult != null && productsResult.Data != null)
                Products = productsResult.Data;
        }
    }
}
