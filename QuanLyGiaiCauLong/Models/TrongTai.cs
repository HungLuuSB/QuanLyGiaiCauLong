using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiCauLong.Models
{
    public class TrongTai
    {
        [Key]
        public string MaTT { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public int SoTran { get; set; }
        public float HeSoLuong { get; set; }
        public float LuongCoBan { get; set; }
    }
}
