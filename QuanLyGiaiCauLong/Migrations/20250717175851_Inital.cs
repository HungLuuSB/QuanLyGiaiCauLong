using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyGiaiCauLong.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaiDaus",
                columns: table => new
                {
                    MaGiai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenGiai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiGiai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiDaus", x => x.MaGiai);
                });

            migrationBuilder.CreateTable(
                name: "HLVTruongs",
                columns: table => new
                {
                    MaHLV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HLVTruongs", x => x.MaHLV);
                });

            migrationBuilder.CreateTable(
                name: "TrongTais",
                columns: table => new
                {
                    MaTT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTran = table.Column<int>(type: "int", nullable: false),
                    HeSoLuong = table.Column<float>(type: "real", nullable: false),
                    LuongCoBan = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrongTais", x => x.MaTT);
                });

            migrationBuilder.CreateTable(
                name: "LichThiDaus",
                columns: table => new
                {
                    MaLich = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaGiai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayThiDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichThiDaus", x => x.MaLich);
                    table.ForeignKey(
                        name: "FK_LichThiDaus_GiaiDaus_MaGiai",
                        column: x => x.MaGiai,
                        principalTable: "GiaiDaus",
                        principalColumn: "MaGiai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoiTuyens",
                columns: table => new
                {
                    MaDoi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaHLV = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiTuyens", x => x.MaDoi);
                    table.ForeignKey(
                        name: "FK_DoiTuyens_HLVTruongs_MaHLV",
                        column: x => x.MaHLV,
                        principalTable: "HLVTruongs",
                        principalColumn: "MaHLV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VanDongViens",
                columns: table => new
                {
                    MaVDV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamSinh = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDoi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Diem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanDongViens", x => x.MaVDV);
                    table.ForeignKey(
                        name: "FK_VanDongViens_DoiTuyens_MaDoi",
                        column: x => x.MaDoi,
                        principalTable: "DoiTuyens",
                        principalColumn: "MaDoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranDaus",
                columns: table => new
                {
                    MaTran = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VongDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLich = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaTT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaVDV1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaVDV2 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaVDV3 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaVDV4 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LichThiDauMaLich = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranDaus", x => x.MaTran);
                    table.ForeignKey(
                        name: "FK_TranDaus_LichThiDaus_LichThiDauMaLich",
                        column: x => x.LichThiDauMaLich,
                        principalTable: "LichThiDaus",
                        principalColumn: "MaLich");
                    table.ForeignKey(
                        name: "FK_TranDaus_LichThiDaus_MaLich",
                        column: x => x.MaLich,
                        principalTable: "LichThiDaus",
                        principalColumn: "MaLich",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_TrongTais_MaTT",
                        column: x => x.MaTT,
                        principalTable: "TrongTais",
                        principalColumn: "MaTT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_VanDongViens_MaVDV1",
                        column: x => x.MaVDV1,
                        principalTable: "VanDongViens",
                        principalColumn: "MaVDV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_VanDongViens_MaVDV2",
                        column: x => x.MaVDV2,
                        principalTable: "VanDongViens",
                        principalColumn: "MaVDV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_VanDongViens_MaVDV3",
                        column: x => x.MaVDV3,
                        principalTable: "VanDongViens",
                        principalColumn: "MaVDV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_VanDongViens_MaVDV4",
                        column: x => x.MaVDV4,
                        principalTable: "VanDongViens",
                        principalColumn: "MaVDV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GiaiDaus",
                columns: new[] { "MaGiai", "DiaDiem", "LoaiGiai", "TenGiai", "ThoiGian" },
                values: new object[,]
                {
                    { "GD01", "Thành phố Hồ Chí Minh", "Đơn Nam", "Giải Cầu Lông Quốc Gia", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "GD02", "Thành phố Hồ Chí Minh", "Đơn Nữ", "Giải Vô Địch Trẻ", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "GD03", "Thành phố Hồ Chí Minh", "Đôi Nam Nữ", "Giải Mở Rộng TP.HCM", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HLVTruongs",
                columns: new[] { "MaHLV", "ChuyenMon", "HoTen", "NgaySinh", "SDT" },
                values: new object[,]
                {
                    { "HLV01", "Thể lực", "Cao Tiến Thành", new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "077123456" },
                    { "HLV02", "Trí tuệ nhân tạo", "Lương Văn Minh", new DateTime(1903, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "077123789" },
                    { "HLV03", "Thống kê", "Wibu Chúa", new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "077789012" }
                });

            migrationBuilder.InsertData(
                table: "TrongTais",
                columns: new[] { "MaTT", "HeSoLuong", "HoTen", "LuongCoBan", "SoTran" },
                values: new object[,]
                {
                    { "TT01", 1.2f, "Nguyễn Thị Thu", 800000f, 17 },
                    { "TT02", 1.4f, "Phan Minh Đức", 500000f, 22 },
                    { "TT03", 1f, "Hoàng Anh Tuấn", 400000f, 13 }
                });

            migrationBuilder.InsertData(
                table: "DoiTuyens",
                columns: new[] { "MaDoi", "MaHLV", "TenDoi" },
                values: new object[,]
                {
                    { "DT01", "HLV01", "Đội Hà Nội" },
                    { "DT02", "HLV02", "Đội TP.HCM" },
                    { "DT03", "HLV03", "Đội Đà Nẵng" }
                });

            migrationBuilder.InsertData(
                table: "LichThiDaus",
                columns: new[] { "MaLich", "DiaDiem", "MaGiai", "NgayThiDau" },
                values: new object[,]
                {
                    { "LTD01", "Sân cầu lông HUFLIT Hóc Môn", "GD01", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "LTD02", "Nhà thi đấu Lê Quang Đạo", "GD02", new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "LTD03", "Nhà thi đấu Hòa Bình", "GD03", new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "VanDongViens",
                columns: new[] { "MaVDV", "Diem", "GioiTinh", "HoTen", "MaDoi", "NamSinh" },
                values: new object[,]
                {
                    { "VDV01", 0, "Nam", "Lưu Thái Hưng", "DT01", 2005 },
                    { "VDV02", 0, "Nam", "Trần Tuấn Phương", "DT02", 2005 },
                    { "VDV03", 0, "Nam", "Lê Đỗ Huy Hùng", "DT02", 2003 },
                    { "VDV04", 0, "Nữ", "Lê Văn Hào Kiệt", "DT02", 2004 },
                    { "VDV05", 0, "Nữ", "Phan Trần Quốc Huy", "DT03", 2005 },
                    { "VDV06", 0, "Nữ", "Skibidi Toilet", "DT03", 1999 }
                });

            migrationBuilder.InsertData(
                table: "TranDaus",
                columns: new[] { "MaTran", "KetQua", "LichThiDauMaLich", "MaLich", "MaTT", "MaVDV1", "MaVDV2", "MaVDV3", "MaVDV4", "VongDau" },
                values: new object[] { "TD01", "2-1", null, "LTD01", "TT01", "VDV01", null, "VDV02", null, "Vòng 1" });

            migrationBuilder.InsertData(
                table: "TranDaus",
                columns: new[] { "MaTran", "KetQua", "LichThiDauMaLich", "MaLich", "MaTT", "MaVDV1", "MaVDV2", "MaVDV3", "MaVDV4", "VongDau" },
                values: new object[] { "TD02", "2-0", null, "LTD02", "TT02", "VDV04", null, "VDV05", null, "Vòng 2" });

            migrationBuilder.InsertData(
                table: "TranDaus",
                columns: new[] { "MaTran", "KetQua", "LichThiDauMaLich", "MaLich", "MaTT", "MaVDV1", "MaVDV2", "MaVDV3", "MaVDV4", "VongDau" },
                values: new object[] { "TD03", "1-2", null, "LTD03", "TT03", "VDV03", "VDV04", "VDV05", "VDV06", "Chung kết" });

            migrationBuilder.CreateIndex(
                name: "IX_DoiTuyens_MaHLV",
                table: "DoiTuyens",
                column: "MaHLV");

            migrationBuilder.CreateIndex(
                name: "IX_LichThiDaus_MaGiai",
                table: "LichThiDaus",
                column: "MaGiai");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_LichThiDauMaLich",
                table: "TranDaus",
                column: "LichThiDauMaLich");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_MaLich",
                table: "TranDaus",
                column: "MaLich");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_MaTT",
                table: "TranDaus",
                column: "MaTT");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_MaVDV1",
                table: "TranDaus",
                column: "MaVDV1");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_MaVDV2",
                table: "TranDaus",
                column: "MaVDV2");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_MaVDV3",
                table: "TranDaus",
                column: "MaVDV3");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_MaVDV4",
                table: "TranDaus",
                column: "MaVDV4");

            migrationBuilder.CreateIndex(
                name: "IX_VanDongViens_MaDoi",
                table: "VanDongViens",
                column: "MaDoi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranDaus");

            migrationBuilder.DropTable(
                name: "LichThiDaus");

            migrationBuilder.DropTable(
                name: "TrongTais");

            migrationBuilder.DropTable(
                name: "VanDongViens");

            migrationBuilder.DropTable(
                name: "GiaiDaus");

            migrationBuilder.DropTable(
                name: "DoiTuyens");

            migrationBuilder.DropTable(
                name: "HLVTruongs");
        }
    }
}
