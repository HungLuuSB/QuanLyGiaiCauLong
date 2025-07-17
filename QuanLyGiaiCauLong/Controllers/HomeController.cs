using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGiaiCauLong.Models;
using QuanLyGiaiCauLong.ViewModels;
using System.Diagnostics;

namespace QuanLyGiaiCauLong.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFBadmintonRepository badmintonRepository;

        public HomeController(ILogger<HomeController> logger, EFBadmintonRepository badmintonRepository)
        {
            _logger = logger;
            this.badmintonRepository = badmintonRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachDoiTuyen()
        {
            var doiTuyens = await badmintonRepository.GetDoiTuyensAsync();
            return View(doiTuyens);
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachTrongTai()
        {
            var trongTais = await badmintonRepository.GetTrongTaisAsync();
            return View(trongTais);
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachTranDau()
        {
            var tranDaus = await badmintonRepository.GetTranDausAsync();
            return View(tranDaus);
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachVDV()
        {
            var vdvs = await badmintonRepository.GetVanDongViensAsync();
            return View(vdvs);
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachGiaiDau()
        {
            var giaiDaus = await badmintonRepository.GetGiaiDausAsync();
            return View(giaiDaus);
        }

        public IActionResult TimKiemVdv()
        {
            return View(new KetQuaTimKiemVdvViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> TimKiemVdv([FromBody] string keyword)
        {
            var viewModel = new KetQuaTimKiemVdvViewModel { TuKhoaTimKiem = keyword };

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return View(viewModel);
            }

            var vanDongViens = await badmintonRepository.GetVanDongViensByNameAsync(keyword);

            if (!vanDongViens.Any())
            {
                return View(viewModel);
            }

            foreach (var vdv in vanDongViens)
            {
                var tranDauThangVDV = await badmintonRepository.GetTranDauThangVDVAsync(vdv.MaVDV);
                
                int tongDiem = TinhTongDiem(vdv, tranDauThangVDV.ToList());

                viewModel.DanhSachKetQua.Add(new VdvVaDiem
                {
                    VanDongVien = vdv,
                    TongDiem = tongDiem,
                    CacTranDauThang = tranDauThangVDV.ToList()
                });
                Console.WriteLine(tongDiem.ToString());


            }

            return View(viewModel);
        }

        private int TinhTongDiem(VanDongVien vdv, List<TranDau> tranDauThang)
        {
            int diem = 0;
            foreach (var tran in tranDauThang)
            {
                string loaiGiai = tran.LichThiDau!.GiaiDau!.LoaiGiai;
                string vongDau = tran.VongDau;

                if (loaiGiai == "Đơn Nam" || loaiGiai == "Đơn Nữ")
                {
                    if (vongDau == "Vòng loại") diem += 200;
                    else if (vongDau == "Tứ kết") diem += 300;
                    else if (vongDau == "Bán kết") diem += 400;
                    else if (vongDau == "Chung kết") diem += 500;
                }
                else
                {
                    if (vongDau == "Vòng loại") diem += 150;
                    else if (vongDau == "Tứ kết") diem += 250;
                    else if (vongDau == "Bán kết") diem += 350;
                    else if (vongDau == "Chung kết") diem += 450;
                }
            }
            return diem;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
