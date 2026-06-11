using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GioChuanGiangDay.Migrations
{
    /// <inheritdoc />
    public partial class AddGiangDayModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DmHeSoSiSos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiSoTu = table.Column<int>(type: "INTEGER", nullable: false),
                    SiSoDen = table.Column<int>(type: "INTEGER", nullable: true),
                    HeSo = table.Column<decimal>(type: "TEXT", nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmHeSoSiSos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiangDayChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GiangVienId = table.Column<int>(type: "INTEGER", nullable: false),
                    NamHoc = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    HocKy = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MaHocPhan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TenHocPhan = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    LopHocPhan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    SoTinChi = table.Column<decimal>(type: "TEXT", nullable: false),
                    SoTietLyThuyet = table.Column<decimal>(type: "TEXT", nullable: false),
                    SoTietThucHanh = table.Column<decimal>(type: "TEXT", nullable: false),
                    SiSo = table.Column<int>(type: "INTEGER", nullable: false),
                    HeSoSiSo = table.Column<decimal>(type: "TEXT", nullable: false),
                    GioQuyDoiLyThuyet = table.Column<decimal>(type: "TEXT", nullable: false),
                    GioQuyDoiThucHanh = table.Column<decimal>(type: "TEXT", nullable: false),
                    TongGioQuyDoi = table.Column<decimal>(type: "TEXT", nullable: false),
                    TrangThaiDuyet = table.Column<string>(type: "TEXT", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangDayChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiangDayChiTiets_GiangViens_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DmHeSoSiSos",
                columns: new[] { "Id", "GhiChu", "HeSo", "SiSoDen", "SiSoTu" },
                values: new object[,]
                {
                    { 1, "Dưới hoặc bằng 40 sinh viên", 1.0m, 40, 0 },
                    { 2, "Từ 41 đến 50 sinh viên", 1.1m, 50, 41 },
                    { 3, "Từ 51 đến 60 sinh viên", 1.2m, 60, 51 },
                    { 4, "Từ 61 đến 70 sinh viên", 1.3m, 70, 61 },
                    { 5, "Từ 71 đến 80 sinh viên", 1.4m, 80, 71 },
                    { 6, "Từ 81 sinh viên trở lên", 1.5m, null, 81 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiangDayChiTiets_GiangVienId",
                table: "GiangDayChiTiets",
                column: "GiangVienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DmHeSoSiSos");

            migrationBuilder.DropTable(
                name: "GiangDayChiTiets");
        }
    }
}
