﻿using System;
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
                    Categoria_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTipo = table.Column<string>(nullable: true),
                    CComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Categoria_ID);
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
                    Dia_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNome = table.Column<string>(nullable: true),
                    DComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dia", x => x.Dia_ID);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Estado_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENome = table.Column<string>(nullable: true),
                    EComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Estado_ID);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Pessoa_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNome = table.Column<string>(maxLength: 50, nullable: false),
                    PContato = table.Column<int>(nullable: false),
                    PEmail = table.Column<string>(nullable: false),
                    PComments = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Pessoa_ID);
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
                    PontoDeInteresse_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria_ID = table.Column<int>(nullable: true),
                    PImagem = table.Column<byte[]>(nullable: false),
                    PNome = table.Column<string>(maxLength: 30, nullable: false),
                    PDescricao = table.Column<string>(maxLength: 400, nullable: false),
                    PEndereco = table.Column<string>(maxLength: 200, nullable: false),
                    PCoordenadas = table.Column<string>(nullable: false),
                    PContacto = table.Column<int>(nullable: false),
                    PEmail = table.Column<string>(maxLength: 100, nullable: false),
                    PNumPessoas = table.Column<int>(nullable: false),
                    PMaxPessoas = table.Column<int>(nullable: false),
                    Estado_ID = table.Column<int>(nullable: true),
                    PDataEstado = table.Column<DateTime>(nullable: false),
                    PComments = table.Column<string>(maxLength: 400, nullable: true),
                    Pessoa_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoDeInteresse", x => x.PontoDeInteresse_ID);
                    table.ForeignKey(
                        name: "FK_PontoDeInteresse_Categoria_Categoria_ID",
                        column: x => x.Categoria_ID,
                        principalTable: "Categoria",
                        principalColumn: "Categoria_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontoDeInteresse_Estado_Estado_ID",
                        column: x => x.Estado_ID,
                        principalTable: "Estado",
                        principalColumn: "Estado_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontoDeInteresse_Pessoa_Pessoa_ID",
                        column: x => x.Pessoa_ID,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Agendamento_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pessoa_ID = table.Column<int>(nullable: true),
                    PontoDeInteresse_ID = table.Column<int>(nullable: true),
                    AData = table.Column<string>(nullable: true),
                    AHora = table.Column<string>(nullable: false),
                    ANumPessoas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Agendamento_ID);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pessoa_Pessoa_ID",
                        column: x => x.Pessoa_ID,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamento_PontoDeInteresse_PontoDeInteresse_ID",
                        column: x => x.PontoDeInteresse_ID,
                        principalTable: "PontoDeInteresse",
                        principalColumn: "PontoDeInteresse_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Horario_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PontoDeInteresse_ID = table.Column<int>(nullable: true),
                    Dia_ID = table.Column<int>(nullable: false),
                    Dia_ID1 = table.Column<int>(nullable: true),
                    HInicio = table.Column<int>(nullable: false),
                    HFim = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Horario_ID);
                    table.ForeignKey(
                        name: "FK_Horario_Dia_Dia_ID1",
                        column: x => x.Dia_ID1,
                        principalTable: "Dia",
                        principalColumn: "Dia_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horario_PontoDeInteresse_PontoDeInteresse_ID",
                        column: x => x.PontoDeInteresse_ID,
                        principalTable: "PontoDeInteresse",
                        principalColumn: "PontoDeInteresse_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_Pessoa_ID",
                table: "Agendamento",
                column: "Pessoa_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PontoDeInteresse_ID",
                table: "Agendamento",
                column: "PontoDeInteresse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_Dia_ID1",
                table: "Horario",
                column: "Dia_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_PontoDeInteresse_ID",
                table: "Horario",
                column: "PontoDeInteresse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PontoDeInteresse_Categoria_ID",
                table: "PontoDeInteresse",
                column: "Categoria_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PontoDeInteresse_Estado_ID",
                table: "PontoDeInteresse",
                column: "Estado_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PontoDeInteresse_Pessoa_ID",
                table: "PontoDeInteresse",
                column: "Pessoa_ID");
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
                name: "Dia");

            migrationBuilder.DropTable(
                name: "PontoDeInteresse");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}