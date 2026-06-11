using System.ComponentModel.DataAnnotations;

namespace GioChuanGiangDay.Models
{
    public class GiangVien
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaGiangVien { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Khoa { get; set; }

        [StringLength(255)]
        public string? BoMon { get; set; }

        [Required]
        [StringLength(50)]
        public string MaChucDanh { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string TrinhDo { get; set; } = string.Empty;

        public bool LaTapSu { get; set; }

        public bool DangHocNghienCuuSinh { get; set; }

        public bool DangLamViec { get; set; } = true;
    }
}