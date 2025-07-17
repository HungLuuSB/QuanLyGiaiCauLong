using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
namespace QuanLyGiaiCauLong.Models
{
    public class BadmintonDbContext : DbContext
    {
        public BadmintonDbContext(DbContextOptions<BadmintonDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TranDau>()
                .HasOne(t => t.LichThiDau)
                .WithMany()
                .HasForeignKey(t => t.MaLich)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TranDau>()
                .HasOne(t => t.TrongTai)
                .WithMany()
                .HasForeignKey(t => t.MaTT)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TranDau>()
                .HasOne(t => t.VanDongVien1)
                .WithMany()
                .HasForeignKey(t => t.MaVDV1)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TranDau>()
                .HasOne(t => t.VanDongVien2)
                .WithMany()
                .HasForeignKey(t => t.MaVDV2)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TranDau>()
                .HasOne(t => t.VanDongVien3)
                .WithMany()
                .HasForeignKey(t => t.MaVDV3)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TranDau>()
                .HasOne(t => t.VanDongVien4)
                .WithMany()
                .HasForeignKey(t => t.MaVDV4)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);


            // SEED DATA(may consider adding more. Depends hhjhj)
            modelBuilder.Entity<DoiTuyen>().HasData(
                new DoiTuyen { MaDoi = "DT01", TenDoi = "Đội Hà Nội", MaHLV = "HLV01" },
                new DoiTuyen { MaDoi = "DT02", TenDoi = "Đội TP.HCM", MaHLV = "HLV02" },
                new DoiTuyen { MaDoi = "DT03", TenDoi = "Đội Đà Nẵng", MaHLV = "HLV03" }
            );

            modelBuilder.Entity<VanDongVien>().HasData(
                new VanDongVien { MaVDV = "VDV01", HoTen = "Lưu Thái Hưng", NamSinh = 2005, GioiTinh = "Nam", MaDoi = "DT01" },
                new VanDongVien { MaVDV = "VDV02", HoTen = "Trần Tuấn Phương", NamSinh = 2005, GioiTinh = "Nam", MaDoi = "DT02" },
                new VanDongVien { MaVDV = "VDV03", HoTen = "Lê Đỗ Huy Hùng", NamSinh = 2003, GioiTinh = "Nam", MaDoi = "DT02" },
                new VanDongVien { MaVDV = "VDV04", HoTen = "Lê Văn Hào Kiệt", NamSinh = 2004, GioiTinh = "Nữ", MaDoi = "DT02" },
                new VanDongVien { MaVDV = "VDV05", HoTen = "Phan Trần Quốc Huy", NamSinh = 2005, GioiTinh = "Nữ", MaDoi = "DT03" },
                new VanDongVien { MaVDV = "VDV06", HoTen = "Skibidi Toilet", NamSinh = 1999, GioiTinh = "Nữ", MaDoi = "DT03" }
            );

            modelBuilder.Entity<HLVTruong>().HasData(
                new HLVTruong { MaHLV = "HLV01", HoTen = "Cao Tiến Thành", NgaySinh = new DateTime(1995, 10, 1), SDT = "077123456", ChuyenMon = "Thể lực" },
                new HLVTruong { MaHLV = "HLV02", HoTen = "Lương Văn Minh", NgaySinh = new DateTime(1903, 5, 2), SDT = "077123789", ChuyenMon = "Trí tuệ nhân tạo" },
                new HLVTruong { MaHLV = "HLV03", HoTen = "Wibu Chúa", NgaySinh = new DateTime(1995, 10, 1), SDT = "077789012", ChuyenMon = "Thống kê" }
            );

            modelBuilder.Entity<TrongTai>().HasData(
                new TrongTai { MaTT = "TT01", HoTen = "Nguyễn Thị Thu", SoTran = 17, HeSoLuong = 1.2f, LuongCoBan = 800000 },
                new TrongTai { MaTT = "TT02", HoTen = "Phan Minh Đức", SoTran = 22, HeSoLuong = 1.4f, LuongCoBan = 500000 },
                new TrongTai { MaTT = "TT03", HoTen = "Hoàng Anh Tuấn", SoTran = 13, HeSoLuong = 1f, LuongCoBan = 400000 }
            );

            modelBuilder.Entity<GiaiDau>().HasData(
                new GiaiDau { MaGiai = "GD01", TenGiai = "Giải Cầu Lông Quốc Gia", LoaiGiai = "Đơn Nam", ThoiGian = new DateTime(2025, 3, 10), DiaDiem = "Thành phố Hồ Chí Minh" },
                new GiaiDau { MaGiai = "GD02", TenGiai = "Giải Vô Địch Trẻ", LoaiGiai = "Đơn Nữ", ThoiGian = new DateTime(2025, 5, 15), DiaDiem = "Thành phố Hồ Chí Minh" },
                new GiaiDau { MaGiai = "GD03", TenGiai = "Giải Mở Rộng TP.HCM", LoaiGiai = "Đôi Nam Nữ", ThoiGian = new DateTime(2025, 7, 20), DiaDiem = "Thành phố Hồ Chí Minh" }
            );

            modelBuilder.Entity<LichThiDau>().HasData(
                new LichThiDau { MaLich = "LTD01", DiaDiem = "Sân cầu lông HUFLIT Hóc Môn", MaGiai = "GD01", NgayThiDau = new DateTime(2025, 7, 20) },
                new LichThiDau { MaLich = "LTD02", DiaDiem = "Nhà thi đấu Lê Quang Đạo", MaGiai = "GD02", NgayThiDau = new DateTime(2025, 7, 21) },
                new LichThiDau { MaLich = "LTD03", DiaDiem = "Nhà thi đấu Hòa Bình", MaGiai = "GD03", NgayThiDau = new DateTime(2025, 8, 5) }
            );

            modelBuilder.Entity<TranDau>().HasData(
                new TranDau
                {
                    MaTran = "TD01",
                    VongDau = "Vòng loại",
                    MaLich = "LTD01",
                    MaTT = "TT01",
                    MaVDV1 = "VDV01",
                    MaVDV2 = null,
                    MaVDV3 = "VDV02",
                    MaVDV4 = null,
                    KetQua = "2-1"
                },
                new TranDau
                {
                    MaTran = "TD02",
                    VongDau = "Vòng tứ kết",
                    MaLich = "LTD02",
                    MaTT = "TT02",
                    MaVDV1 = "VDV04",
                    MaVDV2 = null,
                    MaVDV3 = "VDV05",
                    MaVDV4 = null,
                    KetQua = "2-0"
                },
                new TranDau
                {
                    MaTran = "TD03",
                    VongDau = "Chung kết",
                    MaLich = "LTD03",
                    MaTT = "TT03",
                    MaVDV1 = "VDV03",
                    MaVDV2 = "VDV04",
                    MaVDV3 = "VDV05",
                    MaVDV4 = "VDV06",
                    KetQua = "1-2"
                }
            );
        }

        public DbSet<HLVTruong>? HLVTruongs { get; set; }
        public DbSet<DoiTuyen>? DoiTuyens { get; set; }
        public DbSet<VanDongVien>? VanDongViens { get; set; }
        public DbSet<TrongTai>? TrongTais { get; set; }
        public DbSet<LichThiDau>? LichThiDaus { get; set; }
        public DbSet<TranDau>? TranDaus { get; set; }
        public DbSet<GiaiDau>? GiaiDaus { get; set; }
    }
}
