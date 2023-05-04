using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica.AccesoADatos.Migrations
{
    public partial class PruebaTecnica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Codigo = table.Column<decimal>(type: "numeric(12,0)", nullable: false),
                    Direccion = table.Column<string>(maxLength: 25, nullable: false),
                    Telefono = table.Column<string>(maxLength: 11, nullable: false),
                    Ciudad = table.Column<string>(maxLength: 20, nullable: false),
                    Departamento = table.Column<string>(maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
