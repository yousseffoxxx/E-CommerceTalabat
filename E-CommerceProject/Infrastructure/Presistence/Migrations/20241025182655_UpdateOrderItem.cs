using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_Orderid",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductBrands",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Product_Productid",
                table: "OrderItems",
                newName: "Product_ProductId");

            migrationBuilder.RenameColumn(
                name: "Orderid",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_Orderid",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DeliveryMethods",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductBrands",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Product_ProductId",
                table: "OrderItems",
                newName: "Product_Productid");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "Orderid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderItems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_Orderid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DeliveryMethods",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_Orderid",
                table: "OrderItems",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");
        }
    }
}
