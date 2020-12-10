using Microsoft.EntityFrameworkCore.Migrations;

namespace EI20_21_ESII_PI_GGLP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Desc = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    PontoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PPicture = table.Column<string>(nullable: false),
                    PNome = table.Column<string>(maxLength: 30, nullable: false),
                    PCategoria = table.Column<string>(nullable: false),
                    PDescricao = table.Column<string>(maxLength: 400, nullable: false),
                    PEndereco = table.Column<string>(maxLength: 200, nullable: false),
                    PCoordenadas = table.Column<string>(nullable: false),
                    PHorarioSemana = table.Column<string>(maxLength: 100, nullable: false),
                    PHorarioFimSemana = table.Column<string>(maxLength: 100, nullable: false),
                    PHorarioFeriado = table.Column<string>(maxLength: 100, nullable: false),
                    PContacto = table.Column<int>(nullable: false),
                    PEmail = table.Column<string>(maxLength: 100, nullable: false),
                    PPersonsNum = table.Column<int>(nullable: false),
                    PTotalPersonsNum = table.Column<int>(nullable: false),
                    PCovid = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.PontoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Pontos");
        }
    }
}
