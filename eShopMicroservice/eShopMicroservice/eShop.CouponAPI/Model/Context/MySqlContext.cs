using Microsoft.EntityFrameworkCore;

namespace eShop.CouponAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; }
                
    }
}
