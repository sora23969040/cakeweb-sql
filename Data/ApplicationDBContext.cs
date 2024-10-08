using web_cake.Models;
using Microsoft.EntityFrameworkCore;
namespace web_cake.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<ProductsInsert> ProductsInsert { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 設置主鍵
            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductId);  // 假設 ProductId 是主鍵

            modelBuilder.Entity<Result>()
                .HasKey(p => p.result);


            modelBuilder.Entity<Cart>()
                .HasKey(p => p.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<List<Products>> GetProductsAsync(string category)
        {
            return await Products.FromSqlRaw("CALL usp_GetProduct(@p0)",category).ToListAsync();
        }

        public async Task<List<Cart>> EditCart(string status,int CustomerId,int ProductId,int Quantity)
        {
            return await Carts.FromSqlRaw("CALL usp_EditCart(@p0,@p1,@p2,@p3)", CustomerId, ProductId, Quantity, status).ToListAsync();
        }

        public async Task<List<Cart>> GetCart(int Quantity)
        {
            return await Carts.FromSqlRaw("CALL usp_GetCart(@p0)", Quantity).ToListAsync();
        }

        public async Task<List<Cart>> EditProduct(string ProductName,string Category,decimal Price,int StockQuantity, string Descreption)
        {
            return await Carts.FromSqlRaw("CALL usp_EditProduct(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)", "Add",0,ProductName,Category,Price,StockQuantity,Descreption,1).ToListAsync();
        }
    }
}
