using System.ComponentModel.DataAnnotations;

namespace GioChuanGiangDay.Models
{
    public class DmGioChuan
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaChucDanh { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string TrinhDo { get; set; } = string.Empty;

        public bool LaTapSu { get; set; }

        public decimal GioChuanGiangDay { get; set; }

        public decimal GioChuanNckh { get; set; }

        [Required]
        [StringLength(20)]
        public string NamApDung { get; set; } = string.Empty;
    }
}