using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiCauLong.Models
{
    public class DoiTuyen
    {
        [Key]
        public string MaDoi { get; set; } = string.Empty;
        public string TenDoi { get; set; } = string.Empty;
        [ForeignKey("HLVTruong")]
        public string MaHLV { get; set; } = string.Empty;

        // Navigation properties
        public HLVTruong? HLVTruong { get; set; }
        public ICollection<VanDongVien>? VanDongViens { get; set; } = new List<VanDongVien>();
    }
}
