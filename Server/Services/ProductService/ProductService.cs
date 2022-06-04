namespace Ecommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext DataContext;

        public ProductService(DataContext dataContext)
        {
            DataContext = dataContext;
        }


        public async Task<ServiceResponse<List<Product>>> GetProductListAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await DataContext.Products.ToListAsync()
            };
            return response;
        }
    }
}
