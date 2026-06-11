using GioChuanGiangDay.Data;
using GioChuanGiangDay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GioChuanGiangDay.Controllers
{
    public class HoatDongQuyDoiController : Controller
    {
        private readonly AppDbContext _context;

        public HoatDongQuyDoiController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.HoatDongQuyDoiChiTiets
                .Include(x => x.GiangVien)
                .Include(x => x.DmHoatDongQuyDoi)
                .OrderByDescending(x => x.NgayTao)
                .ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            await LoadCombobox();

            var model = new HoatDongQuyDoiChiTiet
            {
                NamHoc = "2025-2026",
                SoLuong = 1,
                HeSo = 1,
                TyLeDongGop = 100
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HoatDongQuyDoiChiTiet model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCombobox(model.GiangVienId, model.DmHoatDongQuyDoiId);
                return View(model);
            }

            var result = await TinhGioHoatDongAsync(model);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                await LoadCombobox(model.GiangVienId, model.DmHoatDongQuyDoiId);
                return View(model);
            }

            model.TrangThaiDuyet = "NHAP";
            model.NgayTao = DateTime.Now;

            _context.HoatDongQuyDoiChiTiets.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.HoatDongQuyDoiChiTiets
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            await LoadCombobox(model.GiangVienId, model.DmHoatDongQuyDoiId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HoatDongQuyDoiChiTiet model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await LoadCombobox(model.GiangVienId, model.DmHoatDongQuyDoiId);
                return View(model);
            }

            var result = await TinhGioHoatDongAsync(model);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                await LoadCombobox(model.GiangVienId, model.DmHoatDongQuyDoiId);
                return View(model);
            }

            _context.HoatDongQuyDoiChiTiets.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.HoatDongQuyDoiChiTiets.FindAsync(id);

            if (item != null)
            {
                _context.HoatDongQuyDoiChiTiets.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<(bool Success, string Message)> TinhGioHoatDongAsync(HoatDongQuyDoiChiTiet model)
        {
            var dm = await _context.DmHoatDongQuyDois
                .FirstOrDefaultAsync(x => x.Id == model.DmHoatDongQuyDoiId);

            if (dm == null)
            {
                return (false, "Không tìm thấy danh mục hoạt động quy đổi.");
            }

            model.GioQuyDoiMacDinh = dm.GioQuyDoiMacDinh;
            model.HeSo = model.HeSo <= 0 ? dm.HeSoMacDinh : model.HeSo;

            if (!dm.CanTyLeDongGop)
            {
                model.TyLeDongGop = 100;
            }

            model.GioDuocTinh =
                model.SoLuong
                * model.GioQuyDoiMacDinh
                * model.HeSo
                * model.TyLeDongGop / 100;

            return (true, "");
        }

        private async Task LoadCombobox(int? giangVienId = null, int? dmHoatDongId = null)
        {
            var giangViens = await _context.GiangViens
                .OrderBy(x => x.HoTen)
                .ToListAsync();

            ViewBag.GiangVienId = new SelectList(
                giangViens,
                "Id",
                "HoTen",
                giangVienId
            );

            var hoatDongs = await _context.DmHoatDongQuyDois
                .OrderBy(x => x.NhomHoatDong)
                .ThenBy(x => x.TenHoatDong)
                .ToListAsync();

            ViewBag.DmHoatDongQuyDoiId = new SelectList(
                hoatDongs,
                "Id",
                "TenHoatDong",
                dmHoatDongId
            );
        }
    }
}