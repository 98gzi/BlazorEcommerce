namespace Ecommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext DataContext;

        public ProductService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await DataContext.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductListAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await DataContext.Products.Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryListAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await DataContext.Products.Where(product => product.Category.Url.ToLower() == categoryUrl).Include(p => p.Variants).ToListAsync()
            };
            return response;
        }
    }
}
