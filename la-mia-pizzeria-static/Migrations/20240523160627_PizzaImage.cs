using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    public partial class PizzaImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Pizze");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImgFile",
                table: "Pizze",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgFile",
                table: "Pizze");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Pizze",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
