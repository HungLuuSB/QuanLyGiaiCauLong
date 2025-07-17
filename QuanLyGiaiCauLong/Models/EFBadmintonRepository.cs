using Microsoft.EntityFrameworkCore;
using QuanLyGiaiCauLong.Interfaces;
using QuanLyGiaiCauLong.ViewModels;

namespace QuanLyGiaiCauLong.Models
{
    public class EFBadmintonRepository : IBadmintonRepository
    {
        private readonly BadmintonDbContext _context;

        public EFBadmintonRepository(BadmintonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoiTuyen>> GetDoiTuyensAsync()
        {
            return await _context.DoiTuyens!.Include(d => d.HLVTruong)
                                            .Include(d => d.VanDongViens)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<GiaiDau>> GetGiaiDausAsync()
        {
            return await _context.GiaiDaus!.Include(g => g.LichThiDaus)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<HLVTruong>> GetHLVTruongsAsync()
        {
            return await _context.HLVTruongs!.Include(h => h.DoiTuyens)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<LichThiDau>> GetLichThiDausAsync()
        {
            return await _context.LichThiDaus!.Include(l => l.GiaiDau)
                                            .Include(l => l.TranDaus)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<TranDau>> GetTranDausAsync()
        {
            return await _context.TranDaus!.Include(t => t.LichThiDau)
                                            .Include(t => t.TrongTai)
                                            .Include(t => t.VanDongVien1)
                                            .Include(t => t.VanDongVien2)
                                            .Include(t => t.VanDongVien3)
                                            .Include(t => t.VanDongVien4)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<TranDau>> GetTranDauThangVDVAsync(string maVDV)
        {
            var tranDaus = await _context.TranDaus
                            .Where(t =>
                                t.MaVDV1 == maVDV ||
                                t.MaVDV2 == maVDV ||
                                t.MaVDV3 == maVDV ||
                                t.MaVDV4 == maVDV)
                            .ToListAsync();

            return tranDaus.Where(t =>
            {
                int viTriDoi = (t.MaVDV1 == maVDV || t.MaVDV2 == maVDV) ? 1 :
                               (t.MaVDV3 == maVDV || t.MaVDV4 == maVDV) ? 2 : 0;

                if (viTriDoi == 0 || string.IsNullOrEmpty(t.KetQua) || !t.KetQua.Contains('-'))
                    return false;

                var tiSo = t.KetQua.Split('-');
                if (!int.TryParse(tiSo[0], out int tiSoDoi1) || !int.TryParse(tiSo[1], out int tiSoDoi2))
                    return false;

                return (viTriDoi == 1 && tiSoDoi1 > tiSoDoi2) || (viTriDoi == 2 && tiSoDoi2 > tiSoDoi1);
            });
        }

        public async Task<IEnumerable<TranDau>> GetTranDauVDVAsync(string maVDV)
        {
            return await _context.TranDaus!
            .Where(t =>
                t.MaVDV1 == maVDV ||
                t.MaVDV2 == maVDV ||
                t.MaVDV3 == maVDV ||
                t.MaVDV4 == maVDV)
            .ToListAsync();
        }

        public async Task<IEnumerable<TrongTai>> GetTrongTaisAsync()
        {
            return await _context.TrongTais!.ToListAsync();
        }

        public async Task<IEnumerable<VanDongVien>> GetVanDongViensAsync()
        {
            return await _context.VanDongViens!.Include(v => v.DoiTuyen)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<VanDongVien>> GetVanDongViensByNameAsync(string keyword)
        {
            return await _context.VanDongViens!
                .Where(v => v.HoTen.Contains(keyword))
                .ToListAsync();
        }
    }
}
