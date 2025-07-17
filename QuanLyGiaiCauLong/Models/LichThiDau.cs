using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiCauLong.Models
{
    public class LichThiDau
    {
        [Key]
        public string MaLich { get; set; } = string.Empty;
        [ForeignKey("GiaiDau")]
        public string MaGiai { get; set; } = string.Empty;
        public DateTime NgayThiDau { get; set; }
        public string DiaDiem { get; set; } = string.Empty;

        // Navigation property
        public GiaiDau? GiaiDau { get; set; }
        public ICollection<TranDau>? TranDaus { get; set; } = new List<TranDau>();
    }
}
