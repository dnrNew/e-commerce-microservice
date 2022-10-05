using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.ProductAPI.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "product",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product",
                type: "varchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 2L, "Copos", "Copo Mário ideal para tomar suco e refrigerante.", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Glass_Mario.jpg", "Copo Mário", 35.45m },
                    { 3L, "Copos", "Copo Mickey ideal para tomar suco e refrigerante.", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Glass_Mickey.jpg", "Copo Mickey", 20.00m },
                    { 4L, "Mouse Pad", "Mouse Pad Gamer Diablo ideal para jogos.", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Mouse_Pad_Diablo.jpg", "Mouse Pad Diablo", 35.45m },
                    { 5L, "Mouse Pad", "Mouse Pad Gamer Mortal Kombat ideal para jogos.", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Mouse_Pad_Mortal_Kombat.jpg", "Mouse Pad Mortal Kombat", 195.99m },
                    { 6L, "Mouse Pad", "Mouse Pad Gamer Sonic ideal para jogos.", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Mouse_Pad_Sonic.jpg", "Mouse Pad Sonic", 89.00m },
                    { 7L, "Camisas", "Camisa customizada Donkey Kong", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/T-Shirt_Donkey_Kong.jpg", "Camisa Donkey Kong", 18.99m },
                    { 8L, "Camisas", "Camisa customizada Gamer", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/T-Shirt_Gamer.jpg", "Camisa Gamer", 15.45m },
                    { 9L, "Camisas", "Camisa customizada Cavaleiro", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/T-Shirt_Cavaleiro.jpg", "Camisa Cavaleiro", 115.45m },
                    { 10L, "Tolhas", "Tolha de Banho customizada Castlevania", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Castlevania.jpg", "Toalha Castlevania", 87.56m },
                    { 11L, "Tolhas", "Tolha de Banho customizada Gamer", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Gamer.jpg", "Toalha Gamer", 89.45m },
                    { 12L, "Tolhas", "Tolha de Banho customizada Naruto", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Naruto.jpg", "Toalha Naruto", 135.99m },
                    { 13L, "Tolhas", "Tolha de Banho customizada Popeye", "https://github.com/dnrNew/virtual-store-microservice/tree/eShop/eShopMicroservice/eShopImages/Towel_Popeye.jpg", "Toalha Popeye", 250.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "image_url",
                keyValue: null,
                column: "image_url",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "product",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "description",
                keyValue: null,
                column: "description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product",
                type: "varchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "category_name",
                keyValue: null,
                column: "category_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
