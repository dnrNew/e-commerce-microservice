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

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "ESHOP_2022_30",
                DiscountAmount = 30
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "ESHOP_2022_50",
                DiscountAmount = 50
            });
        }

    }
}
