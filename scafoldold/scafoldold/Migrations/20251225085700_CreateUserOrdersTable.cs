using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scafoldold.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "user_orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_orders",
                table: "user_orders",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_orders",
                table: "user_orders");

            migrationBuilder.RenameTable(
                name: "user_orders",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");
        }
    }
}
