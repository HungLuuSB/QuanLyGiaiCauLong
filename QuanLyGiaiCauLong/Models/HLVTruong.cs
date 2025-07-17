using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiCauLong.Models
{
    public class HLVTruong
    {
        [Key]
        public string MaHLV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; } = string.Empty;
        public string ChuyenMon { get; set; } = string.Empty;

        // Navigation property
        public ICollection<DoiTuyen>? DoiTuyens { get; set; }
    }
}
