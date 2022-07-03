namespace Ecommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient HttpClient;

        public CategoryService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var response = await HttpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if(response != null && response.Data != null)
            {
                Categories = response.Data;
            }

        }
    }
}
