using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogScript.Dal.Migrations
{
    public partial class BlogPrivacy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Privacy",
                table: "Blogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "Blogs");
        }
    }
}
