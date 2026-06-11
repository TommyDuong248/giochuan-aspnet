using GioChuanGiangDay.Data;
using GioChuanGiangDay.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GioChuanGiangDay.Controllers
{
    public class TongHopController : Controller
    {
        private readonly AppDbContext _context;

        public TongHopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? giangVienId, string? namHoc)
        {
            namHoc = string.IsNullOrWhiteSpace(namHoc) ? "2025-2026" : namHoc;

            var giangViens = await _context.GiangViens
                .OrderBy(x => x.HoTen)
                .ToListAsync();

            ViewBag.GiangVienId = new SelectList(
                giangViens,
                "Id",
                "HoTen",
                giangVienId
            );

            ViewBag.NamHoc = namHoc;

            if (giangVienId == null)
            {
                return View(null);
            }

            var gv = await _context.GiangViens
                .FirstOrDefaultAsync(x => x.Id == giangVienId.Value);

            if (gv == null)
            {
                return NotFound();
            }

            // Luôn lấy định mức gốc theo chức danh và trình độ,
            // chưa áp dụng chế độ giảm.
            var dinhMuc = await _context.DmGioChuans
                .FirstOrDefaultAsync(x =>
                    x.MaChucDanh == gv.MaChucDanh &&
                    x.TrinhDo == gv.TrinhDo &&
                    x.LaTapSu == false &&
                    x.NamApDung == namHoc);

            // SQLite không SUM trực tiếp được decimal,
            // nên phải lấy dữ liệu về List rồi Sum bằng C#.

            var listGioGiangDayTrucTiep = await _context.GiangDayChiTiets
                .Where(x =>
                    x.GiangVienId == giangVienId.Value &&
                    x.NamHoc == namHoc)
                .Select(x => x.TongGioQuyDoi)
                .ToListAsync();

            var gioGiangDayTrucTiep = listGioGiangDayTrucTiep.Sum();

            var listGioHuongDanVaGiangDayKhac = await _context.HoatDongQuyDoiChiTiets
                .Where(x =>
                    x.GiangVienId == giangVienId.Value &&
                    x.NamHoc == namHoc &&
                    x.DmHoatDongQuyDoi != null &&
                    x.DmHoatDongQuyDoi.NhomHoatDong == "GIANG_DAY_KHAC")
                .Select(x => x.GioDuocTinh)
                .ToListAsync();

            var gioHuongDanVaGiangDayKhac = listGioHuongDanVaGiangDayKhac.Sum();

            var listGioHoiDong = await _context.HoatDongQuyDoiChiTiets
                .Where(x =>
                    x.GiangVienId == giangVienId.Value &&
                    x.NamHoc == namHoc &&
                    x.DmHoatDongQuyDoi != null &&
                    x.DmHoatDongQuyDoi.NhomHoatDong == "HOI_DONG")
                .Select(x => x.GioDuocTinh)
                .ToListAsync();

            var gioHoiDong = listGioHoiDong.Sum();

            var listGioNckh = await _context.HoatDongQuyDoiChiTiets
                .Where(x =>
                    x.GiangVienId == giangVienId.Value &&
                    x.NamHoc == namHoc &&
                    x.DmHoatDongQuyDoi != null &&
                    x.DmHoatDongQuyDoi.NhomHoatDong == "NCKH")
                .Select(x => x.GioDuocTinh)
                .ToListAsync();

            var gioNckh = listGioNckh.Sum();

            var listGioNhiemVuKhac = await _context.HoatDongQuyDoiChiTiets
                .Where(x =>
                    x.GiangVienId == giangVienId.Value &&
                    x.NamHoc == namHoc &&
                    x.DmHoatDongQuyDoi != null &&
                    x.DmHoatDongQuyDoi.NhomHoatDong == "NHIEM_VU_KHAC")
                .Select(x => x.GioDuocTinh)
                .ToListAsync();

            var gioNhiemVuKhac = listGioNhiemVuKhac.Sum();
            decimal gioChuanGiangDaySauGiam = dinhMuc?.GioChuanGiangDay ?? 0;
            decimal gioChuanNckhSauGiam = dinhMuc?.GioChuanNckh ?? 0;

            var ghiChuMienGiam = "";

            if (gv.LaTapSu || gv.DangHocNghienCuuSinh)
            {
                gioChuanGiangDaySauGiam = gioChuanGiangDaySauGiam * 0.5m;
                gioChuanNckhSauGiam = 0;

                if (gv.LaTapSu && gv.DangHocNghienCuuSinh)
                {
                    ghiChuMienGiam = "Giảng viên tập sự và đang học nghiên cứu sinh: giảm 50% giờ chuẩn giảng dạy, miễn giờ NCKH.";
                }
                else if (gv.LaTapSu)
                {
                    ghiChuMienGiam = "Giảng viên tập sự: giảm 50% giờ chuẩn giảng dạy, miễn giờ NCKH.";
                }
                else if (gv.DangHocNghienCuuSinh)
                {
                    ghiChuMienGiam = "Giảng viên đang học nghiên cứu sinh: giảm 50% giờ chuẩn giảng dạy, miễn giờ NCKH.";
                }
            }
            var model = new TongHopGioChuanViewModel
            {
                GiangVienId = gv.Id,
                HoTen = gv.HoTen,
                MaGiangVien = gv.MaGiangVien,
                NamHoc = namHoc,

                GioChuanGiangDay = gioChuanGiangDaySauGiam,
                GioChuanNckh = gioChuanNckhSauGiam,

                GioGiangDayTrucTiep = gioGiangDayTrucTiep,
                GioHuongDanVaGiangDayKhac = gioHuongDanVaGiangDayKhac,
                GioHoiDong = gioHoiDong,
                GioNckh = gioNckh,
                GioNhiemVuKhac = gioNhiemVuKhac,

                DaCauHinhDinhMuc = dinhMuc != null
            };
            if (!string.IsNullOrWhiteSpace(ghiChuMienGiam))
            {
                model.GhiChu = ghiChuMienGiam;
            }
            if (dinhMuc == null)
            {
                model.GhiChu =
                "Chưa cấu hình định mức giờ chuẩn cho chức danh/trình độ của giảng viên trong năm học này.";
            }
            else if (!string.IsNullOrWhiteSpace(ghiChuMienGiam))
            {
            model.GhiChu = ghiChuMienGiam;
            }

            return View(model);
        }
    }
}