using QuanLyGiaiCauLong.Models;

namespace QuanLyGiaiCauLong.Interfaces
{
    public interface IBadmintonRepository
    {
        Task<IEnumerable<TrongTai>> GetTrongTaisAsync();
        Task<IEnumerable<VanDongVien>> GetVanDongViensAsync();
        Task<IEnumerable<TranDau>> GetTranDausAsync();
        Task<IEnumerable<LichThiDau>> GetLichThiDausAsync();
        Task<IEnumerable<GiaiDau>> GetGiaiDausAsync();
        Task<IEnumerable<HLVTruong>> GetHLVTruongsAsync();
        Task<IEnumerable<DoiTuyen>> GetDoiTuyensAsync();
        Task<IEnumerable<VanDongVien>> GetVanDongViensByNameAsync(string keyword);
        Task<IEnumerable<TranDau>> GetTranDauVDVAsync(string maVDV);
        Task<IEnumerable<TranDau>> GetTranDauThangVDVAsync(string maVDV);
    }
}
