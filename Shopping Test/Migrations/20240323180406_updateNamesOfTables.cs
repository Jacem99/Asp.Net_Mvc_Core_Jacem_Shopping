using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_Test.Migrations
{
    /// <inheritdoc />
    public partial class updateNamesOfTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_products_ProductId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRevesationSystem_products_ProductsId",
                table: "ProductRevesationSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_products_AgeStages_AgeStageId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ClothesClassifications_ClothesClassificationId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_HumanClass_HumanClassId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Markas_MarkaId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_products_ProductId",
                table: "UserProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_products_MarkaId",
                table: "Products",
                newName: "IX_Products_MarkaId");

            migrationBuilder.RenameIndex(
                name: "IX_products_HumanClassId",
                table: "Products",
                newName: "IX_Products_HumanClassId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ClothesClassificationId",
                table: "Products",
                newName: "IX_Products_ClothesClassificationId");

            migrationBuilder.RenameIndex(
                name: "IX_products_AgeStageId",
                table: "Products",
                newName: "IX_Products_AgeStageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Products_ProductId",
                table: "Cards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRevesationSystem_Products_ProductsId",
                table: "ProductRevesationSystem",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AgeStages_AgeStageId",
                table: "Products",
                column: "AgeStageId",
                principalTable: "AgeStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ClothesClassifications_ClothesClassificationId",
                table: "Products",
                column: "ClothesClassificationId",
                principalTable: "ClothesClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_HumanClass_HumanClassId",
                table: "Products",
                column: "HumanClassId",
                principalTable: "HumanClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Markas_MarkaId",
                table: "Products",
                column: "MarkaId",
                principalTable: "Markas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Products_ProductId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRevesationSystem_Products_ProductsId",
                table: "ProductRevesationSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AgeStages_AgeStageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ClothesClassifications_ClothesClassificationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_HumanClass_HumanClassId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Markas_MarkaId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Products_MarkaId",
                table: "products",
                newName: "IX_products_MarkaId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_HumanClassId",
                table: "products",
                newName: "IX_products_HumanClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ClothesClassificationId",
                table: "products",
                newName: "IX_products_ClothesClassificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AgeStageId",
                table: "products",
                newName: "IX_products_AgeStageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_products_ProductId",
                table: "Cards",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRevesationSystem_products_ProductsId",
                table: "ProductRevesationSystem",
                column: "ProductsId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_AgeStages_AgeStageId",
                table: "products",
                column: "AgeStageId",
                principalTable: "AgeStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ClothesClassifications_ClothesClassificationId",
                table: "products",
                column: "ClothesClassificationId",
                principalTable: "ClothesClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_HumanClass_HumanClassId",
                table: "products",
                column: "HumanClassId",
                principalTable: "HumanClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Markas_MarkaId",
                table: "products",
                column: "MarkaId",
                principalTable: "Markas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_products_ProductId",
                table: "UserProducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
