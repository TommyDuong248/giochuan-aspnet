using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GioChuanGiangDay.Migrations
{
    /// <inheritdoc />
    public partial class AddHoatDongQuyDoiTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DmHoatDongQuyDois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NhomHoatDong = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MaHoatDong = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TenHoatDong = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DonViTinh = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GioQuyDoiMacDinh = table.Column<decimal>(type: "TEXT", nullable: false),
                    HeSoMacDinh = table.Column<decimal>(type: "TEXT", nullable: false),
                    CanTyLeDongGop = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanMinhChung = table.Column<bool>(type: "INTEGER", nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmHoatDongQuyDois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoatDongQuyDoiChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GiangVienId = table.Column<int>(type: "INTEGER", nullable: false),
                    DmHoatDongQuyDoiId = table.Column<int>(type: "INTEGER", nullable: false),
                    NamHoc = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TenNoiDung = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    SoLuong = table.Column<decimal>(type: "TEXT", nullable: false),
                    GioQuyDoiMacDinh = table.Column<decimal>(type: "TEXT", nullable: false),
                    HeSo = table.Column<decimal>(type: "TEXT", nullable: false),
                    TyLeDongGop = table.Column<decimal>(type: "TEXT", nullable: false),
                    GioDuocTinh = table.Column<decimal>(type: "TEXT", nullable: false),
                    FileMinhChung = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    TrangThaiDuyet = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoatDongQuyDoiChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoatDongQuyDoiChiTiets_DmHoatDongQuyDois_DmHoatDongQuyDoiId",
                        column: x => x.DmHoatDongQuyDoiId,
                        principalTable: "DmHoatDongQuyDois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoatDongQuyDoiChiTiets_GiangViens_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoatDongQuyDoiChiTiets_DmHoatDongQuyDoiId",
                table: "HoatDongQuyDoiChiTiets",
                column: "DmHoatDongQuyDoiId");

            migrationBuilder.CreateIndex(
                name: "IX_HoatDongQuyDoiChiTiets_GiangVienId",
                table: "HoatDongQuyDoiChiTiets",
                column: "GiangVienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoatDongQuyDoiChiTiets");

            migrationBuilder.DropTable(
                name: "DmHoatDongQuyDois");
        }
    }
}
