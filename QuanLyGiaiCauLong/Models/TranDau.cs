using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiCauLong.Models
{
    public class TranDau
    {
        [Key]
        public string MaTran { get; set; } = string.Empty;
        public string VongDau { get; set; } = string.Empty;
        [ForeignKey("LichThiDau")]
        public string MaLich { get; set; } = string.Empty;
        [ForeignKey("TrongTai")]
        public string MaTT { get; set; } = string.Empty;

        [ForeignKey("VanDongVien1")]
        public string? MaVDV1 { get; set; }

        [ForeignKey("VanDongVien2")]
        public string? MaVDV2 { get; set; }

        [ForeignKey("VanDongVien3")]
        public string? MaVDV3 { get; set; }

        [ForeignKey("VanDongVien4")]
        public string? MaVDV4 { get; set; }

        public string KetQua { get; set; } = string.Empty;
        // Navigation properties
        public LichThiDau? LichThiDau { get; set; }
        public TrongTai? TrongTai { get; set; }
        public VanDongVien? VanDongVien1 { get; set; }
        public VanDongVien? VanDongVien2 { get; set; }
        public VanDongVien? VanDongVien3 { get; set; }
        public VanDongVien? VanDongVien4 { get; set; }
    }
}
