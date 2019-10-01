using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Data.Migrations
{
    public partial class baseEntityKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifyTime",
                table: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifyBy",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifyTime",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
