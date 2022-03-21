﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koncert_Izvodjac_IzvodjacId",
                table: "Koncert");

            migrationBuilder.AlterColumn<int>(
                name: "IzvodjacId",
                table: "Koncert",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Koncert_Izvodjac_IzvodjacId",
                table: "Koncert",
                column: "IzvodjacId",
                principalTable: "Izvodjac",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koncert_Izvodjac_IzvodjacId",
                table: "Koncert");

            migrationBuilder.AlterColumn<int>(
                name: "IzvodjacId",
                table: "Koncert",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Koncert_Izvodjac_IzvodjacId",
                table: "Koncert",
                column: "IzvodjacId",
                principalTable: "Izvodjac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
