using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShowCompanionAPI.Migrations
{
    public partial class DogKennelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Kennels_KennelId",
                table: "Dogs");

            migrationBuilder.AlterColumn<int>(
                name: "KennelId",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Kennels_KennelId",
                table: "Dogs",
                column: "KennelId",
                principalTable: "Kennels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Kennels_KennelId",
                table: "Dogs");

            migrationBuilder.AlterColumn<int>(
                name: "KennelId",
                table: "Dogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Kennels_KennelId",
                table: "Dogs",
                column: "KennelId",
                principalTable: "Kennels",
                principalColumn: "Id");
        }
    }
}
