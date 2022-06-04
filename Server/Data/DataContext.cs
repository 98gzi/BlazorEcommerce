namespace Ecommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "In Search of Lost Time by Marcel Proust",
                Description = "Swann's Way, the first part of A la recherche de temps perdu, Marcel Proust's seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work.",
                ImageUrl = "https://d3i5mgdwi2ze58.cloudfront.net/7hqv6ddaqv363p4hadx6lymotow1",
                Price = 9.99m
            },
            new Product
            {
                Id = 2,
                Title = "Don Quixote by Miguel de Cervantes",
                Description = "Alonso Quixano, a retired country gentleman in his fifties, lives in an unnamed section of La Mancha with his niece and a housekeeper.",
                ImageUrl = "https://d3i5mgdwi2ze58.cloudfront.net/821hrmad01r9sdml2g2mmnbyykfk",
                Price = 7.99m
            },
            new Product
            {
                Id = 3,
                Title = "One Hundred Years of Solitude by Gabriel Garcia Marquez",
                Description = "One of the 20th century's enduring works, One Hundred Years of Solitude is a widely beloved and acclaimed novel known throughout the world, and the ultimate achievement in a Nobel Prize–winning car.",
                ImageUrl = "https://d3i5mgdwi2ze58.cloudfront.net/j7koelfcv0va5zky4x1ccmpsgcsb",
                Price = 8.99m
            });
        }
        public DbSet<Product> Products { get; set; }
    }
}
