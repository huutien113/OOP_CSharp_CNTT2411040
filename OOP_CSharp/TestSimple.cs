using System;
using System.Collections.Generic;

namespace KTGK_CSharp
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public double GiaNhap { get; set; }
        public int SoLuongTon { get; set; }
        public string NhaCungCap { get; set; }

        public SanPham(int maSP, string tenSP, double giaNhap, int soLuongTon, string nhaCungCap)
        {
            MaSP = maSP; TenSP = tenSP; GiaNhap = giaNhap; SoLuongTon = soLuongTon; NhaCungCap = nhaCungCap;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - NCC: {2} - Tồn: {3}", MaSP, TenSP, NhaCungCap, SoLuongTon);
        }
    }

    public class KhachHang
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string LoaiKH { get; set; }

        public KhachHang(string maKH, string hoTen, string diaChi, string loaiKH)
        {
            MaKH = maKH; HoTen = hoTen; DiaChi = diaChi; LoaiKH = loaiKH;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2}) - {3}", MaKH, HoTen, LoaiKH, DiaChi);
        }
    }

    public class HoaDon
    {
        public int SoHD { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayLap { get; set; }
        public List<ChiTietHoaDon> ChiTiet { get; set; }

        public HoaDon(int soHD, string maKH, DateTime ngayLap)
        {
            SoHD = soHD; MaKH = maKH; NgayLap = ngayLap;
            ChiTiet = new List<ChiTietHoaDon>();
        }
    }

    public class ChiTietHoaDon
    {
        public int MaSP { get; set; }
        public int SoLuongBan { get; set; }
        public double DonGiaBan { get; set; }

        public ChiTietHoaDon(int maSP, int soLuongBan, double donGiaBan)
        {
            MaSP = maSP; SoLuongBan = soLuongBan; DonGiaBan = donGiaBan;
        }
    }
}

namespace OOP_CSharp
{
    using KTGK_CSharp;
    
    class QuanLyCuaHang
    {
        private List<SanPham> danhSachSP;
        private List<KhachHang> danhSachKH;
        private List<HoaDon> danhSachHD;
        private Dictionary<string, double> chietKhauTheoLoai;

        public List<SanPham> DanhSachSP { get { return danhSachSP; } set { danhSachSP = value; } }
        public List<KhachHang> DanhSachKH { get { return danhSachKH; } set { danhSachKH = value; } }
        public List<HoaDon> DanhSachHD { get { return danhSachHD; } set { danhSachHD = value; } }
        public Dictionary<string, double> ChietKhauTheoLoai
        {
            get { return chietKhauTheoLoai; }
            set { chietKhauTheoLoai = value; }
        }

        public void ThemSanPham(SanPham sp)
        {
            DanhSachSP.Add(sp);
        }

        public void ThemKhachHang(KhachHang kh)
        {
            DanhSachKH.Add(kh);
        }

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

    class TestSimple
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAT DAU KIEM THU QuanLyCuaHang ===\n");

            var ql = new QuanLyCuaHang();

            Console.WriteLine("1. Them san pham:");
            var sp1 = new SanPham(1, "Ban phim co RK", 850000, 10, "Royal Kludge");
            var sp2 = new SanPham(2, "Chuot G Pro", 1200000, 8, "Logitech");
            var sp3 = new SanPham(3, "Tai nghe WH-1000", 6500000, 3, "Sony");
            ql.ThemSanPham(sp1);
            ql.ThemSanPham(sp2);
            ql.ThemSanPham(sp3);
            Console.WriteLine("   Da them 3 san pham\n");

            Console.WriteLine("2. Them khach hang:");
            var kh1 = new KhachHang("KH001", "Nguyen Van Ut Moi", "Ha Noi", "VIP");
            var kh2 = new KhachHang("KH002", "Tran Thi Thanh", "Da Nang", "Thuong");
            var kh3 = new KhachHang("KH003", "Le Van Tuong", "TP.HCM", "Moi");
            ql.ThemKhachHang(kh1);
            ql.ThemKhachHang(kh2);
            ql.ThemKhachHang(kh3);
            Console.WriteLine("   Da them 3 khach hang\n");

            Console.WriteLine("3. TEST ThemHoaDon - Hoa don hop le:");
            Console.WriteLine("   Tao HD1: KH001, 2 SP1 (950k), 1 SP2 (1350k)");
            Console.WriteLine("   Ton truoc: SP1={0}, SP2={1}", ql.DanhSachSP[0].SoLuongTon, ql.DanhSachSP[1].SoLuongTon);
            
            var hd1 = new HoaDon(1001, "KH001", new DateTime(2025, 11, 10));
            hd1.ChiTiet.Add(new ChiTietHoaDon(1, 2, 950000));
            hd1.ChiTiet.Add(new ChiTietHoaDon(2, 1, 1350000));
            
            ql.ThemHoaDon(hd1);
            Console.WriteLine("   Ton sau: SP1={0}, SP2={1}", ql.DanhSachSP[0].SoLuongTon, ql.DanhSachSP[1].SoLuongTon);
            Console.WriteLine("   So hoa don: {0}\n", ql.DanhSachHD.Count);

            Console.WriteLine("4. TEST ThemHoaDon - Hoa don hop le tiep:");
            Console.WriteLine("   Tao HD2: KH002, 1 SP3 (7200k)");
            var hd2 = new HoaDon(1002, "KH002", new DateTime(2025, 11, 12));
            hd2.ChiTiet.Add(new ChiTietHoaDon(3, 1, 7200000));
            
            ql.ThemHoaDon(hd2);
            Console.WriteLine("   Ton SP3: {0}", ql.DanhSachSP[2].SoLuongTon);
            Console.WriteLine("   So hoa don: {0}\n", ql.DanhSachHD.Count);

            Console.WriteLine("5. TEST ThemHoaDon - KHONG hop le (vuot ton kho):");
            Console.WriteLine("   Tao HD3: KH003, 15 SP1 (900k) - chi con ton it hon");
            Console.WriteLine("   Ton truoc: SP1={0}", ql.DanhSachSP[0].SoLuongTon);
            var hd3 = new HoaDon(1003, "KH003", new DateTime(2025, 11, 15));
            hd3.ChiTiet.Add(new ChiTietHoaDon(1, 15, 900000));
            
            ql.ThemHoaDon(hd3);
            Console.WriteLine("   Ton sau: SP1={0}", ql.DanhSachSP[0].SoLuongTon);
            Console.WriteLine("   So hoa don: {0}", ql.DanhSachHD.Count);
            
            if (ql.DanhSachSP[0].SoLuongTon < 0)
            {
                Console.WriteLine("   LOI NGHIEM TRONG: Ton kho am!");
            }
            else if (ql.DanhSachHD.Count == 2)
            {
                Console.WriteLine("   DUNG: Hoa don khong hop le da bi tu choi!");
            }
            else
            {
                Console.WriteLine("   LOI: Hoa don khong hop le nhung van duoc them!");
            }
            Console.WriteLine();

            Console.WriteLine("6. TEST ThongKeKhachHangMuaNhieuNhat:");
            var khTop = ql.ThongKeKhachHangMuaNhieuNhat(11, 2025);
            if (khTop != null)
            {
                Console.WriteLine("   Khach mua nhieu nhat: {0}", khTop.HoTen);
                Console.WriteLine("   Loai khach: {0}", khTop.LoaiKH);
                
                Console.WriteLine("\n   KIEM TRA TINH TOAN:");
                Console.WriteLine("   HD1 (KH001-VIP, chiet khau 10%):");
                Console.WriteLine("     - 2 x 950,000 = 1,900,000");
                Console.WriteLine("     - 1 x 1,350,000 = 1,350,000");
                Console.WriteLine("     - Tong = 3,250,000");
                Console.WriteLine("     - Sau CK = 3,250,000 x 0.9 = 2,925,000");
                Console.WriteLine("   HD2 (KH002-Thuong, chiet khau 5%):");
                Console.WriteLine("     - 1 x 7,200,000 = 7,200,000");
                Console.WriteLine("     - Sau CK = 7,200,000 x 0.95 = 6,840,000");
                Console.WriteLine("   => KH002 phai la nguoi mua nhieu nhat!");
                
                if (khTop.MaKH != "KH002")
                {
                    Console.WriteLine("   LOI: Ket qua sai! Phai la KH002 nhung tra ve {0}", khTop.MaKH);
                }
                else
                {
                    Console.WriteLine("   DUNG: Ket qua chinh xac!");
                }
            }
            else
            {
                Console.WriteLine("   LOI: Tra ve null");
            }

            Console.WriteLine("\n=== KET THUC KIEM THU ===");
        }
    }
}
