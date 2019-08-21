using Microsoft.EntityFrameworkCore.Migrations;

namespace StrumskaSlava.Data.Migrations
{
    public partial class AddedPictureToNewsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "News");
        }
    }
}
