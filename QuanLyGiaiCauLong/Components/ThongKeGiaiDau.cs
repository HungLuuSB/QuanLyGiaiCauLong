using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGiaiCauLong.Models;
using QuanLyGiaiCauLong.ViewModels;

namespace QuanLyGiaiCauLong.Components
{
    public class ThongKeGiaiDau : ViewComponent
    {
        private readonly BadmintonDbContext _context;

        public ThongKeGiaiDau(BadmintonDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int soTranDau, int soVanDongVien, int soDoiTuyen)
        {
            var loaiGiaiDaus = _context.GiaiDaus
                        .Select(g => g.LoaiGiai)
                        .Distinct()
                        .ToList();

            List<ThongKeVDVGiaiDauVM> result = new();

            foreach (var loaiGiai in loaiGiaiDaus)
            {
                var queryTranDauTheoLoaiGiai = _context.TranDaus
                    .Where(td => td.LichThiDau.GiaiDau.LoaiGiai == loaiGiai);

                var tatCaMaVdv = queryTranDauTheoLoaiGiai.Select(t => t.MaVDV1)
                    .Concat(queryTranDauTheoLoaiGiai.Select(t => t.MaVDV2))
                    .Concat(queryTranDauTheoLoaiGiai.Select(t => t.MaVDV3))
                    .Concat(queryTranDauTheoLoaiGiai.Select(t => t.MaVDV4));

                var maVdvDuyNhat = tatCaMaVdv
                    .Where(id => !string.IsNullOrEmpty(id))
                    .Distinct()
                    .ToList();

                var vanDongViens = _context.VanDongViens
                                                 .Where(vdv => maVdvDuyNhat.Contains(vdv.MaVDV))
                                                 .ToList();

                int tongSoVdv = vanDongViens.Count;
                double tuoiTb = 0;

                if (tongSoVdv > 0)
                {
                    tuoiTb = vanDongViens.Average(vdv => (DateTime.Today.Year - vdv.NamSinh));
                }

                result.Add(new ThongKeVDVGiaiDauVM
                {
                    LoaiGiai = loaiGiai,
                    TongSoVanDongVien = tongSoVdv,
                    TuoiTrungBinh = (float)Math.Round(tuoiTb, 1)
                });
            }
            return View(result);
        }
    }
}
