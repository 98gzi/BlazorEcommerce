using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public DataContext DataContext { get; }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var prodcts = await DataContext.Products.ToListAsync();
            return Ok(prodcts);
        }
    }
}
