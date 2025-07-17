using QuanLyGiaiCauLong.Models;

namespace QuanLyGiaiCauLong.ViewModels
{
    public class VdvVaDiem
    {
        public VanDongVien VanDongVien { get; set; }
        public int TongDiem { get; set; }
        public ICollection<TranDau> CacTranDauThang { get; set; } = new List<TranDau>();
    }

    public class KetQuaTimKiemVdvViewModel
    {
        public string TuKhoaTimKiem { get; set; } = string.Empty;
        public List<VdvVaDiem> DanhSachKetQua { get; set; } = new List<VdvVaDiem>();
    }
}
