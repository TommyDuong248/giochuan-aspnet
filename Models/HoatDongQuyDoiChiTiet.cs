using System.ComponentModel.DataAnnotations;

namespace GioChuanGiangDay.Models
{
    public class HoatDongQuyDoiChiTiet
    {
        public int Id { get; set; }

        public int GiangVienId { get; set; }

        public GiangVien? GiangVien { get; set; }

        public int DmHoatDongQuyDoiId { get; set; }

        public DmHoatDongQuyDoi? DmHoatDongQuyDoi { get; set; }

        [Required]
        [StringLength(20)]
        public string NamHoc { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string TenNoiDung { get; set; } = string.Empty;

        public decimal SoLuong { get; set; } = 1;

        public decimal GioQuyDoiMacDinh { get; set; }

        public decimal HeSo { get; set; } = 1;

        public decimal TyLeDongGop { get; set; } = 100;

        public decimal GioDuocTinh { get; set; }

        [StringLength(500)]
        public string? FileMinhChung { get; set; }

        [StringLength(50)]
        public string TrangThaiDuyet { get; set; } = "NHAP";

        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}