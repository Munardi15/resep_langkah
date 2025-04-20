using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace resep_langkah.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Langkah",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResepId = table.Column<int>(type: "integer", nullable: false),
                    Judul = table.Column<string>(type: "text", nullable: false),
                    ParentLangkahId = table.Column<int>(type: "integer", nullable: true),
                    Urutan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langkah", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Langkah_Langkah_ParentLangkahId",
                        column: x => x.ParentLangkahId,
                        principalTable: "Langkah",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Langkah_Resep_ResepId",
                        column: x => x.ResepId,
                        principalTable: "Resep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangkahId = table.Column<int>(type: "integer", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    TipeData = table.Column<string>(type: "text", nullable: false),
                    Nilai = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameter_Langkah_LangkahId",
                        column: x => x.LangkahId,
                        principalTable: "Langkah",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Langkah_ParentLangkahId",
                table: "Langkah",
                column: "ParentLangkahId");

            migrationBuilder.CreateIndex(
                name: "IX_Langkah_ResepId",
                table: "Langkah",
                column: "ResepId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_LangkahId",
                table: "Parameter",
                column: "LangkahId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Langkah");

            migrationBuilder.DropTable(
                name: "Resep");
        }
    }
}
