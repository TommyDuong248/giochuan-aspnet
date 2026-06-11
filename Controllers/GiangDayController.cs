using GioChuanGiangDay.Data;
using GioChuanGiangDay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GioChuanGiangDay.Controllers
{
    public class GiangDayController : Controller
    {
        private readonly AppDbContext _context;

        public GiangDayController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.GiangDayChiTiets
                .Include(x => x.GiangVien)
                .OrderByDescending(x => x.NgayTao)
                .ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            await LoadGiangVienList();

            var model = new GiangDayChiTiet
            {
                NamHoc = "2025-2026",
                HocKy = "HK1"
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GiangDayChiTiet model)
        {
            if (!ModelState.IsValid)
            {
                await LoadGiangVienList(model.GiangVienId);
                return View(model);
            }

            await TinhGioGiangDayAsync(model);

            model.TrangThaiDuyet = "NHAP";
            model.NgayTao = DateTime.Now;

            _context.GiangDayChiTiets.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.GiangDayChiTiets
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            await LoadGiangVienList(model.GiangVienId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GiangDayChiTiet model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await LoadGiangVienList(model.GiangVienId);
                return View(model);
            }

            await TinhGioGiangDayAsync(model);

            _context.GiangDayChiTiets.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.GiangDayChiTiets.FindAsync(id);

            if (item != null)
            {
                _context.GiangDayChiTiets.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadGiangVienList(int? selectedGiangVienId = null)
        {
            var giangViens = await _context.GiangViens
                .OrderBy(x => x.HoTen)
                .ToListAsync();

            ViewBag.GiangVienId = new SelectList(
                giangViens,
                "Id",
                "HoTen",
                selectedGiangVienId
            );
        }

        private async Task TinhGioGiangDayAsync(GiangDayChiTiet model)
        {
            model.HeSoSiSo = await LayHeSoSiSoAsync(model.SiSo);

            model.GioQuyDoiLyThuyet =
                model.SoTietLyThuyet * model.HeSoSiSo;

            model.GioQuyDoiThucHanh =
                model.SoTietThucHanh;

            model.TongGioQuyDoi =
                model.GioQuyDoiLyThuyet + model.GioQuyDoiThucHanh;
        }

        private async Task<decimal> LayHeSoSiSoAsync(int siSo)
        {
            var heSo = await _context.DmHeSoSiSos
                .Where(x =>
                    siSo >= x.SiSoTu &&
                    (x.SiSoDen == null || siSo <= x.SiSoDen))
                .OrderBy(x => x.SiSoTu)
                .FirstOrDefaultAsync();

            return heSo?.HeSo ?? 1.0m;
        }
    }
}