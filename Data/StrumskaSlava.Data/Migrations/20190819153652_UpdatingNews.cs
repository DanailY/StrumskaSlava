using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrumskaSlava.Data.Migrations
{
    public partial class UpdatingNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Products_ProductId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_ProductId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_UserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "IssuedOn",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "News",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "News",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "NewsCategoryId",
                table: "News",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_News_NewsCategoryId",
                table: "News",
                newName: "IX_News_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "News",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "News",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "News",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "News",
                newName: "NewsCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_News_CategoryId",
                table: "News",
                newName: "IX_News_NewsCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "News",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "News",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedOn",
                table: "News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_News_ProductId",
                table: "News",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Products_ProductId",
                table: "News",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
