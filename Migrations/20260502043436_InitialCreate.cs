using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GioChuanGiangDay.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DmGioChuans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaChucDanh = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TrinhDo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LaTapSu = table.Column<bool>(type: "INTEGER", nullable: false),
                    GioChuanGiangDay = table.Column<decimal>(type: "TEXT", nullable: false),
                    GioChuanNckh = table.Column<decimal>(type: "TEXT", nullable: false),
                    NamApDung = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmGioChuans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiangViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaGiangVien = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Khoa = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    BoMon = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    MaChucDanh = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TrinhDo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LaTapSu = table.Column<bool>(type: "INTEGER", nullable: false),
                    DangLamViec = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangViens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DmGioChuans",
                columns: new[] { "Id", "GioChuanGiangDay", "GioChuanNckh", "LaTapSu", "MaChucDanh", "NamApDung", "TrinhDo" },
                values: new object[,]
                {
                    { 1, 200m, 250m, false, "GV_HANG_I", "2025-2026", "TIEN_SI" },
                    { 2, 240m, 210m, false, "GV_HANG_II", "2025-2026", "TIEN_SI" },
                    { 3, 280m, 170m, false, "GV_HANG_III", "2025-2026", "TIEN_SI" },
                    { 4, 300m, 150m, false, "GV_HANG_III", "2025-2026", "THAC_SI" },
                    { 5, 100m, 50m, false, "GV_HANG_III", "2025-2026", "KHAC" },
                    { 6, 80m, 40m, false, "TRO_GIANG", "2025-2026", "THAC_SI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DmGioChuans");

            migrationBuilder.DropTable(
                name: "GiangViens");
        }
    }
}
