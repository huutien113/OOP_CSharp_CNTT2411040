using System;
using System.Collections.Generic;
using KTGK_CSharp;

namespace OOP_CSharp
{
    class TestKiemTra
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TEST ĐỀ 0: QuanLyCuaHang ===");
            TestDe0();
            
            Console.WriteLine("\n\n=== TEST ĐỀ 1: QuanLyNhaThuoc ===");
            TestDe1();
            
            Console.WriteLine("\n\n=== TEST ĐỀ 2: QuanLyNhaSach ===");
            TestDe2();
        }

        static void TestDe0()
        {
            var ql = new QuanLyCuaHang();
            // Thêm sản phẩm
            ql.CapNhatSoLuongTon(1, 10); // Không tồn tại → bỏ qua
            var sp1 = new SanPham(1, "Bàn phím cơ RK", 850000, 10, "Royal Kludge");
            var sp2 = new SanPham(2, "Chuột G Pro", 1200000, 8, "Logitech");
            var sp3 = new SanPham(3, "Tai nghe WH-1000", 6500000, 3, "Sony");
            ql.ThemSanPham(sp1);
            ql.ThemSanPham(sp2);
            ql.ThemSanPham(sp3);
            // Thêm khách
            var kh1 = new KhachHang("KH001", "Nguyễn Văn Út Mới", "Hà Nội", "VIP");
            var kh2 = new KhachHang("KH002", "Trần Thị Thanh", "Đà Nẵng", "Thuong");
            var kh3 = new KhachHang("KH003", "Lê Văn Tường", "TP.HCM", "Moi");
            ql.ThemKhachHang(kh1);
            ql.ThemKhachHang(kh2);
            ql.ThemKhachHang(kh3);
            // Tạo hóa đơn
            var hd1 = new HoaDon(1001, "KH001", new DateTime(2025, 11, 10));
            hd1.ChiTiet.Add(new ChiTietHoaDon(1, 2, 950000));   // OK
            hd1.ChiTiet.Add(new ChiTietHoaDon(2, 1, 1350000));  // OK
            var hd2 = new HoaDon(1002, "KH002", new DateTime(2025, 11, 12));
            hd2.ChiTiet.Add(new ChiTietHoaDon(3, 1, 7200000));  // OK
            var hd3 = new HoaDon(1003, "KH003", new DateTime(2025, 11, 15));
            hd3.ChiTiet.Add(new ChiTietHoaDon(1, 15, 900000));  // Lỗi: vượt tồn kho
            // Thêm hóa đơn
            ql.ThemHoaDon(hd1);
            ql.ThemHoaDon(hd2);
            ql.ThemHoaDon(hd3); // Bị từ chối
            // Thống kê
            var khTop = ql.ThongKeKhachHangMuaNhieuNhat(11, 2025);
            if (khTop!=null)
                Console.WriteLine("Khách mua nhiều nhất: " + khTop.HoTen);
            else
                Console.WriteLine("Không có khách mua hàng vào thời gian này!");
        }

        static void TestDe1()
        {
            var ql = new QuanLyNhaThuoc();
            // Thêm thuốc
            ql.CapNhatSoLuongTon(1, 10); // Không tồn tại → bỏ qua
            var t1 = new Thuoc(1, "Paracetamol", 50000, 100, "Sanofi");
            var t2 = new Thuoc(2, "Amoxicillin", 150000, 50, "Pfizer");
            var t3 = new Thuoc(3, "Vitamin C", 30000, 200, "Bayer");
            ql.ThemThuoc(t1);
            ql.ThemThuoc(t2);
            ql.ThemThuoc(t3);
            // Thêm bệnh nhân
            var bn1 = new BenhNhan("BN001", "Nguyễn Văn An", "Hà Nội", "VIP");
            var bn2 = new BenhNhan("BN002", "Trần Thị Bích", "Đà Nẵng", "Thuong");
            var bn3 = new BenhNhan("BN003", "Lê Văn Cung", "TP.HCM", "Moi");
            ql.ThemBenhNhan(bn1);
            ql.ThemBenhNhan(bn2);
            ql.ThemBenhNhan(bn3);
            // Tạo đơn thuốc
            var dt1 = new DonThuoc(1001, "BN001", new DateTime(2025, 11, 10));
            dt1.ChiTiet.Add(new ChiTietDonThuoc(1, 5, 55000));   // OK
            dt1.ChiTiet.Add(new ChiTietDonThuoc(2, 2, 165000));  // OK
            var dt2 = new DonThuoc(1002, "BN002", new DateTime(2025, 11, 12));
            dt2.ChiTiet.Add(new ChiTietDonThuoc(3, 10, 33000));  // OK
            var dt3 = new DonThuoc(1003, "BN003", new DateTime(2025, 11, 15));
            dt3.ChiTiet.Add(new ChiTietDonThuoc(1, 150, 50000));  // Lỗi: vượt tồn kho
            // Thêm đơn thuốc
            ql.ThemDonThuoc(dt1);
            ql.ThemDonThuoc(dt2);
            ql.ThemDonThuoc(dt3); // Bị từ chối
            // Thống kê
            var bnTop = ql.ThongKeBenhNhanChiTieuNhieuNhat(11, 2025);
            if (bnTop != null)
                Console.WriteLine("Bệnh nhân chi tiêu nhiều nhất: " + bnTop.HoTen);
            else
                Console.WriteLine("Không có bệnh nhân vào thời gian này!");
        }

        static void TestDe2()
        {
            var ql = new QuanLyNhaSach();
            // Thêm sách
            ql.CapNhatSoLuongTon(1, 10); // Không tồn tại → bỏ qua
            var s1 = new Sach(1, "Harry Potter", 150000, 20, "Bloomsbury");
            var s2 = new Sach(2, "The Hobbit", 200000, 15, "HarperCollins");
            var s3 = new Sach(3, "1984", 100000, 30, "Penguin");
            ql.ThemSach(s1);
            ql.ThemSach(s2);
            ql.ThemSach(s3);
            // Thêm độc giả
            var dg1 = new DocGia("DG001", "Nguyễn Văn An", "Hà Nội", "VIP");
            var dg2 = new DocGia("DG002", "Trần Thị Bích", "Đà Nẵng", "Thuong");
            var dg3 = new DocGia("DG003", "Lê Văn Cung", "TP.HCM", "Moi");
            ql.ThemDocGia(dg1);
            ql.ThemDocGia(dg2);
            ql.ThemDocGia(dg3);
            // Tạo hóa đơn
            var hd1 = new HoaDonMuaSach(1001, "DG001", new DateTime(2025, 11, 10));
            hd1.ChiTiet.Add(new ChiTietHoaDonMuaSach(1, 3, 165000));   // OK
            hd1.ChiTiet.Add(new ChiTietHoaDonMuaSach(2, 1, 220000));  // OK
            var hd2 = new HoaDonMuaSach(1002, "DG002", new DateTime(2025, 11, 12));
            hd2.ChiTiet.Add(new ChiTietHoaDonMuaSach(3, 5, 110000));  // OK
            var hd3 = new HoaDonMuaSach(1003, "DG003", new DateTime(2025, 11, 15));
            hd3.ChiTiet.Add(new ChiTietHoaDonMuaSach(1, 25, 150000));  // Lỗi: vượt tồn kho
            // Thêm hóa đơn
            ql.ThemHoaDonMuaSach(hd1);
            ql.ThemHoaDonMuaSach(hd2);
            ql.ThemHoaDonMuaSach(hd3); // Bị từ chối
            // Thống kê
            var dgTop = ql.ThongKeDocGiaMuaNhieuNhat(11, 2025);
            if (dgTop != null)
                Console.WriteLine("Độc giả mua nhiều nhất: " + dgTop.HoTen);
            else
                Console.WriteLine("Không có độc giả mua sách vào thời gian này!");
        }
    }
}
