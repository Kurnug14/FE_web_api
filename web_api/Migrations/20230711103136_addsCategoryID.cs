using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class addsCategoryID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Categories_CategoryId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Meals",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_CategoryId",
                table: "Meals",
                newName: "IX_Meals_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Categories_CategoryID",
                table: "Meals",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Categories_CategoryID",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Meals",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_CategoryID",
                table: "Meals",
                newName: "IX_Meals_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Categories_CategoryId",
                table: "Meals",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
