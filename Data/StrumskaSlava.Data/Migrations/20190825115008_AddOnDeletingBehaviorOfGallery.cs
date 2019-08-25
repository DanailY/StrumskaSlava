using Microsoft.EntityFrameworkCore.Migrations;

namespace StrumskaSlava.Data.Migrations
{
    public partial class AddOnDeletingBehaviorOfGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Galleries_GalleryId",
                table: "Pictures");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Galleries_GalleryId",
                table: "Pictures",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Galleries_GalleryId",
                table: "Pictures");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Galleries_GalleryId",
                table: "Pictures",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
