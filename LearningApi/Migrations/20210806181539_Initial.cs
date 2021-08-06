using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Competency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    WhenAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LearningItems",
                columns: new[] { "Id", "Competency", "Notes", "Topic" },
                values: new object[,]
                {
                    { 1, "Conscious Incompetence", null, "Learn Protobuf" },
                    { 2, "Conscious Competence", "Watched some good videos. Tried it out. It's cool", "Explore Terraform" }
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Description", "IsRemoved", "WhenAdded" },
                values: new object[,]
                {
                    { 1, "Fix Angular App", false, new DateTime(2021, 8, 6, 14, 15, 38, 329, DateTimeKind.Local).AddTicks(8970) },
                    { 2, "Add a POST to the API", false, new DateTime(2021, 8, 6, 14, 15, 38, 335, DateTimeKind.Local).AddTicks(5625) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningItems");

            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
