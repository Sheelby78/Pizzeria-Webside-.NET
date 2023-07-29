using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizzeriaWebside.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_Orders_OrdersId",
                table: "OrderPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_Pizzas_PizzasId",
                table: "OrderPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPizza",
                table: "OrderPizza");

            migrationBuilder.RenameColumn(
                name: "PizzasId",
                table: "OrderPizza",
                newName: "PizzaId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "OrderPizza",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPizza_PizzasId",
                table: "OrderPizza",
                newName: "IX_OrderPizza_PizzaId");

            migrationBuilder.AddColumn<int>(
                name: "OrderPizzaId",
                table: "OrderPizza",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "OrderPizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPizza",
                table: "OrderPizza",
                column: "OrderPizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_OrderId",
                table: "OrderPizza",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_Orders_OrderId",
                table: "OrderPizza",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_Pizzas_PizzaId",
                table: "OrderPizza",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_Orders_OrderId",
                table: "OrderPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_Pizzas_PizzaId",
                table: "OrderPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPizza",
                table: "OrderPizza");

            migrationBuilder.DropIndex(
                name: "IX_OrderPizza_OrderId",
                table: "OrderPizza");

            migrationBuilder.DropColumn(
                name: "OrderPizzaId",
                table: "OrderPizza");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderPizza");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "OrderPizza",
                newName: "PizzasId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderPizza",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPizza_PizzaId",
                table: "OrderPizza",
                newName: "IX_OrderPizza_PizzasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPizza",
                table: "OrderPizza",
                columns: new[] { "OrdersId", "PizzasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_Orders_OrdersId",
                table: "OrderPizza",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_Pizzas_PizzasId",
                table: "OrderPizza",
                column: "PizzasId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
