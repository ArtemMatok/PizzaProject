using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaProjectApi.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartInitializeTokenAndUpdateUserWithCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Carts");
        }
    }
}
