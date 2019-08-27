namespace StrumskaSlava.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddMatchScheduleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RivalTeam",
                table: "MatchSchedules",
                newName: "MatchStatusId");

            migrationBuilder.RenameColumn(
                name: "FinalResult",
                table: "MatchSchedules",
                newName: "HomeTeam");

            migrationBuilder.RenameColumn(
                name: "DateOfTheGame",
                table: "MatchSchedules",
                newName: "MatchDate");

            migrationBuilder.AlterColumn<string>(
                name: "MatchStatusId",
                table: "MatchSchedules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MatchSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GuestTeam",
                table: "MatchSchedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuestTeamScore",
                table: "MatchSchedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamScore",
                table: "MatchSchedules",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "MatchSchedules",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatchStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchSchedules_MatchStatusId",
                table: "MatchSchedules",
                column: "MatchStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchSchedules_MatchStatuses_MatchStatusId",
                table: "MatchSchedules",
                column: "MatchStatusId",
                principalTable: "MatchStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchSchedules_MatchStatuses_MatchStatusId",
                table: "MatchSchedules");

            migrationBuilder.DropTable(
                name: "MatchStatuses");

            migrationBuilder.DropIndex(
                name: "IX_MatchSchedules_MatchStatusId",
                table: "MatchSchedules");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MatchSchedules");

            migrationBuilder.DropColumn(
                name: "GuestTeam",
                table: "MatchSchedules");

            migrationBuilder.DropColumn(
                name: "GuestTeamScore",
                table: "MatchSchedules");

            migrationBuilder.DropColumn(
                name: "HomeTeamScore",
                table: "MatchSchedules");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "MatchSchedules");

            migrationBuilder.RenameColumn(
                name: "MatchStatusId",
                table: "MatchSchedules",
                newName: "RivalTeam");

            migrationBuilder.RenameColumn(
                name: "MatchDate",
                table: "MatchSchedules",
                newName: "DateOfTheGame");

            migrationBuilder.RenameColumn(
                name: "HomeTeam",
                table: "MatchSchedules",
                newName: "FinalResult");

            migrationBuilder.AlterColumn<string>(
                name: "RivalTeam",
                table: "MatchSchedules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
