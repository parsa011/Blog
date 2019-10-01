using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Data.Migrations
{
    public partial class rforigenkeyAttUndo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_WriterId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_WriterId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedBy",
                table: "Posts",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_CreatedBy",
                table: "Posts",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_CreatedBy",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CreatedBy",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WriterId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WriterId",
                table: "Posts",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_WriterId",
                table: "Posts",
                column: "WriterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
