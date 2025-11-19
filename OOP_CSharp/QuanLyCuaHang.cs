using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    class QuanLyCuaHang
    {
        private List<SanPham> danhSachSP;
        private List<KhachHang> danhSachKH;
        private List<HoaDon> danhSachHD;
        private Dictionary<string, double> chietKhauTheoLoai;

        public List<SanPham> DanhSachSP { get => danhSachSP; set => danhSachSP = value; }
        public List<KhachHang> DanhSachKH { get => danhSachKH; set => danhSachKH = value; }
        public List<HoaDon> DanhSachHD { get => danhSachHD; set => danhSachHD = value; }
        public Dictionary<string, double> ChietKhauTheoLoai
        {
            get => chietKhauTheoLoai;
            set
            {
                chietKhauTheoLoai = value;
            }
        }

        public void ThemSanPham(SanPham sp)
        {
            DanhSachSP.Add(sp);
        }

        public void ThemKhachHang(KhachHang kh)
        {
            DanhSachKH.Add(kh);
        }
        // Loại Khách hàng -> % chiết khấu(0 đến 10%) 

        public QuanLyCuaHang()
        {
            DanhSachSP = new List<SanPham>();
            DanhSachKH = new List<KhachHang>();
            DanhSachHD = new List<HoaDon>();
            ChietKhauTheoLoai = new Dictionary<string, double>()
            {
                { "VIP", 0.10 },
                { "Thuong", 0.05 },
                { "Moi", 0.00 }
            };
        }

        public void CapNhatSoLuongTon(int maSP, int soLuongNhapThem)
        {
            for (int i = 0; i < DanhSachSP.Count; i++)
            {
                if (maSP == DanhSachSP[i].MaSP)
                {
                    DanhSachSP[i].SoLuongTon += soLuongNhapThem;
                }
            }
        }

        public List<SanPham> TimKiemSanPhamTheoNhaCungCap(string nhaCungCap)
        {
            List<SanPham> Lst_SanPham = new List<SanPham>();
            for (int i = 0; i < DanhSachSP.Count; i++)
            {
                if (nhaCungCap.ToUpper() == DanhSachSP[i].NhaCungCap.ToUpper())
                {
                    Lst_SanPham.Add(DanhSachSP[i]);
                }
            }
            return Lst_SanPham;
        }

        public void ThemHoaDon(HoaDon hd)
        {
            // Kiểm tra mã khách hàng phải tồn tại
            bool khachHangTonTai = false;
            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (hd.MaKH == DanhSachKH[i].MaKH)
                {
                    khachHangTonTai = true;
                    break;
                }
            }
            if (!khachHangTonTai)
            {
                return; // Hủy, không thêm
            }

            // Kiểm tra tất cả chi tiết hóa đơn
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDon ct = hd.ChiTiet[i];
                
                // Kiểm tra số lượng bán > 0
                if (ct.SoLuongBan <= 0)
                {
                    return; // Hủy, không thêm
                }
                
                // Tìm sản phẩm
                SanPham sp = null;
                for (int j = 0; j < DanhSachSP.Count; j++)
                {
                    if (DanhSachSP[j].MaSP == ct.MaSP)
                    {
                        sp = DanhSachSP[j];
                        break;
                    }
                }
                
                // Kiểm tra mã sản phẩm phải tồn tại
                if (sp == null)
                {
                    return; // Hủy, không thêm
                }
                
                // Kiểm tra số lượng không vượt tồn kho
                if (ct.SoLuongBan > sp.SoLuongTon)
                {
                    return; // Hủy, không thêm
                }
                
                // Kiểm tra đơn giá bán >= giá nhập * 1.1
                if (ct.DonGiaBan < sp.GiaNhap * 1.1)
                {
                    return; // Hủy, không thêm
                }
            }

            // Tất cả hợp lệ → Cập nhật tồn kho và thêm hóa đơn
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDon ct = hd.ChiTiet[i];
                for (int j = 0; j < DanhSachSP.Count; j++)
                {
                    if (DanhSachSP[j].MaSP == ct.MaSP)
                    {
                        DanhSachSP[j].SoLuongTon -= ct.SoLuongBan;
                        break;
                    }
                }
            }
            
            DanhSachHD.Add(hd);
        }

        public KhachHang ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
        {
            // Lọc các hóa đơn trong tháng/năm
            List<HoaDon> hoaDonThang = new List<HoaDon>();
            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                if (DanhSachHD[i].NgayLap.Month == thang && DanhSachHD[i].NgayLap.Year == nam)
                {
                    hoaDonThang.Add(DanhSachHD[i]);
                }
            }
            
            // Nếu không có hóa đơn nào
            if (hoaDonThang.Count == 0)
            {
                return null;
            }

            // Tính tổng tiền thanh toán thực tế của từng khách hàng
            Dictionary<string, double> tongTienTheoKH = new Dictionary<string, double>();
            
            for (int i = 0; i < hoaDonThang.Count; i++)
            {
                HoaDon hd = hoaDonThang[i];
                
                // Tính tổng tiền chi tiết
                double tongTienChiTiet = 0;
                for (int j = 0; j < hd.ChiTiet.Count; j++)
                {
                    tongTienChiTiet += hd.ChiTiet[j].DonGiaBan * hd.ChiTiet[j].SoLuongBan;
                }
                
                // Tìm khách hàng để lấy loại và chiết khấu
                KhachHang kh = null;
                for (int j = 0; j < DanhSachKH.Count; j++)
                {
                    if (DanhSachKH[j].MaKH == hd.MaKH)
                    {
                        kh = DanhSachKH[j];
                        break;
                    }
                }
                
                if (kh != null)
                {
                    // Lấy chiết khấu theo loại khách hàng
                    double chietKhau = 0;
                    if (ChietKhauTheoLoai.ContainsKey(kh.LoaiKH))
                    {
                        chietKhau = ChietKhauTheoLoai[kh.LoaiKH];
                    }
                    
                    // Tính tiền thanh toán thực tế
                    double tienThanhToan = tongTienChiTiet * (1 - chietKhau);
                    
                    // Cộng dồn vào tổng của khách hàng
                    if (tongTienTheoKH.ContainsKey(hd.MaKH))
                    {
                        tongTienTheoKH[hd.MaKH] += tienThanhToan;
                    }
                    else
                    {
                        tongTienTheoKH[hd.MaKH] = tienThanhToan;
                    }
                }
            }
            
            // Tìm khách hàng có tổng tiền cao nhất
            string maKHMax = null;
            double tongMax = 0;
            
            foreach (var item in tongTienTheoKH)
            {
                if (maKHMax == null || item.Value > tongMax)
                {
                    maKHMax = item.Key;
                    tongMax = item.Value;
                }
            }
            
            // Trả về đối tượng KhachHang
            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (DanhSachKH[i].MaKH == maKHMax)
                {
                    return DanhSachKH[i];
                }
            }
            
            return null;
        }
    }
}
