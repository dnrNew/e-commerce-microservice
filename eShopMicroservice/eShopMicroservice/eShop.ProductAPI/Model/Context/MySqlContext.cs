using Microsoft.EntityFrameworkCore;

namespace eShop.ProductAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product{
                Id = 2,
                Name = "Copo Mário",
                Price = 35.45M,
                Description = "Copo Mário ideal para tomar suco e refrigerante.",
                CategoryName = "Copos",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Glass_Mario.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Copo Mickey",
                Price = 20.00M,
                Description = "Copo Mickey ideal para tomar suco e refrigerante.",
                CategoryName = "Copos",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Glass_Mickey.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Mouse Pad Diablo",
                Price = 35.45M,
                Description = "Mouse Pad Gamer Diablo ideal para jogos.",
                CategoryName = "Mouse Pad",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Mouse_Pad_Diablo.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Mouse Pad Mortal Kombat",
                Price = 195.99M,
                Description = "Mouse Pad Gamer Mortal Kombat ideal para jogos.",
                CategoryName = "Mouse Pad",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Mouse_Pad_Mortal_Kombat.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Mouse Pad Sonic",
                Price = 89.00M,
                Description = "Mouse Pad Gamer Sonic ideal para jogos.",
                CategoryName = "Mouse Pad",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Mouse_Pad_Sonic.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Camisa Donkey Kong",
                Price = 18.99M,
                Description = "Camisa customizada Donkey Kong",
                CategoryName = "Camisas",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/T-Shirt_Donkey_Kong.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Camisa Gamer",
                Price = 15.45M,
                Description = "Camisa customizada Gamer",
                CategoryName = "Camisas",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/T-Shirt_Gamer.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Camisa Cavaleiro",
                Price = 115.45M,
                Description = "Camisa customizada Cavaleiro",
                CategoryName = "Camisas",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/T-Shirt_Cavaleiro.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Toalha Castlevania",
                Price = 87.56M,
                Description = "Tolha de Banho customizada Castlevania",
                CategoryName = "Tolhas",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Castlevania.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Toalha Gamer",
                Price = 89.45M,
                Description = "Tolha de Banho customizada Gamer",
                CategoryName = "Tolhas",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Gamer.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Toalha Naruto",
                Price = 135.99M,
                Description = "Tolha de Banho customizada Naruto",
                CategoryName = "Tolhas",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Naruto.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Toalha Popeye",
                Price = 250.99M,
                Description = "Tolha de Banho customizada Popeye",
                CategoryName = "Tolhas",
                ImageUrl = "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Popeye.jpg"
            });
        }
    }
}
