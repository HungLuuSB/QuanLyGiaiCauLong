using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiCauLong.Models
{
    public class GiaiDau
    {
        [Key]
        public string MaGiai { get; set; } = string.Empty;
        public string TenGiai { get; set; } = string.Empty;
        public string LoaiGiai { get; set; } = string.Empty;
        public DateTime ThoiGian { get; set; }
        public string DiaDiem { get; set; } = string.Empty;

        // Navigation property
        public ICollection<LichThiDau>? LichThiDaus { get; set; } = new List<LichThiDau>();
    }
}
