using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShowCompanionAPI.Migrations
{
    public partial class updateddogshowclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShowDate",
                table: "DogShows",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "DogShows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "DogShows");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "DogShows",
                newName: "ShowDate");
        }
    }
}
