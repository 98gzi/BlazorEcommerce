namespace Ecommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext DataContext;

        public CategoryService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var categories = await DataContext.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }
    }
}
