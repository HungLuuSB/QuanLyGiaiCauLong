using QuanLyGiaiCauLong.Models;

namespace QuanLyGiaiCauLong.ViewModels
{
    public class ThongKeVDVGiaiDauVM
    {
        public string LoaiGiai { get; set; } = string.Empty;
        public string TenGiai { get; set; } = string.Empty;
        public int TongSoVanDongVien { get; set; }
        public float TuoiTrungBinh { get; set; }
    }
}
