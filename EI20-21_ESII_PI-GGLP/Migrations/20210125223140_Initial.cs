using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EI20_21_ESII_PI_GGLP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTipo = table.Column<string>(nullable: true),
                    CComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaID);
                });

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
                name: "Dia",
                columns: table => new
                {
                    DiaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNome = table.Column<string>(nullable: true),
                    DComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dia", x => x.DiaID);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENome = table.Column<string>(nullable: true),
                    EComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNome = table.Column<string>(maxLength: 50, nullable: false),
                    PContato = table.Column<int>(nullable: false),
                    PEmail = table.Column<string>(nullable: false),
                    PComments = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaID);
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

            migrationBuilder.CreateTable(
                name: "RegrasCOVID",
                columns: table => new
                {
                    RegrasCOVID_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RDescricao = table.Column<string>(maxLength: 400, nullable: false),
                    RDataVigor = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegrasCOVID", x => x.RegrasCOVID_ID);
                });

            migrationBuilder.CreateTable(
                name: "PontoDeInteresse",
                columns: table => new
                {
                    PontoDeInteresseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaID = table.Column<int>(nullable: false),
                    PImagem = table.Column<byte[]>(nullable: true),
                    PNome = table.Column<string>(maxLength: 30, nullable: false),
                    PDescricao = table.Column<string>(maxLength: 400, nullable: false),
                    PEndereco = table.Column<string>(maxLength: 200, nullable: false),
                    PCoordenadas = table.Column<string>(nullable: false),
                    PContacto = table.Column<int>(nullable: false),
                    PEmail = table.Column<string>(maxLength: 100, nullable: false),
                    PNumPessoas = table.Column<int>(nullable: false),
                    PMaxPessoas = table.Column<int>(nullable: false),
                    EstadoID = table.Column<int>(nullable: false),
                    PDataEstado = table.Column<DateTime>(nullable: false),
                    PComments = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoDeInteresse", x => x.PontoDeInteresseID);
                    table.ForeignKey(
                        name: "FK_PontoDeInteresse_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontoDeInteresse_Estado_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estado",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    AgendamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaID = table.Column<int>(nullable: false),
                    PontoDeInteresseID = table.Column<int>(nullable: false),
                    AData = table.Column<string>(nullable: true),
                    AHora = table.Column<string>(nullable: false),
                    ANumPessoas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.AgendamentoID);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_PontoDeInteresse_PontoDeInteresseID",
                        column: x => x.PontoDeInteresseID,
                        principalTable: "PontoDeInteresse",
                        principalColumn: "PontoDeInteresseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PontoDeInteresseID = table.Column<int>(nullable: false),
                    DiaID = table.Column<int>(nullable: false),
                    HInicio = table.Column<int>(nullable: false),
                    HFim = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioID);
                    table.ForeignKey(
                        name: "FK_Horario_Dia_DiaID",
                        column: x => x.DiaID,
                        principalTable: "Dia",
                        principalColumn: "DiaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horario_PontoDeInteresse_PontoDeInteresseID",
                        column: x => x.PontoDeInteresseID,
                        principalTable: "PontoDeInteresse",
                        principalColumn: "PontoDeInteresseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PessoaID",
                table: "Agendamento",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PontoDeInteresseID",
                table: "Agendamento",
                column: "PontoDeInteresseID");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_DiaID",
                table: "Horario",
                column: "DiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_PontoDeInteresseID",
                table: "Horario",
                column: "PontoDeInteresseID");

            migrationBuilder.CreateIndex(
                name: "IX_PontoDeInteresse_CategoriaID",
                table: "PontoDeInteresse",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_PontoDeInteresse_EstadoID",
                table: "PontoDeInteresse",
                column: "EstadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Pontos");

            migrationBuilder.DropTable(
                name: "RegrasCOVID");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Dia");

            migrationBuilder.DropTable(
                name: "PontoDeInteresse");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
