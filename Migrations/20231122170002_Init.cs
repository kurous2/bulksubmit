using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramTest.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblM_Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblM_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblM_Hobi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(1)", nullable: false),
                    Nama = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblM_Hobi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblT_Umur",
                columns: table => new
                {
                    Age = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblT_Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "varchar(255)", nullable: true),
                    IdGender = table.Column<int>(type: "int", nullable: true),
                    IdHobi = table.Column<string>(type: "char(1)", nullable: true),
                    Umur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblT_Personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblT_Personal_tblM_Gender_IdGender",
                        column: x => x.IdGender,
                        principalTable: "tblM_Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblT_Personal_tblM_Hobi_IdHobi",
                        column: x => x.IdHobi,
                        principalTable: "tblM_Hobi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblT_Personal_IdGender",
                table: "tblT_Personal",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_tblT_Personal_IdHobi",
                table: "tblT_Personal",
                column: "IdHobi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblT_Personal");

            migrationBuilder.DropTable(
                name: "tblT_Umur");

            migrationBuilder.DropTable(
                name: "tblM_Gender");

            migrationBuilder.DropTable(
                name: "tblM_Hobi");
        }
    }
}
