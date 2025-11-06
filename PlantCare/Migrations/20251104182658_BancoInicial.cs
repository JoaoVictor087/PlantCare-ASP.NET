using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantCare.Migrations
{
    /// <inheritdoc />
    public partial class BancoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PC_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SENHA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PC_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "T_PC_PLANTA",
                columns: table => new
                {
                    ID_PLANTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_PLANTA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TIPO_PLANTA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PC_PLANTA", x => x.ID_PLANTA);
                    table.ForeignKey(
                        name: "FK_T_PC_PLANTA_T_PC_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "T_PC_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_PC_PLANTA_ID_USUARIO",
                table: "T_PC_PLANTA",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PC_PLANTA");

            migrationBuilder.DropTable(
                name: "T_PC_USUARIO");
        }
    }
}
