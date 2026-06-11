using ClosedXML.Excel;
using GioChuanGiangDay.Data;
using GioChuanGiangDay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GioChuanGiangDay.Controllers
{
    public class GiangVienController : Controller
    {
        private readonly AppDbContext _context;

        public GiangVienController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.GiangViens
                .OrderBy(x => x.HoTen)
                .ToListAsync();

            return View(data);
        }

        public IActionResult Create()
        {
            return View(new GiangVien
            {
                DangLamViec = true
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GiangVien model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.GiangViens.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.GiangViens
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GiangVien model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.GiangViens.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var giangVien = await _context.GiangViens.FindAsync(id);

            if (giangVien != null)
            {
                _context.GiangViens.Remove(giangVien);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // ===== IMPORT EXCEL =====

        private static readonly Dictionary<string, string> ChucDanhMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["GV_HANG_I"] = "GV_HANG_I",
            ["Giảng viên hạng I"] = "GV_HANG_I",
            ["GV_HANG_II"] = "GV_HANG_II",
            ["Giảng viên hạng II"] = "GV_HANG_II",
            ["GV_HANG_III"] = "GV_HANG_III",
            ["Giảng viên hạng III"] = "GV_HANG_III",
            ["TRO_GIANG"] = "TRO_GIANG",
            ["Trợ giảng"] = "TRO_GIANG",
        };

        private static readonly Dictionary<string, string> TrinhDoMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["TIEN_SI"] = "TIEN_SI",
            ["Tiến sĩ"] = "TIEN_SI",
            ["THAC_SI"] = "THAC_SI",
            ["Thạc sĩ"] = "THAC_SI",
            ["KHAC"] = "KHAC",
            ["Khác"] = "KHAC",
        };

        private static bool ParseBool(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            value = value.Trim();
            return value.Equals("x", StringComparison.OrdinalIgnoreCase)
                || value.Equals("có", StringComparison.OrdinalIgnoreCase)
                || value.Equals("co", StringComparison.OrdinalIgnoreCase)
                || value.Equals("1")
                || value.Equals("true", StringComparison.OrdinalIgnoreCase)
                || value.Equals("yes", StringComparison.OrdinalIgnoreCase);
        }

        public IActionResult DownloadTemplate()
        {
            using var workbook = new XLWorkbook();

            // Sheet nhập liệu
            var ws = workbook.Worksheets.Add("GiangVien");
            string[] headers =
            {
                "Mã giảng viên (*)", "Họ tên (*)", "Khoa", "Bộ môn",
                "Chức danh (*)", "Trình độ (*)",
                "Tập sự (x = Có)", "Đang học NCS (x = Có)", "Đang làm việc (x = Có)"
            };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(1, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#D9E1F2");
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            // Dòng ví dụ
            ws.Cell(2, 1).Value = "GV001";
            ws.Cell(2, 2).Value = "Nguyễn Văn A";
            ws.Cell(2, 3).Value = "Công nghệ thông tin";
            ws.Cell(2, 4).Value = "Khoa học máy tính";
            ws.Cell(2, 5).Value = "Giảng viên hạng III";
            ws.Cell(2, 6).Value = "Thạc sĩ";
            ws.Cell(2, 7).Value = "";
            ws.Cell(2, 8).Value = "";
            ws.Cell(2, 9).Value = "x";

            // Sheet danh mục (nguồn cho dropdown)
            var wsDm = workbook.Worksheets.Add("DanhMuc");
            wsDm.Cell(1, 1).Value = "Chức danh";
            wsDm.Cell(2, 1).Value = "Giảng viên hạng I";
            wsDm.Cell(3, 1).Value = "Giảng viên hạng II";
            wsDm.Cell(4, 1).Value = "Giảng viên hạng III";
            wsDm.Cell(5, 1).Value = "Trợ giảng";
            wsDm.Cell(1, 2).Value = "Trình độ";
            wsDm.Cell(2, 2).Value = "Tiến sĩ";
            wsDm.Cell(3, 2).Value = "Thạc sĩ";
            wsDm.Cell(4, 2).Value = "Khác";
            wsDm.Hide();

            // Dropdown validation cho 500 dòng
            var chucDanhRange = ws.Range("E2:E501");
            chucDanhRange.CreateDataValidation().List(wsDm.Range("A2:A5"), true);
            var trinhDoRange = ws.Range("F2:F501");
            trinhDoRange.CreateDataValidation().List(wsDm.Range("B2:B4"), true);

            ws.Columns(1, 9).AdjustToContents();
            ws.SheetView.FreezeRows(1);

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Template_GiangVien.xlsx");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile? file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["ImportError"] = "Vui lòng chọn file Excel (.xlsx) để import.";
                return RedirectToAction(nameof(Index));
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                TempData["ImportError"] = "File không đúng định dạng. Chỉ chấp nhận file .xlsx.";
                return RedirectToAction(nameof(Index));
            }

            var errors = new List<string>();
            int created = 0, updated = 0;

            try
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                using var workbook = new XLWorkbook(stream);

                var ws = workbook.Worksheets.FirstOrDefault(w => w.Name == "GiangVien")
                         ?? workbook.Worksheets.First();

                var existing = await _context.GiangViens
                    .ToDictionaryAsync(x => x.MaGiangVien.Trim(), StringComparer.OrdinalIgnoreCase);

                var seenInFile = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (var row in ws.RowsUsed().Skip(1)) // bỏ dòng tiêu đề
                {
                    int rowNum = row.RowNumber();

                    var maGv = row.Cell(1).GetString().Trim();
                    var hoTen = row.Cell(2).GetString().Trim();
                    var khoa = row.Cell(3).GetString().Trim();
                    var boMon = row.Cell(4).GetString().Trim();
                    var chucDanhRaw = row.Cell(5).GetString().Trim();
                    var trinhDoRaw = row.Cell(6).GetString().Trim();

                    // Bỏ qua dòng trống hoàn toàn
                    if (string.IsNullOrEmpty(maGv) && string.IsNullOrEmpty(hoTen))
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(maGv))
                    {
                        errors.Add($"Dòng {rowNum}: thiếu Mã giảng viên.");
                        continue;
                    }
                    if (string.IsNullOrEmpty(hoTen))
                    {
                        errors.Add($"Dòng {rowNum}: thiếu Họ tên.");
                        continue;
                    }
                    if (!ChucDanhMap.TryGetValue(chucDanhRaw, out var maChucDanh))
                    {
                        errors.Add($"Dòng {rowNum}: Chức danh '{System.Net.WebUtility.HtmlEncode(chucDanhRaw)}' không hợp lệ.");
                        continue;
                    }
                    if (!TrinhDoMap.TryGetValue(trinhDoRaw, out var trinhDo))
                    {
                        errors.Add($"Dòng {rowNum}: Trình độ '{System.Net.WebUtility.HtmlEncode(trinhDoRaw)}' không hợp lệ.");
                        continue;
                    }
                    if (!seenInFile.Add(maGv))
                    {
                        errors.Add($"Dòng {rowNum}: Mã giảng viên '{System.Net.WebUtility.HtmlEncode(maGv)}' bị trùng trong file.");
                        continue;
                    }

                    bool laTapSu = ParseBool(row.Cell(7).GetString());
                    bool dangHocNcs = ParseBool(row.Cell(8).GetString());
                    bool dangLamViec = ParseBool(row.Cell(9).GetString());

                    if (existing.TryGetValue(maGv, out var gv))
                    {
                        // Cập nhật giảng viên đã có
                        gv.HoTen = hoTen;
                        gv.Khoa = string.IsNullOrEmpty(khoa) ? null : khoa;
                        gv.BoMon = string.IsNullOrEmpty(boMon) ? null : boMon;
                        gv.MaChucDanh = maChucDanh;
                        gv.TrinhDo = trinhDo;
                        gv.LaTapSu = laTapSu;
                        gv.DangHocNghienCuuSinh = dangHocNcs;
                        gv.DangLamViec = dangLamViec;
                        updated++;
                    }
                    else
                    {
                        _context.GiangViens.Add(new GiangVien
                        {
                            MaGiangVien = maGv,
                            HoTen = hoTen,
                            Khoa = string.IsNullOrEmpty(khoa) ? null : khoa,
                            BoMon = string.IsNullOrEmpty(boMon) ? null : boMon,
                            MaChucDanh = maChucDanh,
                            TrinhDo = trinhDo,
                            LaTapSu = laTapSu,
                            DangHocNghienCuuSinh = dangHocNcs,
                            DangLamViec = dangLamViec
                        });
                        created++;
                    }
                }

                if (created + updated > 0)
                {
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                TempData["ImportError"] = "Không đọc được file. Hãy chắc chắn file đúng định dạng template.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ImportSuccess"] = $"Import xong: thêm mới {created}, cập nhật {updated} giảng viên.";
            if (errors.Any())
            {
                TempData["ImportError"] = $"{errors.Count} dòng bị bỏ qua:<br/>" + string.Join("<br/>", errors.Take(20))
                    + (errors.Count > 20 ? $"<br/>... và {errors.Count - 20} lỗi khác." : "");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}