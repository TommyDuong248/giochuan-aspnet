using System.ComponentModel.DataAnnotations;

namespace GioChuanGiangDay.Models
{
    public class GiangDayChiTiet
    {
        public int Id { get; set; }

        public int GiangVienId { get; set; }

        public GiangVien? GiangVien { get; set; }

        [Required]
        [StringLength(20)]
        public string NamHoc { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string HocKy { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string MaHocPhan { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string TenHocPhan { get; set; } = string.Empty;

        [StringLength(50)]
        public string? LopHocPhan { get; set; }

        public decimal SoTinChi { get; set; }

        public decimal SoTietLyThuyet { get; set; }

        public decimal SoTietThucHanh { get; set; }

        public int SiSo { get; set; }

        public decimal HeSoSiSo { get; set; }

        public decimal GioQuyDoiLyThuyet { get; set; }

        public decimal GioQuyDoiThucHanh { get; set; }

        public decimal TongGioQuyDoi { get; set; }

        public string TrangThaiDuyet { get; set; } = "NHAP";

        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}