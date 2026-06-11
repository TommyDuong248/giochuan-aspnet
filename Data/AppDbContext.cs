using GioChuanGiangDay.Models;
using Microsoft.EntityFrameworkCore;

namespace GioChuanGiangDay.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<GiangVien> GiangViens => Set<GiangVien>();

        public DbSet<DmGioChuan> DmGioChuans => Set<DmGioChuan>();

        public DbSet<DmHeSoSiSo> DmHeSoSiSos => Set<DmHeSoSiSo>();

        public DbSet<GiangDayChiTiet> GiangDayChiTiets => Set<GiangDayChiTiet>();
        public DbSet<DmHoatDongQuyDoi> DmHoatDongQuyDois => Set<DmHoatDongQuyDoi>();

        public DbSet<HoatDongQuyDoiChiTiet> HoatDongQuyDoiChiTiets => Set<HoatDongQuyDoiChiTiet>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DmGioChuan>().HasData(
                new DmGioChuan
                {
                    Id = 1,
                    MaChucDanh = "GV_HANG_I",
                    TrinhDo = "TIEN_SI",
                    LaTapSu = false,
                    GioChuanGiangDay = 200,
                    GioChuanNckh = 250,
                    NamApDung = "2025-2026"
                },
                new DmGioChuan
                {
                    Id = 2,
                    MaChucDanh = "GV_HANG_II",
                    TrinhDo = "TIEN_SI",
                    LaTapSu = false,
                    GioChuanGiangDay = 240,
                    GioChuanNckh = 210,
                    NamApDung = "2025-2026"
                },
                new DmGioChuan
                {
                    Id = 3,
                    MaChucDanh = "GV_HANG_III",
                    TrinhDo = "TIEN_SI",
                    LaTapSu = false,
                    GioChuanGiangDay = 280,
                    GioChuanNckh = 170,
                    NamApDung = "2025-2026"
                },
                new DmGioChuan
                {
                    Id = 4,
                    MaChucDanh = "GV_HANG_III",
                    TrinhDo = "THAC_SI",
                    LaTapSu = false,
                    GioChuanGiangDay = 300,
                    GioChuanNckh = 150,
                    NamApDung = "2025-2026"
                },
                new DmGioChuan
                {
                    Id = 5,
                    MaChucDanh = "GV_HANG_III",
                    TrinhDo = "KHAC",
                    LaTapSu = false,
                    GioChuanGiangDay = 100,
                    GioChuanNckh = 50,
                    NamApDung = "2025-2026"
                },
                new DmGioChuan
                {
                    Id = 6,
                    MaChucDanh = "TRO_GIANG",
                    TrinhDo = "THAC_SI",
                    LaTapSu = false,
                    GioChuanGiangDay = 80,
                    GioChuanNckh = 40,
                    NamApDung = "2025-2026"
                }
            );

            modelBuilder.Entity<DmHeSoSiSo>().HasData(
                new DmHeSoSiSo
                {
                    Id = 1,
                    SiSoTu = 0,
                    SiSoDen = 40,
                    HeSo = 1.0m,
                    GhiChu = "Dưới hoặc bằng 40 sinh viên"
                },
                new DmHeSoSiSo
                {
                    Id = 2,
                    SiSoTu = 41,
                    SiSoDen = 50,
                    HeSo = 1.1m,
                    GhiChu = "Từ 41 đến 50 sinh viên"
                },
                new DmHeSoSiSo
                {
                    Id = 3,
                    SiSoTu = 51,
                    SiSoDen = 60,
                    HeSo = 1.2m,
                    GhiChu = "Từ 51 đến 60 sinh viên"
                },
                new DmHeSoSiSo
                {
                    Id = 4,
                    SiSoTu = 61,
                    SiSoDen = 70,
                    HeSo = 1.3m,
                    GhiChu = "Từ 61 đến 70 sinh viên"
                },
                new DmHeSoSiSo
                {
                    Id = 5,
                    SiSoTu = 71,
                    SiSoDen = 80,
                    HeSo = 1.4m,
                    GhiChu = "Từ 71 đến 80 sinh viên"
                },
                new DmHeSoSiSo
                {
                    Id = 6,
                    SiSoTu = 81,
                    SiSoDen = null,
                    HeSo = 1.5m,
                    GhiChu = "Từ 81 sinh viên trở lên"
                }
            );
        }
    }
}