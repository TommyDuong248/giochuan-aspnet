using GioChuanGiangDay.Models;
using Microsoft.EntityFrameworkCore;

namespace GioChuanGiangDay.Data
{
    public static class SeedHoatDongQuyDoi
    {
        public static async Task RunAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.MigrateAsync();

            var data = new List<DmHoatDongQuyDoi>
            {
                // ============================================================
                // A. GIẢNG DẠY KHÁC / HƯỚNG DẪN SINH VIÊN
                // ============================================================

                A("GIANG_DAY_KHAC", "HD_SV_NCKH_CAP_TRUONG", 
                    "Hướng dẫn sinh viên làm đề tài NCKH cấp Trường trở lên, nghiệm thu đạt",
                    "Đề tài", 20, false, "20 GC / đề tài"),

                A("GIANG_DAY_KHAC", "HD_THUC_TAP_THUC_TE", 
                    "Hướng dẫn sinh viên thực hiện học phần thực tập thực tế",
                    "Sinh viên", 2, false, "02 GC / sinh viên"),

                A("GIANG_DAY_KHAC", "HD_CHUYEN_DE_DO_AN_MON_HOC", 
                    "Hướng dẫn sinh viên thực hiện chuyên đề / đồ án môn học",
                    "Sinh viên", 1.2m, false, "1,2 GC / sinh viên"),

                A("GIANG_DAY_KHAC", "HD_THUC_TAP_TOT_NGHIEP", 
                    "Hướng dẫn và chấm thứ I báo cáo thực tập tốt nghiệp đại học",
                    "Báo cáo", 7, false, "07 GC / báo cáo"),

                A("GIANG_DAY_KHAC", "HD_KHOA_LUAN_DO_AN_TOT_NGHIEP", 
                    "Hướng dẫn khóa luận / đồ án tốt nghiệp đại học",
                    "Khóa luận / Đồ án", 18, false, "18 GC / khóa luận hoặc đồ án"),

                A("GIANG_DAY_KHAC", "CHAM_THU_II_BCTT_KHONG_HD", 
                    "Chấm thứ II báo cáo thực tập tốt nghiệp đại học không thành lập hội đồng",
                    "Báo cáo", 2, false, "02 GC / báo cáo"),

                A("GIANG_DAY_KHAC", "DU_AN_THI_BO_GD_GIAI_123", 
                    "Hướng dẫn dự án thi cấp Bộ GD&ĐT đạt giải nhất, nhì, ba",
                    "Dự án", 20, false, "20 GC / dự án"),

                A("GIANG_DAY_KHAC", "DU_AN_THI_BO_GD_KHUYEN_KHICH", 
                    "Hướng dẫn dự án thi cấp Bộ GD&ĐT đạt giải khuyến khích",
                    "Dự án", 15, false, "15 GC / dự án"),

                A("GIANG_DAY_KHAC", "DU_AN_THI_CAP_KHAC", 
                    "Hướng dẫn dự án thi cấp Trường hoặc ngoài Trường đạt giải",
                    "Dự án", 10, false, "10 GC / dự án"),

                // ============================================================
                // B. THỰC HÀNH, THÍ NGHIỆM, CỐ VẤN, COI THI, NGÂN HÀNG ĐỀ
                // ============================================================

                A("GIANG_DAY_KHAC", "THUC_HANH_MAY_TINH", 
                    "Hướng dẫn thực hành, thí nghiệm trên máy tính",
                    "Sinh viên x tín chỉ", 0.6m, false, "0,6 GC / 01 SV / 01 tín chỉ"),

                A("GIANG_DAY_KHAC", "THUC_HANH_MON_KHAC", 
                    "Hướng dẫn thực hành, thí nghiệm môn học khác",
                    "Sinh viên x tín chỉ", 1, false, "01 GC / 01 SV / 01 tín chỉ"),

                A("GIANG_DAY_KHAC", "THUC_HANH_GD_THE_CHAT", 
                    "Hướng dẫn thực hành lớp học phần Giáo dục thể chất",
                    "Sinh viên x tín chỉ", 1, false, "01 GC / 01 SV / 01 tín chỉ"),

                A("GIANG_DAY_KHAC", "HO_TRO_VAN_PHONG_KHOA", 
                    "Hỗ trợ công tác Văn phòng Khoa",
                    "Năm", 50, false, "50 GC / năm"),

                A("GIANG_DAY_KHAC", "CVHT_DUOI_40", 
                    "Cố vấn học tập lớp có dưới hoặc bằng 40 sinh viên",
                    "Lớp / năm", 45, false, "45 GC / lớp / năm"),

                A("GIANG_DAY_KHAC", "CVHT_41_50", 
                    "Cố vấn học tập lớp có 41-50 sinh viên",
                    "Lớp / năm", 50, false, "50 GC / lớp / năm"),

                A("GIANG_DAY_KHAC", "CVHT_51_60", 
                    "Cố vấn học tập lớp có 51-60 sinh viên",
                    "Lớp / năm", 55, false, "55 GC / lớp / năm"),

                A("GIANG_DAY_KHAC", "CVHT_61_70", 
                    "Cố vấn học tập lớp có 61-70 sinh viên",
                    "Lớp / năm", 60, false, "60 GC / lớp / năm"),

                A("GIANG_DAY_KHAC", "CVHT_71_80", 
                    "Cố vấn học tập lớp có 71-80 sinh viên",
                    "Lớp / năm", 65, false, "65 GC / lớp / năm"),

                A("GIANG_DAY_KHAC", "CVHT_TREN_81", 
                    "Cố vấn học tập lớp có trên 81 sinh viên",
                    "Lớp / năm", 70, false, "70 GC / lớp / năm"),

                A("GIANG_DAY_KHAC", "NGAN_HANG_DE_TU_LUAN", 
                    "Xây dựng ngân hàng đề thi tự luận",
                    "Tín chỉ", 15, false, "15 GC / 01 tín chỉ"),

                A("GIANG_DAY_KHAC", "NGAN_HANG_DE_VAN_DAP", 
                    "Xây dựng ngân hàng đề thi vấn đáp",
                    "Tín chỉ", 15, false, "15 GC / 01 tín chỉ"),

                A("GIANG_DAY_KHAC", "NGAN_HANG_DE_TRAC_NGHIEM", 
                    "Xây dựng ngân hàng đề thi trắc nghiệm hoặc kết hợp tự luận",
                    "Tín chỉ", 20, false, "20 GC / 01 tín chỉ"),

                A("GIANG_DAY_KHAC", "DANH_GIA_HP_DAI_HOC", 
                    "Công tác đánh giá học phần trình độ đại học",
                    "Sinh viên", 0.2m, false, "0,2 GC / 01 sinh viên"),

                A("GIANG_DAY_KHAC", "DANH_GIA_HP_SAU_DAI_HOC", 
                    "Công tác đánh giá học phần trình độ sau đại học",
                    "Sinh viên", 0.3m, false, "0,3 GC / 01 sinh viên"),

                A("GIANG_DAY_KHAC", "CONG_THEM_LOP_DUOI_20", 
                    "Cộng thêm cho lớp học phần có số lượng sinh viên nhỏ hơn hoặc bằng 20",
                    "Lớp học phần", 2, false, "Cộng thêm 02 GC / lớp"),

                A("GIANG_DAY_KHAC", "COI_THI", 
                    "Coi thi / giám sát thi",
                    "Ca thi", 1, false, "01 GC / ca thi"),

                A("GIANG_DAY_KHAC", "PHU_TRACH_PHONG_THI_NGHIEM", 
                    "Giảng viên kiêm nhiệm phụ trách phòng thí nghiệm",
                    "Năm", 40, false, "40 GC / năm"),

                // ============================================================
                // C. HỘI ĐỒNG THẨM ĐỊNH, HỘI ĐỒNG NGHIỆM THU
                // ============================================================

                A("HOI_DONG", "HD_THAM_DINH_BAI_GIANG_CHU_TICH", 
                    "Hội đồng thẩm định bài giảng - Chủ tịch",
                    "Hội đồng", 4, false, "04 GC"),

                A("HOI_DONG", "HD_THAM_DINH_BAI_GIANG_PHAN_BIEN", 
                    "Hội đồng thẩm định bài giảng - Phản biện",
                    "Hội đồng", 5, false, "05 GC"),

                A("HOI_DONG", "HD_THAM_DINH_BAI_GIANG_THU_KY", 
                    "Hội đồng thẩm định bài giảng - Ủy viên kiêm thư ký",
                    "Hội đồng", 4, false, "04 GC"),

                A("HOI_DONG", "HD_NGHIEM_THU_CHU_TICH", 
                    "Hội đồng nghiệm thu đề tài, dự án, giáo trình, chương trình đào tạo - Chủ tịch",
                    "Hội đồng", 7, false, "07 GC"),

                A("HOI_DONG", "HD_NGHIEM_THU_PHAN_BIEN", 
                    "Hội đồng nghiệm thu đề tài, dự án, giáo trình, chương trình đào tạo - Phản biện",
                    "Hội đồng", 8, false, "08 GC"),

                A("HOI_DONG", "HD_NGHIEM_THU_UY_VIEN", 
                    "Hội đồng nghiệm thu đề tài, dự án, giáo trình, chương trình đào tạo - Ủy viên",
                    "Hội đồng", 5, false, "05 GC"),

                A("HOI_DONG", "HD_NGHIEM_THU_THU_KY", 
                    "Hội đồng nghiệm thu đề tài, dự án, giáo trình, chương trình đào tạo - Thư ký",
                    "Hội đồng", 6, false, "06 GC"),

                A("HOI_DONG", "HD_DO_AN_KLTN_DUOI_50_CHU_TICH", 
                    "Hội đồng thẩm định đồ án / khóa luận dưới 50 - Chủ tịch",
                    "Hội đồng", 5, false, "05 GC"),

                A("HOI_DONG", "HD_DO_AN_KLTN_DUOI_50_UY_VIEN", 
                    "Hội đồng thẩm định đồ án / khóa luận dưới 50 - Phó Chủ tịch / Ủy viên",
                    "Hội đồng", 3, false, "03 GC"),

                A("HOI_DONG", "HD_DO_AN_KLTN_DUOI_50_THU_KY", 
                    "Hội đồng thẩm định đồ án / khóa luận dưới 50 - Thư ký",
                    "Hội đồng", 4, false, "04 GC"),

                A("HOI_DONG", "HD_DO_AN_KLTN_TU_50_CHU_TICH", 
                    "Hội đồng thẩm định đồ án / khóa luận từ 50 trở lên - Chủ tịch",
                    "Hội đồng", 7, false, "07 GC"),

                A("HOI_DONG", "HD_DO_AN_KLTN_TU_50_UY_VIEN", 
                    "Hội đồng thẩm định đồ án / khóa luận từ 50 trở lên - Phó Chủ tịch / Ủy viên",
                    "Hội đồng", 5, false, "05 GC"),

                A("HOI_DONG", "HD_DO_AN_KLTN_TU_50_THU_KY", 
                    "Hội đồng thẩm định đồ án / khóa luận từ 50 trở lên - Thư ký",
                    "Hội đồng", 6, false, "06 GC"),

                A("HOI_DONG", "BAN_DANH_GIA_DO_AN_KLTN_TRUONG_BAN", 
                    "Ban đánh giá đồ án / khóa luận tốt nghiệp - Trưởng ban",
                    "Ban", 4, false, "04 GC"),

                A("HOI_DONG", "BAN_DANH_GIA_DO_AN_KLTN_PHAN_BIEN", 
                    "Ban đánh giá đồ án / khóa luận tốt nghiệp - Phản biện",
                    "Ban", 4, false, "04 GC"),

                A("HOI_DONG", "BAN_DANH_GIA_DO_AN_KLTN_THU_KY", 
                    "Ban đánh giá đồ án / khóa luận tốt nghiệp - Thư ký",
                    "Ban", 3, false, "03 GC"),

                A("HOI_DONG", "HD_NGHIEM_THU_NCKH_SV_CHU_TICH", 
                    "Hội đồng nghiệm thu đề tài NCKH sinh viên - Chủ tịch",
                    "Hội đồng", 4, false, "04 GC"),

                A("HOI_DONG", "HD_NGHIEM_THU_NCKH_SV_PHAN_BIEN", 
                    "Hội đồng nghiệm thu đề tài NCKH sinh viên - Phản biện",
                    "Hội đồng", 4, false, "04 GC"),

                A("HOI_DONG", "HD_NGHIEM_THU_NCKH_SV_THU_KY", 
                    "Hội đồng nghiệm thu đề tài NCKH sinh viên - Thư ký",
                    "Hội đồng", 3, false, "03 GC"),

                // ============================================================
                // D. NGHIÊN CỨU KHOA HỌC - ĐỀ TÀI / NHIỆM VỤ KHCN
                // ============================================================

                A("NCKH", "KHCN_CAP_NHA_NUOC", 
                    "Nhiệm vụ KHCN cấp Nhà nước đã nghiệm thu",
                    "Nhiệm vụ", 270, true, "270 GC / nhiệm vụ"),

                A("NCKH", "KHCN_CAP_BO_TINH_THANH", 
                    "Nhiệm vụ KHCN cấp Bộ / Tỉnh / Thành phố đã nghiệm thu",
                    "Nhiệm vụ", 250, true, "250 GC / nhiệm vụ"),

                A("NCKH", "DE_TAI_CO_SO_XUAT_SAC", 
                    "Đề tài cấp cơ sở nghiệm thu xếp loại Xuất sắc",
                    "Đề tài", 180, true, "180 GC / đề tài"),

                A("NCKH", "DE_TAI_CO_SO_TOT", 
                    "Đề tài cấp cơ sở nghiệm thu xếp loại Tốt",
                    "Đề tài", 170, true, "170 GC / đề tài"),

                A("NCKH", "DE_TAI_CO_SO_KHA", 
                    "Đề tài cấp cơ sở nghiệm thu xếp loại Khá",
                    "Đề tài", 160, true, "160 GC / đề tài"),

                A("NCKH", "DE_TAI_CO_SO_DAT", 
                    "Đề tài cấp cơ sở nghiệm thu xếp loại Đạt",
                    "Đề tài", 150, true, "150 GC / đề tài"),

                // ============================================================
                // E. BIÊN SOẠN TÀI LIỆU PHỤC VỤ ĐÀO TẠO
                // ============================================================

                A("NCKH", "BIEN_SOAN_BAI_GIANG", 
                    "Biên soạn bài giảng",
                    "Tín chỉ", 20, true, "20 GC / tín chỉ"),

                A("NCKH", "BIEN_SOAN_GIAO_TRINH_NOI_BO", 
                    "Biên soạn giáo trình lưu hành nội bộ",
                    "Tín chỉ", 60, true, "60 GC / tín chỉ"),

                A("NCKH", "GIAO_TRINH_TAI_BAN_TREN_50", 
                    "Biên soạn giáo trình tái bản, sửa chữa bổ sung trên 50%",
                    "Tín chỉ", 40, true, "40 GC / tín chỉ"),

                A("NCKH", "GIAO_TRINH_TAI_BAN_30_50", 
                    "Biên soạn giáo trình tái bản, sửa chữa bổ sung từ 30% đến 50%",
                    "Tín chỉ", 30, true, "30 GC / tín chỉ"),

                A("NCKH", "GIAO_TRINH_TAI_BAN_DUOI_30", 
                    "Biên soạn giáo trình tái bản, sửa chữa bổ sung dưới 30%",
                    "Tín chỉ", 20, true, "20 GC / tín chỉ"),

                A("NCKH", "XUAT_BAN_GIAO_TRINH_ISBN", 
                    "Xuất bản giáo trình đã được nghiệm thu có ISBN",
                    "Tín chỉ", 40, true, "40 GC / tín chỉ"),

                A("NCKH", "SACH_CHUYEN_KHAO_NXB_UY_TIN", 
                    "Sách chuyên khảo xuất bản bởi nhà xuất bản uy tín thế giới",
                    "Chương", 100, true, "100 GC / chương"),

                A("NCKH", "SACH_THAM_KHAO_NXB_UY_TIN", 
                    "Sách tham khảo xuất bản bởi nhà xuất bản uy tín thế giới",
                    "Chương", 70, true, "70 GC / chương"),

                A("NCKH", "SACH_CHUYEN_KHAO_XUAT_BAN", 
                    "Sách chuyên khảo được xuất bản",
                    "Sách", 120, true, "120 GC"),

                A("NCKH", "SACH_THAM_KHAO_XUAT_BAN", 
                    "Sách tham khảo được xuất bản",
                    "Sách", 80, true, "80 GC"),

                // ============================================================
                // F. BÀI BÁO KHOA HỌC
                // ============================================================

                A("NCKH", "BAI_BAO_SCIMAGO_Q1", 
                    "Bài báo Scimago Q1",
                    "Bài báo", 1000, true, "1000 GC / bài"),

                A("NCKH", "BAI_BAO_SCIMAGO_Q2", 
                    "Bài báo Scimago Q2",
                    "Bài báo", 600, true, "600 GC / bài"),

                A("NCKH", "BAI_BAO_SCIMAGO_Q3", 
                    "Bài báo Scimago Q3",
                    "Bài báo", 300, true, "300 GC / bài"),

                A("NCKH", "BAI_BAO_SCIMAGO_Q4", 
                    "Bài báo Scimago Q4",
                    "Bài báo", 200, true, "200 GC / bài"),

                A("NCKH", "BAI_BAO_ISI_SCOPUS_ACI_CHUA_XEP_HANG", 
                    "Bài báo thuộc ISI / Scopus / ACI / SCImago nhưng chưa xếp hạng",
                    "Bài báo", 150, true, "150 GC / bài"),

                A("NCKH", "BAI_BAO_KHONG_SCIMAGO", 
                    "Bài báo khoa học nước ngoài không thuộc danh mục Scimago",
                    "Bài báo", 100, true, "100 GC / bài"),

                A("NCKH", "TAP_CHI_TRONG_NUOC_TREN_1_DIEM", 
                    "Tạp chí trong nước HĐCDGSNN trên 1.0 điểm",
                    "Bài báo", 150, true, "150 GC / bài"),

                A("NCKH", "TAP_CHI_TRONG_NUOC_1_DIEM", 
                    "Tạp chí trong nước HĐCDGSNN tối đa 1.0 điểm hoặc Tạp chí KH&CN Cần Thơ",
                    "Bài báo", 130, true, "130 GC / bài"),

                A("NCKH", "TAP_CHI_TRONG_NUOC_075_DIEM", 
                    "Tạp chí trong nước HĐCDGSNN tối đa 0.75 điểm",
                    "Bài báo", 110, true, "110 GC / bài"),

                A("NCKH", "TAP_CHI_TRONG_NUOC_05_DIEM", 
                    "Tạp chí trong nước HĐCDGSNN tối đa 0.5 điểm",
                    "Bài báo", 90, true, "90 GC / bài"),

                A("NCKH", "TAP_CHI_TRONG_NUOC_025_DIEM", 
                    "Tạp chí trong nước HĐCDGSNN tối đa 0.25 điểm",
                    "Bài báo", 70, true, "70 GC / bài"),

                A("NCKH", "TAP_CHI_ISSN_PHAN_BIEN", 
                    "Tạp chí khoa học có ISSN, có phản biện",
                    "Bài báo", 50, true, "50 GC / bài"),

                A("NCKH", "CONG_THEM_BAI_BAO_TIENG_ANH", 
                    "Cộng thêm cho bài báo trong nước đăng bằng tiếng Anh",
                    "Bài báo", 30, false, "Cộng thêm 30 GC / bài"),

                A("NCKH", "KY_YEU_QUOC_TE_NGOAI_NGU", 
                    "Bài đăng kỷ yếu hội nghị quốc tế toàn văn bằng tiếng nước ngoài, có phản biện",
                    "Bài", 40, true, "40 GC / bài"),

                A("NCKH", "KY_YEU_QUOC_GIA_TIENG_VIET", 
                    "Bài đăng kỷ yếu hội nghị quốc gia toàn văn bằng tiếng Việt, có phản biện",
                    "Bài", 30, true, "30 GC / bài"),

                A("NCKH", "KY_YEU_CAP_KHOA_TRUONG_TINH", 
                    "Bài viết đăng kỷ yếu hội nghị, hội thảo cấp khoa, trường, tỉnh, thành phố, có phản biện",
                    "Bài", 20, true, "20 GC / bài"),

                A("NCKH", "BAN_TIN_KHDT_TRUONG", 
                    "Bài viết đăng trên Bản tin Khoa học - Đào tạo của Trường",
                    "Bài", 30, true, "30 GC / bài"),

                A("NCKH", "SO_HUU_TRI_TUE", 
                    "Sản phẩm NCKH được cấp quyền sở hữu trí tuệ",
                    "Sản phẩm", 100, true, "100 GC / sản phẩm"),

                A("NCKH", "BAO_CAO_KHOA_HOC_KHA_TRO_LEN", 
                    "Báo cáo khoa học được đánh giá loại Khá trở lên",
                    "Báo cáo", 20, true, "20 GC / báo cáo"),

                // ============================================================
                // G. HỘI ĐỒNG KHOA HỌC, ĐỀ ÁN, ĐÁNH GIÁ CHẤT LƯỢNG
                // ============================================================

                A("NHIEM_VU_KHAC", "HD_THAM_DINH_BAO_CAO_KH_CHU_TOA", 
                    "Hội đồng thẩm định báo cáo khoa học - Chủ tọa",
                    "Hội đồng", 3, false, "03 GC"),

                A("NHIEM_VU_KHAC", "HD_THAM_DINH_BAO_CAO_KH_THU_KY", 
                    "Hội đồng thẩm định báo cáo khoa học - Thư ký",
                    "Hội đồng", 2, false, "02 GC"),

                A("NHIEM_VU_KHAC", "HD_KHDT_TRUONG_CHU_TICH", 
                    "Hội đồng Khoa học và Đào tạo Trường - Chủ tịch",
                    "Năm", 70, false, "70 GC"),

                A("NHIEM_VU_KHAC", "HD_KHDT_TRUONG_PHO_CHU_TICH_THU_KY", 
                    "Hội đồng Khoa học và Đào tạo Trường - Phó Chủ tịch / Thư ký",
                    "Năm", 60, false, "60 GC"),

                A("NHIEM_VU_KHAC", "HD_KHDT_TRUONG_UY_VIEN", 
                    "Hội đồng Khoa học và Đào tạo Trường - Ủy viên",
                    "Năm", 50, false, "50 GC"),

                A("NHIEM_VU_KHAC", "HD_KHDT_KHOA_CHU_TICH", 
                    "Hội đồng Khoa học và Đào tạo Khoa - Chủ tịch",
                    "Năm", 30, false, "30 GC"),

                A("NHIEM_VU_KHAC", "HD_KHDT_KHOA_THU_KY", 
                    "Hội đồng Khoa học và Đào tạo Khoa - Thư ký",
                    "Năm", 25, false, "25 GC"),

                A("NHIEM_VU_KHAC", "HD_KHDT_KHOA_UY_VIEN", 
                    "Hội đồng Khoa học và Đào tạo Khoa - Ủy viên",
                    "Năm", 20, false, "20 GC"),

                A("NHIEM_VU_KHAC", "DE_AN_MO_NGANH_THAC_SI_TIEN_SI", 
                    "Xây dựng đề án mở ngành trình độ thạc sĩ, tiến sĩ được phê duyệt",
                    "Đề án", 450, true, "450 GC / đề án"),

                A("NHIEM_VU_KHAC", "DE_AN_MO_NGANH_DAI_HOC", 
                    "Xây dựng đề án mở ngành trình độ đại học được phê duyệt",
                    "Đề án", 300, true, "300 GC / đề án"),

                A("NHIEM_VU_KHAC", "CHUONG_TRINH_LIEN_THONG_VB2", 
                    "Xây dựng chương trình đào tạo đại học liên thông và văn bằng 2 được phê duyệt",
                    "Chương trình", 150, true, "150 GC / chương trình"),

                A("NHIEM_VU_KHAC", "DGCL_CSGD_TU_DANH_GIA_LAN_1", 
                    "Đề án đánh giá chất lượng cơ sở giáo dục tự chuẩn lần thứ nhất",
                    "Đề án", 1000, true, "1000 GC / đề án"),

                A("NHIEM_VU_KHAC", "DGCL_CSGD_CAC_LAN_TIEP_THEO", 
                    "Đề án đánh giá chất lượng cơ sở giáo dục đạt chuẩn các lần tiếp theo",
                    "Đề án", 500, true, "500 GC / đề án"),

                A("NHIEM_VU_KHAC", "DGCL_CSGD_GIUA_KY", 
                    "Đề án đánh giá giữa kỳ cơ sở giáo dục đạt yêu cầu",
                    "Đề án", 250, true, "250 GC / đề án"),

                A("NHIEM_VU_KHAC", "DGCL_CTDT_LAN_1", 
                    "Đề án đánh giá chất lượng chương trình đào tạo tự chuẩn lần thứ nhất",
                    "Chương trình đào tạo", 440, true, "440 GC / CTĐT"),

                A("NHIEM_VU_KHAC", "DGCL_CTDT_CAC_LAN_TIEP_THEO", 
                    "Đề án đánh giá chất lượng chương trình đào tạo tự chuẩn các lần tiếp theo",
                    "Chương trình đào tạo", 220, true, "220 GC / CTĐT"),

                A("NHIEM_VU_KHAC", "DGCL_CTDT_GIUA_KY", 
                    "Đề án đánh giá giữa kỳ chương trình đào tạo đạt yêu cầu",
                    "Chương trình đào tạo", 110, true, "110 GC / CTĐT"),
            };

            foreach (var item in data)
            {
                var existed = await context.DmHoatDongQuyDois
                    .FirstOrDefaultAsync(x => x.MaHoatDong == item.MaHoatDong);

                if (existed == null)
                {
                    context.DmHoatDongQuyDois.Add(item);
                }
                else
                {
                    existed.NhomHoatDong = item.NhomHoatDong;
                    existed.TenHoatDong = item.TenHoatDong;
                    existed.DonViTinh = item.DonViTinh;
                    existed.GioQuyDoiMacDinh = item.GioQuyDoiMacDinh;
                    existed.HeSoMacDinh = item.HeSoMacDinh;
                    existed.CanTyLeDongGop = item.CanTyLeDongGop;
                    existed.CanMinhChung = item.CanMinhChung;
                    existed.GhiChu = item.GhiChu;
                }
            }

            await context.SaveChangesAsync();
        }

        private static DmHoatDongQuyDoi A(
            string nhom,
            string ma,
            string ten,
            string donViTinh,
            decimal gioMacDinh,
            bool canTyLeDongGop,
            string ghiChu)
        {
            return new DmHoatDongQuyDoi
            {
                NhomHoatDong = nhom,
                MaHoatDong = ma,
                TenHoatDong = ten,
                DonViTinh = donViTinh,
                GioQuyDoiMacDinh = gioMacDinh,
                HeSoMacDinh = 1,
                CanTyLeDongGop = canTyLeDongGop,
                CanMinhChung = true,
                GhiChu = ghiChu
            };
        }
    }
}