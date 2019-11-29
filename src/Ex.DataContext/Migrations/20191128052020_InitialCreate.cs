using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ex.DataContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DominioCategoria",
                columns: table => new
                {
                    DominioCategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusaoRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracaoRegistro = table.Column<DateTime>(nullable: true)
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DominioCategoria", x => x.DominioCategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Dominio",
                columns: table => new
                {
                    DominioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    DominioCategoriaId = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusaoRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracaoRegistro = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dominio", x => x.DominioId);
                    table.ForeignKey(
                        name: "FK_Dominio_DominioCategoria_DominioCategoriaId",
                        column: x => x.DominioCategoriaId,
                        principalTable: "DominioCategoria",
                        principalColumn: "DominioCategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    FamiliaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DominioIdStatus = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusaoRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracaoRegistro = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.FamiliaId);
                    table.ForeignKey(
                        name: "FK_Familia_Dominio_DominioIdStatus",
                        column: x => x.DominioIdStatus,
                        principalTable: "Dominio",
                        principalColumn: "DominioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoFamiliar",
                columns: table => new
                {
                    AvaliacaoFamiliarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pontuacao = table.Column<int>(nullable: false),
                    FamiliaId = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusaoRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracaoRegistro = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoFamiliar", x => x.AvaliacaoFamiliarId);
                    table.ForeignKey(
                        name: "FK_AvaliacaoFamiliar_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    FamiliaId = table.Column<int>(nullable: false),
                    DominioIdTipo = table.Column<int>(nullable: false),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusaoRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracaoRegistro = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoa_Dominio_DominioIdTipo",
                        column: x => x.DominioIdTipo,
                        principalTable: "Dominio",
                        principalColumn: "DominioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoa_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Renda",
                columns: table => new
                {
                    RendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14, 2)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusaoRegistro = table.Column<DateTime>(nullable: false),
                    DataAlteracaoRegistro = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renda", x => x.RendaId);
                    table.ForeignKey(
                        name: "FK_Renda_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DominioCategoria",
                columns: new[] { "DominioCategoriaId", "Ativo", "DataAlteracaoRegistro", "DataInclusaoRegistro", "Nome" },
                values: new object[] { 1, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 191, DateTimeKind.Local).AddTicks(2032), "Tipo Pessoa" });

            migrationBuilder.InsertData(
                table: "DominioCategoria",
                columns: new[] { "DominioCategoriaId", "Ativo", "DataAlteracaoRegistro", "DataInclusaoRegistro", "Nome" },
                values: new object[] { 2, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 194, DateTimeKind.Local).AddTicks(1800), "Status Familia" });

            migrationBuilder.InsertData(
                table: "Dominio",
                columns: new[] { "DominioId", "Ativo", "DataAlteracaoRegistro", "DataInclusaoRegistro", "DominioCategoriaId", "Nome" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 196, DateTimeKind.Local).AddTicks(290), 1, "Pretendente" },
                    { 2, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 196, DateTimeKind.Local).AddTicks(373), 1, "Conjuge" },
                    { 3, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 196, DateTimeKind.Local).AddTicks(379), 1, "Dependente" },
                    { 4, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 196, DateTimeKind.Local).AddTicks(385), 2, "Cadastro Válido" },
                    { 5, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 196, DateTimeKind.Local).AddTicks(390), 2, "Possui Uma Casa" },
                    { 6, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 196, DateTimeKind.Local).AddTicks(395), 2, "Selecionada Em Outro Processo" },
                    { 7, true, null, new DateTime(2019, 11, 28, 1, 20, 20, 196, DateTimeKind.Local).AddTicks(400), 2, "Cadastro Incompleto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoFamiliar_FamiliaId",
                table: "AvaliacaoFamiliar",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dominio_DominioCategoriaId",
                table: "Dominio",
                column: "DominioCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Familia_DominioIdStatus",
                table: "Familia",
                column: "DominioIdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_DominioIdTipo",
                table: "Pessoa",
                column: "DominioIdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_FamiliaId",
                table: "Pessoa",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Renda_PessoaId",
                table: "Renda",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoFamiliar");

            migrationBuilder.DropTable(
                name: "Renda");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Familia");

            migrationBuilder.DropTable(
                name: "Dominio");

            migrationBuilder.DropTable(
                name: "DominioCategoria");
        }
    }
}
