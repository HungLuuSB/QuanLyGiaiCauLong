using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiCauLong.Models
{
    public class VanDongVien
    {
        [Key]
        public string MaVDV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public int NamSinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        [ForeignKey("DoiTuyen")]
        public string MaDoi { get; set; } = string.Empty;
        public int Diem { get; set; }

        // Navigation property
        public DoiTuyen? DoiTuyen { get; set; }
    }
}
