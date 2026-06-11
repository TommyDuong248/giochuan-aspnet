namespace GioChuanGiangDay.ViewModels
{
    public class TongHopGioChuanViewModel
    {
        public int GiangVienId { get; set; }

        public string HoTen { get; set; } = string.Empty;

        public string MaGiangVien { get; set; } = string.Empty;

        public string NamHoc { get; set; } = string.Empty;

        public decimal GioChuanGiangDay { get; set; }

        public decimal GioChuanNckh { get; set; }

        public decimal GioGiangDayTrucTiep { get; set; }

        public decimal GioHuongDanVaGiangDayKhac { get; set; }

        public decimal GioHoiDong { get; set; }

        public decimal GioNckh { get; set; }

        public decimal GioNhiemVuKhac { get; set; }

        public decimal TongGioGiangDay
            => GioGiangDayTrucTiep + GioHuongDanVaGiangDayKhac + GioHoiDong;

        public decimal ChenhLechGiangDay
            => TongGioGiangDay - GioChuanGiangDay;

        public decimal ChenhLechNckh
            => GioNckh - GioChuanNckh;

        public decimal TongTatCaGioQuyDoi
            => TongGioGiangDay + GioNckh + GioNhiemVuKhac;

        public bool DaCauHinhDinhMuc { get; set; } = true;

        public string? GhiChu { get; set; }
    }
}