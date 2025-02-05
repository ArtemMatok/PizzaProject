using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaProjectApi.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartItemAddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartTokenCart",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CartTokenCart",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CartTokenCart",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "TokenCart",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TokenCart",
                table: "CartItems",
                column: "TokenCart");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_TokenCart",
                table: "CartItems",
                column: "TokenCart",
                principalTable: "Carts",
                principalColumn: "TokenCart",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_TokenCart",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_TokenCart",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "TokenCart",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CartTokenCart",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartTokenCart",
                table: "CartItems",
                column: "CartTokenCart");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartTokenCart",
                table: "CartItems",
                column: "CartTokenCart",
                principalTable: "Carts",
                principalColumn: "TokenCart",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
