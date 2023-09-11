using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chefsanddishes.Migrations
{
    public partial class AddChefNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chef_ChefId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chef",
                table: "Chef");

            migrationBuilder.RenameTable(
                name: "Chef",
                newName: "Chefs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chefs",
                table: "Chefs",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chefs",
                table: "Chefs");

            migrationBuilder.RenameTable(
                name: "Chefs",
                newName: "Chef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chef",
                table: "Chef",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chef_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chef",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
