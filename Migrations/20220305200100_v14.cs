using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Koncert",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Koncert",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
