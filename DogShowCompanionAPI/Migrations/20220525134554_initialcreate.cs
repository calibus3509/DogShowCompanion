using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShowCompanionAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogBreeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogShowClassCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogShowClassCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    EntryFee = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogShows_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kennels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kennels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kennels_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DogColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsStandard = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogBreedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogColors_DogBreeds_DogBreedId",
                        column: x => x.DogBreedId,
                        principalTable: "DogBreeds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DogTraits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogBreedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogTraits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogTraits_DogBreeds_DogBreedId",
                        column: x => x.DogBreedId,
                        principalTable: "DogBreeds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    KennelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_Kennels_KennelId",
                        column: x => x.KennelId,
                        principalTable: "Kennels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DogShowClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    RingNumber = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JudgeId = table.Column<int>(type: "int", nullable: true),
                    DogShowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogShowClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogShowClasses_DogBreeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "DogBreeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DogShowClasses_DogShowClassCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DogShowClassCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DogShowClasses_DogShows_DogShowId",
                        column: x => x.DogShowId,
                        principalTable: "DogShows",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DogShowClasses_People_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AkcId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Microchip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    DogShowClassId = table.Column<int>(type: "int", nullable: true),
                    KennelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_DogBreeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "DogBreeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dogs_DogColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "DogColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dogs_DogGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "DogGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dogs_DogShowClasses_DogShowClassId",
                        column: x => x.DogShowClassId,
                        principalTable: "DogShowClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dogs_Kennels_KennelId",
                        column: x => x.KennelId,
                        principalTable: "Kennels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogColors_DogBreedId",
                table: "DogColors",
                column: "DogBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ColorId",
                table: "Dogs",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_DogShowClassId",
                table: "Dogs",
                column: "DogShowClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_GroupId",
                table: "Dogs",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_KennelId",
                table: "Dogs",
                column: "KennelId");

            migrationBuilder.CreateIndex(
                name: "IX_DogShowClasses_BreedId",
                table: "DogShowClasses",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_DogShowClasses_CategoryId",
                table: "DogShowClasses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DogShowClasses_DogShowId",
                table: "DogShowClasses",
                column: "DogShowId");

            migrationBuilder.CreateIndex(
                name: "IX_DogShowClasses_JudgeId",
                table: "DogShowClasses",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_DogShows_AddressId",
                table: "DogShows",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DogTraits_DogBreedId",
                table: "DogTraits",
                column: "DogBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_AddressId",
                table: "Kennels",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_KennelId",
                table: "People",
                column: "KennelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "DogTraits");

            migrationBuilder.DropTable(
                name: "DogColors");

            migrationBuilder.DropTable(
                name: "DogGroup");

            migrationBuilder.DropTable(
                name: "DogShowClasses");

            migrationBuilder.DropTable(
                name: "DogBreeds");

            migrationBuilder.DropTable(
                name: "DogShowClassCategories");

            migrationBuilder.DropTable(
                name: "DogShows");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Kennels");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
