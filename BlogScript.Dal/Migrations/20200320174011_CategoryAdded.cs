using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogScript.Dal.Migrations
{
    public partial class CategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoryid",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Categoryid",
                table: "Blogs",
                column: "Categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_Categoryid",
                table: "Blogs",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_Categoryid",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_Categoryid",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Categoryid",
                table: "Blogs");
        }
    }
}
