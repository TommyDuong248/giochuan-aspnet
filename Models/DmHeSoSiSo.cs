namespace GioChuanGiangDay.Models
{
    public class DmHeSoSiSo
    {
        public int Id { get; set; }

        public int SiSoTu { get; set; }

        public int? SiSoDen { get; set; }

        public decimal HeSo { get; set; }

        public string GhiChu { get; set; } = string.Empty;
    }
}