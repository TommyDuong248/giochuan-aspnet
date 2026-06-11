using System.ComponentModel.DataAnnotations;

namespace GioChuanGiangDay.Models
{
    public class DmHoatDongQuyDoi
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NhomHoatDong { get; set; } = string.Empty;
        // GIANG_DAY_KHAC, HOI_DONG, NCKH, NHIEM_VU_KHAC

        [Required]
        [StringLength(100)]
        public string MaHoatDong { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string TenHoatDong { get; set; } = string.Empty;

        [StringLength(100)]
        public string DonViTinh { get; set; } = string.Empty;

        public decimal GioQuyDoiMacDinh { get; set; }

        public decimal HeSoMacDinh { get; set; } = 1;

        public bool CanTyLeDongGop { get; set; }

        public bool CanMinhChung { get; set; } = true;

        public string GhiChu { get; set; } = string.Empty;
    }
}