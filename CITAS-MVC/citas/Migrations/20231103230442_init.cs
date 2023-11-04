using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace citas.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoPaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Tipo_Identidad = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Tipo_Sangre = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlergiaPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlergiaPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlergiaPaciente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitaMedica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitaMedica_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlergiaPaciente_PacienteId",
                table: "AlergiaPaciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_PacienteId",
                table: "CitaMedica",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlergiaPaciente");

            migrationBuilder.DropTable(
                name: "CitaMedica");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
