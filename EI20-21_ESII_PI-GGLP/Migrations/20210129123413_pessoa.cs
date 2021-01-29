using Microsoft.EntityFrameworkCore.Migrations;

namespace EI20_21_ESII_PI_GGLP.Migrations
{
    public partial class pessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Pessoa",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Pessoa",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Pessoa");
        }
    }
}
