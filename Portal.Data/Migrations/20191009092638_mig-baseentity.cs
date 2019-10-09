using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Data.Migrations
{
    public partial class migbaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifyBy",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastModifyBy",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
