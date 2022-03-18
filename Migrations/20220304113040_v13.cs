using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Grad_GradId",
                table: "Sala");

            migrationBuilder.AlterColumn<int>(
                name: "Kapacitet",
                table: "Sala",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GradId",
                table: "Sala",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Grad_GradId",
                table: "Sala",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Grad_GradId",
                table: "Sala");

            migrationBuilder.AlterColumn<string>(
                name: "Kapacitet",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GradId",
                table: "Sala",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Grad_GradId",
                table: "Sala",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
