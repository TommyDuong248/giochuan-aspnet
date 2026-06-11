using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GioChuanGiangDay.Migrations
{
    /// <inheritdoc />
    public partial class AddDangHocNghienCuuSinhToGiangVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DangHocNghienCuuSinh",
                table: "GiangViens",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DangHocNghienCuuSinh",
                table: "GiangViens");
        }
    }
}
