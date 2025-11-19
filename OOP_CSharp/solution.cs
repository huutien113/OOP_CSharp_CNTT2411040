using System;
using System.Collections.Generic;

/*
 * Đây là phần triển khai các lớp quản lý cho ba đề bài (đề 0, đề 1, đề 2).
 * Lưu ý: không thay đổi nội dung bất kỳ lớp nào trong classesLib.cs. Tất cả
 * logic mới đều nằm trong các lớp QuanLyCuaHang, QuanLyNhaThuoc và
 * QuanLyNhaSach dưới đây. Các phương thức được cài đặt sử dụng vòng lặp
 * for thay vì foreach và không sử dụng các hàm dựng sẵn như Sort, Max, Min.
 * Tên biến tuân theo quy tắc: các danh sách bắt đầu bằng Lst_, từ điển bắt
 * đầu bằng Dict_, các biến kiểu đơn giản viết tiếng Việt không dấu, in hoa
 * chữ cái đầu của mỗi từ. Các tham số phải giữ nguyên tên nếu đề bài đã
 * quy định.
 */

namespace KTGK_CSharp
{
    // Quản lý bán hàng dành cho đề 0
    public class QuanLyCuaHang
    {
        // Danh sách sản phẩm
        private List<SanPham> Lst_SanPham;
        // Danh sách khách hàng
        private List<KhachHang> Lst_KhachHang;
        // Danh sách hóa đơn
        private List<HoaDon> Lst_HoaDon;
        // Từ điển loại khách hàng -> phần trăm chiết khấu
        private Dictionary<string, double> Dict_chietKhauTheoLoai;

        // Constructor khởi tạo các danh sách rỗng và từ điển chiết khấu cố định
        public QuanLyCuaHang()
        {
            Lst_SanPham = new List<SanPham>();
            Lst_KhachHang = new List<KhachHang>();
            Lst_HoaDon = new List<HoaDon>();
            Dict_chietKhauTheoLoai = new Dictionary<string, double>();
            // Khởi tạo chiết khấu cho từng loại khách hàng
            Dict_chietKhauTheoLoai["VIP"] = 0.10;
            Dict_chietKhauTheoLoai["Thuong"] = 0.05;
            Dict_chietKhauTheoLoai["Moi"] = 0.0;
        }

        // Thêm một sản phẩm mới vào danh sách
        public void ThemSanPham(SanPham SanPham)
        {
            Lst_SanPham.Add(SanPham);
        }

        // Thêm một khách hàng mới vào danh sách
        public void ThemKhachHang(KhachHang KhachHang)
        {
            Lst_KhachHang.Add(KhachHang);
        }

        // Cập nhật số lượng tồn cho sản phẩm dựa vào mã
        public void CapNhatSoLuongTon(int maSP, int soLuongNhapThem)
        {
            // Duyệt qua danh sách sản phẩm để tìm sản phẩm có mã tương ứng
            for (int i = 0; i < Lst_SanPham.Count; i++)
            {
                if (Lst_SanPham[i].MaSP == maSP)
                {
                    // Tăng số lượng tồn nếu tìm thấy
                    Lst_SanPham[i].SoLuongTon += soLuongNhapThem;
                    break;
                }
            }
        }

        // Tìm kiếm sản phẩm theo nhà cung cấp (không phân biệt chữ hoa thường)
        public List<SanPham> TimKiemSanPhamTheoNhaCungCap(string nhaCungCap)
        {
            List<SanPham> Lst_KetQua = new List<SanPham>();
            // Duyệt từng sản phẩm và so sánh nhà cung cấp
            for (int i = 0; i < Lst_SanPham.Count; i++)
            {
                // So sánh không phân biệt hoa thường
                if (string.Equals(Lst_SanPham[i].NhaCungCap, nhaCungCap, StringComparison.OrdinalIgnoreCase))
                {
                    Lst_KetQua.Add(Lst_SanPham[i]);
                }
            }
            return Lst_KetQua;
        }

        // Thêm hóa đơn với đầy đủ kiểm tra ràng buộc
        public bool ThemHoaDon(HoaDon hd)
        {
            // Kiểm tra mã khách hàng tồn tại
            bool KT_KhachHangTonTai = false;
            for (int i = 0; i < Lst_KhachHang.Count; i++)
            {
                if (Lst_KhachHang[i].MaKH == hd.MaKH)
                {
                    KT_KhachHangTonTai = true;
                    break;
                }
            }
            if (!KT_KhachHangTonTai) return false;

            // Kiểm tra từng chi tiết hóa đơn
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDon ChiTiet = hd.ChiTiet[i];
                // Tìm sản phẩm theo mã
                SanPham SanPham = null;
                for (int j = 0; j < Lst_SanPham.Count; j++)
                {
                    if (Lst_SanPham[j].MaSP == ChiTiet.MaSP)
                    {
                        SanPham = Lst_SanPham[j];
                        break;
                    }
                }
                // Nếu sản phẩm không tồn tại thì hóa đơn không hợp lệ
                if (SanPham == null) return false;
                // Số lượng bán phải > 0 và không vượt tồn kho
                if (ChiTiet.SoLuongBan <= 0) return false;
                if (ChiTiet.SoLuongBan > SanPham.SoLuongTon) return false;
                // Đơn giá bán phải >= giá nhập * 1.1 (lợi nhuận tối thiểu 10%)
                double GiaBanToiThieu = SanPham.GiaNhap * 1.1;
                if (ChiTiet.DonGiaBan < GiaBanToiThieu) return false;
            }
            // Nếu tất cả chi tiết hợp lệ → cập nhật tồn kho và thêm hóa đơn
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDon ChiTiet = hd.ChiTiet[i];
                // Giảm số lượng tồn kho cho sản phẩm tương ứng
                for (int j = 0; j < Lst_SanPham.Count; j++)
                {
                    if (Lst_SanPham[j].MaSP == ChiTiet.MaSP)
                    {
                        Lst_SanPham[j].SoLuongTon -= ChiTiet.SoLuongBan;
                        break;
                    }
                }
            }
            // Thêm hóa đơn vào danh sách
            Lst_HoaDon.Add(hd);
            return true;
        }

        // Thống kê khách hàng mua nhiều nhất trong tháng/năm cho trước
        public KhachHang ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
        {
            // Biến lưu tổng tiền lớn nhất và khách hàng tương ứng
            double TongTienMax = 0;
            KhachHang KhachHangMax = null;
            // Duyệt qua từng khách hàng trong danh sách
            for (int i = 0; i < Lst_KhachHang.Count; i++)
            {
                KhachHang KHienTai = Lst_KhachHang[i];
                double TongTienKhachHang = 0;
                // Tính tổng tiền thực tế của khách hàng trong tháng/năm yêu cầu
                for (int j = 0; j < Lst_HoaDon.Count; j++)
                {
                    HoaDon HD = Lst_HoaDon[j];
                    if (HD.MaKH == KHienTai.MaKH && HD.NgayLap.Month == thang && HD.NgayLap.Year == nam)
                    {
                        double TongChiTiet = 0;
                        // Tính tổng tiền chi tiết hóa đơn
                        for (int k = 0; k < HD.ChiTiet.Count; k++)
                        {
                            TongChiTiet += HD.ChiTiet[k].DonGiaBan * HD.ChiTiet[k].SoLuongBan;
                        }
                        // Lấy loại khách hàng để tính chiết khấu
                        string loaiKH = KHienTai.LoaiKH;
                        double chietKhau = 0;
                        // Tìm giá trị chiết khấu tương ứng (dùng vòng lặp for trên KeyValuePair)
                        // Tạo danh sách các key để duyệt bằng for (tránh foreach)
                        List<string> Lst_Key = new List<string>(Dict_chietKhauTheoLoai.Keys);
                        for (int x = 0; x < Lst_Key.Count; x++)
                        {
                            string key = Lst_Key[x];
                            if (key == loaiKH)
                            {
                                chietKhau = Dict_chietKhauTheoLoai[key];
                                break;
                            }
                        }
                        double TienThucTe = TongChiTiet * (1 - chietKhau);
                        TongTienKhachHang += TienThucTe;
                    }
                }
                // Cập nhật khách hàng có tổng tiền cao nhất
                if (TongTienKhachHang > TongTienMax)
                {
                    TongTienMax = TongTienKhachHang;
                    KhachHangMax = KHienTai;
                }
            }
            return KhachHangMax;
        }
    }

    // Quản lý nhà thuốc dành cho đề 1
    public class QuanLyNhaThuoc
    {
        private List<Thuoc> Lst_Thuoc;
        private List<BenhNhan> Lst_BenhNhan;
        private List<DonThuoc> Lst_DonThuoc;
        private Dictionary<string, double> Dict_chietKhauTheoLoai;

        public QuanLyNhaThuoc()
        {
            Lst_Thuoc = new List<Thuoc>();
            Lst_BenhNhan = new List<BenhNhan>();
            Lst_DonThuoc = new List<DonThuoc>();
            Dict_chietKhauTheoLoai = new Dictionary<string, double>();
            Dict_chietKhauTheoLoai["VIP"] = 0.10;
            Dict_chietKhauTheoLoai["Thuong"] = 0.05;
            Dict_chietKhauTheoLoai["Moi"] = 0.0;
        }

        // Thêm thuốc
        public void ThemThuoc(Thuoc Thuoc)
        {
            Lst_Thuoc.Add(Thuoc);
        }

        // Thêm bệnh nhân
        public void ThemBenhNhan(BenhNhan BenhNhan)
        {
            Lst_BenhNhan.Add(BenhNhan);
        }

        // Cập nhật số lượng tồn kho thuốc
        public void CapNhatSoLuongTon(int maThuoc, int soLuongNhapThem)
        {
            for (int i = 0; i < Lst_Thuoc.Count; i++)
            {
                if (Lst_Thuoc[i].MaThuoc == maThuoc)
                {
                    Lst_Thuoc[i].SoLuongTon += soLuongNhapThem;
                    break;
                }
            }
        }

        // Tìm kiếm thuốc theo nhà sản xuất (không phân biệt hoa thường)
        public List<Thuoc> TimKiemThuocTheoNhaSanXuat(string nhaSanXuat)
        {
            List<Thuoc> Lst_KetQua = new List<Thuoc>();
            for (int i = 0; i < Lst_Thuoc.Count; i++)
            {
                if (string.Equals(Lst_Thuoc[i].NhaSanXuat, nhaSanXuat, StringComparison.OrdinalIgnoreCase))
                {
                    Lst_KetQua.Add(Lst_Thuoc[i]);
                }
            }
            return Lst_KetQua;
        }

        // Thêm đơn thuốc với ràng buộc
        public bool ThemDonThuoc(DonThuoc dt)
        {
            // Kiểm tra mã bệnh nhân tồn tại
            bool KT_BenhNhanTonTai = false;
            for (int i = 0; i < Lst_BenhNhan.Count; i++)
            {
                if (Lst_BenhNhan[i].MaBN == dt.MaBN)
                {
                    KT_BenhNhanTonTai = true;
                    break;
                }
            }
            if (!KT_BenhNhanTonTai) return false;
            // Kiểm tra từng chi tiết
            for (int i = 0; i < dt.ChiTiet.Count; i++)
            {
                ChiTietDonThuoc ChiTiet = dt.ChiTiet[i];
                // Tìm thuốc theo mã
                Thuoc Thuoc = null;
                for (int j = 0; j < Lst_Thuoc.Count; j++)
                {
                    if (Lst_Thuoc[j].MaThuoc == ChiTiet.MaThuoc)
                    {
                        Thuoc = Lst_Thuoc[j];
                        break;
                    }
                }
                if (Thuoc == null) return false;
                if (ChiTiet.SoLuong <= 0) return false;
                if (ChiTiet.SoLuong > Thuoc.SoLuongTon) return false;
                double GiaBanToiThieu = Thuoc.GiaNhap * 1.1;
                if (ChiTiet.DonGia < GiaBanToiThieu) return false;
            }
            // Nếu hợp lệ → cập nhật tồn kho và thêm đơn
            for (int i = 0; i < dt.ChiTiet.Count; i++)
            {
                ChiTietDonThuoc ChiTiet = dt.ChiTiet[i];
                for (int j = 0; j < Lst_Thuoc.Count; j++)
                {
                    if (Lst_Thuoc[j].MaThuoc == ChiTiet.MaThuoc)
                    {
                        Lst_Thuoc[j].SoLuongTon -= ChiTiet.SoLuong;
                        break;
                    }
                }
            }
            Lst_DonThuoc.Add(dt);
            return true;
        }

        // Thống kê bệnh nhân chi tiêu nhiều nhất
        public BenhNhan ThongKeBenhNhanChiTieuNhieuNhat(int thang, int nam)
        {
            double TongTienMax = 0;
            BenhNhan BenhNhanMax = null;
            for (int i = 0; i < Lst_BenhNhan.Count; i++)
            {
                BenhNhan BN = Lst_BenhNhan[i];
                double TongTienBenhNhan = 0;
                for (int j = 0; j < Lst_DonThuoc.Count; j++)
                {
                    DonThuoc DT = Lst_DonThuoc[j];
                    if (DT.MaBN == BN.MaBN && DT.NgayKe.Month == thang && DT.NgayKe.Year == nam)
                    {
                        double TongChiTiet = 0;
                        for (int k = 0; k < DT.ChiTiet.Count; k++)
                        {
                            TongChiTiet += DT.ChiTiet[k].DonGia * DT.ChiTiet[k].SoLuong;
                        }
                        // Xác định loại bệnh nhân và chiết khấu
                        string loaiBN = BN.LoaiBN;
                        double chietKhau = 0;
                        List<string> Lst_Key = new List<string>(Dict_chietKhauTheoLoai.Keys);
                        for (int x = 0; x < Lst_Key.Count; x++)
                        {
                            string key = Lst_Key[x];
                            if (key == loaiBN)
                            {
                                chietKhau = Dict_chietKhauTheoLoai[key];
                                break;
                            }
                        }
                        double TienThucTe = TongChiTiet * (1 - chietKhau);
                        TongTienBenhNhan += TienThucTe;
                    }
                }
                if (TongTienBenhNhan > TongTienMax)
                {
                    TongTienMax = TongTienBenhNhan;
                    BenhNhanMax = BN;
                }
            }
            return BenhNhanMax;
        }
    }

    // Quản lý nhà sách dành cho đề 2
    public class QuanLyNhaSach
    {
        private List<Sach> Lst_Sach;
        private List<DocGia> Lst_DocGia;
        private List<HoaDonMuaSach> Lst_HoaDon;
        private Dictionary<string, double> Dict_chietKhauTheoLoai;

        public QuanLyNhaSach()
        {
            Lst_Sach = new List<Sach>();
            Lst_DocGia = new List<DocGia>();
            Lst_HoaDon = new List<HoaDonMuaSach>();
            Dict_chietKhauTheoLoai = new Dictionary<string, double>();
            Dict_chietKhauTheoLoai["VIP"] = 0.10;
            Dict_chietKhauTheoLoai["Thuong"] = 0.05;
            Dict_chietKhauTheoLoai["Moi"] = 0.0;
        }

        // Thêm sách
        public void ThemSach(Sach Sach)
        {
            Lst_Sach.Add(Sach);
        }

        // Thêm độc giả
        public void ThemDocGia(DocGia DocGia)
        {
            Lst_DocGia.Add(DocGia);
        }

        // Cập nhật số lượng tồn sách
        public void CapNhatSoLuongTon(int maSach, int soLuongNhapThem)
        {
            for (int i = 0; i < Lst_Sach.Count; i++)
            {
                if (Lst_Sach[i].MaSach == maSach)
                {
                    Lst_Sach[i].SoLuongTon += soLuongNhapThem;
                    break;
                }
            }
        }

        // Tìm kiếm sách theo nhà xuất bản (không phân biệt hoa thường)
        public List<Sach> TimKiemSachTheoNhaXuatBan(string nhaXuatBan)
        {
            List<Sach> Lst_KetQua = new List<Sach>();
            for (int i = 0; i < Lst_Sach.Count; i++)
            {
                if (string.Equals(Lst_Sach[i].NhaXuatBan, nhaXuatBan, StringComparison.OrdinalIgnoreCase))
                {
                    Lst_KetQua.Add(Lst_Sach[i]);
                }
            }
            return Lst_KetQua;
        }

        // Thêm hóa đơn mua sách với ràng buộc
        public bool ThemHoaDonMuaSach(HoaDonMuaSach hd)
        {
            // Kiểm tra mã độc giả tồn tại
            bool KT_DocGiaTonTai = false;
            for (int i = 0; i < Lst_DocGia.Count; i++)
            {
                if (Lst_DocGia[i].MaDG == hd.MaDG)
                {
                    KT_DocGiaTonTai = true;
                    break;
                }
            }
            if (!KT_DocGiaTonTai) return false;
            // Kiểm tra từng chi tiết
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDonMuaSach ChiTiet = hd.ChiTiet[i];
                // Tìm sách theo mã
                Sach Sach = null;
                for (int j = 0; j < Lst_Sach.Count; j++)
                {
                    if (Lst_Sach[j].MaSach == ChiTiet.MaSach)
                    {
                        Sach = Lst_Sach[j];
                        break;
                    }
                }
                if (Sach == null) return false;
                if (ChiTiet.SoLuong <= 0) return false;
                if (ChiTiet.SoLuong > Sach.SoLuongTon) return false;
                double GiaBanToiThieu = Sach.GiaNhap * 1.1;
                if (ChiTiet.DonGia < GiaBanToiThieu) return false;
            }
            // Nếu hợp lệ → cập nhật tồn kho và thêm hóa đơn
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDonMuaSach ChiTiet = hd.ChiTiet[i];
                for (int j = 0; j < Lst_Sach.Count; j++)
                {
                    if (Lst_Sach[j].MaSach == ChiTiet.MaSach)
                    {
                        Lst_Sach[j].SoLuongTon -= ChiTiet.SoLuong;
                        break;
                    }
                }
            }
            Lst_HoaDon.Add(hd);
            return true;
        }

        // Thống kê độc giả mua nhiều nhất
        public DocGia ThongKeDocGiaMuaNhieuNhat(int thang, int nam)
        {
            double TongTienMax = 0;
            DocGia DocGiaMax = null;
            for (int i = 0; i < Lst_DocGia.Count; i++)
            {
                DocGia DG = Lst_DocGia[i];
                double TongTienDocGia = 0;
                for (int j = 0; j < Lst_HoaDon.Count; j++)
                {
                    HoaDonMuaSach HD = Lst_HoaDon[j];
                    if (HD.MaDG == DG.MaDG && HD.NgayMua.Month == thang && HD.NgayMua.Year == nam)
                    {
                        double TongChiTiet = 0;
                        for (int k = 0; k < HD.ChiTiet.Count; k++)
                        {
                            TongChiTiet += HD.ChiTiet[k].DonGia * HD.ChiTiet[k].SoLuong;
                        }
                        // Xác định loại độc giả và chiết khấu
                        string loaiDG = DG.LoaiDG;
                        double chietKhau = 0;
                        List<string> Lst_Key = new List<string>(Dict_chietKhauTheoLoai.Keys);
                        for (int x = 0; x < Lst_Key.Count; x++)
                        {
                            string key = Lst_Key[x];
                            if (key == loaiDG)
                            {
                                chietKhau = Dict_chietKhauTheoLoai[key];
                                break;
                            }
                        }
                        double TienThucTe = TongChiTiet * (1 - chietKhau);
                        TongTienDocGia += TienThucTe;
                    }
                }
                if (TongTienDocGia > TongTienMax)
                {
                    TongTienMax = TongTienDocGia;
                    DocGiaMax = DG;
                }
            }
            return DocGiaMax;
        }
    }
}