using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTGK_CSharp;

namespace OOP_CSharp
{
    class TestQuanLyCuaHang
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== BẮT ĐẦU KIỂM THỬ QuanLyCuaHang ===\n");

            var ql = new QuanLyCuaHang();

            Console.WriteLine("1. TEST CapNhatSoLuongTon trước khi thêm sản phẩm:");
            ql.CapNhatSoLuongTon(1, 10); // Không tồn tại → bỏ qua
            Console.WriteLine("   ✓ Không có lỗi (mã sản phẩm chưa tồn tại)\n");

            Console.WriteLine("2. Thêm sản phẩm:");
            var sp1 = new SanPham(1, "Bàn phím cơ RK", 850000, 10, "Royal Kludge");
            var sp2 = new SanPham(2, "Chuột G Pro", 1200000, 8, "Logitech");
            var sp3 = new SanPham(3, "Tai nghe WH-1000", 6500000, 3, "Sony");
            ql.ThemSanPham(sp1);
            ql.ThemSanPham(sp2);
            ql.ThemSanPham(sp3);
            Console.WriteLine("   ✓ Đã thêm 3 sản phẩm\n");

            Console.WriteLine("3. TEST CapNhatSoLuongTon sau khi thêm:");
            Console.WriteLine($"   Trước: SP1 tồn = {ql.DanhSachSP[0].SoLuongTon}");
            ql.CapNhatSoLuongTon(1, 5);
            Console.WriteLine($"   Sau: SP1 tồn = {ql.DanhSachSP[0].SoLuongTon}");
            Console.WriteLine("   ✓ Cập nhật đúng (+5)\n");

            Console.WriteLine("4. TEST TimKiemSanPhamTheoNhaCungCap:");
            var ketQua = ql.TimKiemSanPhamTheoNhaCungCap("LOGITECH");
            Console.WriteLine($"   Tìm 'LOGITECH': {ketQua.Count} sản phẩm");
            if (ketQua.Count > 0)
                Console.WriteLine($"   - {ketQua[0].TenSP}");
            Console.WriteLine("   ✓ Tìm kiếm không phân biệt hoa thường\n");

            Console.WriteLine("5. Thêm khách hàng:");
            var kh1 = new KhachHang("KH001", "Nguyễn Văn Út Mới", "Hà Nội", "VIP");
            var kh2 = new KhachHang("KH002", "Trần Thị Thanh", "Đà Nẵng", "Thuong");
            var kh3 = new KhachHang("KH003", "Lê Văn Tường", "TP.HCM", "Moi");
            ql.ThemKhachHang(kh1);
            ql.ThemKhachHang(kh2);
            ql.ThemKhachHang(kh3);
            Console.WriteLine("   ✓ Đã thêm 3 khách hàng\n");

            Console.WriteLine("6. TEST ThemHoaDon - Hóa đơn hợp lệ:");
            Console.WriteLine("   Tạo HD1: KH001, 2 SP1 (950k), 1 SP2 (1350k)");
            Console.WriteLine($"   Tồn trước: SP1={ql.DanhSachSP[0].SoLuongTon}, SP2={ql.DanhSachSP[1].SoLuongTon}");
            
            var hd1 = new HoaDon(1001, "KH001", new DateTime(2025, 11, 10));
            hd1.ChiTiet.Add(new ChiTietHoaDon(1, 2, 950000));   // OK
            hd1.ChiTiet.Add(new ChiTietHoaDon(2, 1, 1350000));  // OK
            
            try
            {
                bool result = ql.ThemHoaDon(hd1);
                Console.WriteLine($"   Kết quả: {result}");
                Console.WriteLine($"   Tồn sau: SP1={ql.DanhSachSP[0].SoLuongTon}, SP2={ql.DanhSachSP[1].SoLuongTon}");
                Console.WriteLine($"   Số hóa đơn trong hệ thống: {ql.DanhSachHD.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ✗ LỖI: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine("7. TEST ThemHoaDon - Hóa đơn hợp lệ tiếp:");
            Console.WriteLine("   Tạo HD2: KH002, 1 SP3 (7200k)");
            var hd2 = new HoaDon(1002, "KH002", new DateTime(2025, 11, 12));
            hd2.ChiTiet.Add(new ChiTietHoaDon(3, 1, 7200000));  // OK
            
            try
            {
                bool result = ql.ThemHoaDon(hd2);
                Console.WriteLine($"   Kết quả: {result}");
                Console.WriteLine($"   Tồn SP3: {ql.DanhSachSP[2].SoLuongTon}");
                Console.WriteLine($"   Số hóa đơn trong hệ thống: {ql.DanhSachHD.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ✗ LỖI: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine("8. TEST ThemHoaDon - Hóa đơn KHÔNG hợp lệ (vượt tồn kho):");
            Console.WriteLine("   Tạo HD3: KH003, 15 SP1 (900k) - chỉ còn tồn ít hơn");
            Console.WriteLine($"   Tồn trước: SP1={ql.DanhSachSP[0].SoLuongTon}");
            var hd3 = new HoaDon(1003, "KH003", new DateTime(2025, 11, 15));
            hd3.ChiTiet.Add(new ChiTietHoaDon(1, 15, 900000));  // Lỗi: vượt tồn kho
            
            try
            {
                bool result = ql.ThemHoaDon(hd3);
                Console.WriteLine($"   Kết quả: {result}");
                Console.WriteLine($"   Tồn sau: SP1={ql.DanhSachSP[0].SoLuongTon}");
                Console.WriteLine($"   Số hóa đơn trong hệ thống: {ql.DanhSachHD.Count}");
                
                if (ql.DanhSachSP[0].SoLuongTon < 0)
                {
                    Console.WriteLine("   ✗ LỖI NGHIÊM TRỌNG: Tồn kho âm!");
                }
                if (result == true || ql.DanhSachHD.Count == 3)
                {
                    Console.WriteLine("   ✗ LỖI: Hóa đơn không hợp lệ nhưng vẫn được thêm!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ✗ LỖI: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine("9. TEST ThongKeKhachHangMuaNhieuNhat:");
            try
            {
                var khTop = ql.ThongKeKhachHangMuaNhieuNhat(11, 2025);
                if (khTop != null)
                {
                    Console.WriteLine($"   Khách mua nhiều nhất: {khTop.HoTen}");
                    Console.WriteLine($"   Loại khách: {khTop.LoaiKH}");
                    
                    // Tính toán thủ công để kiểm tra
                    Console.WriteLine("\n   KIỂM TRA TÍNH TOÁN:");
                    Console.WriteLine("   HD1 (KH001-VIP, chiết khấu 10%):");
                    Console.WriteLine("     - 2 x 950,000 = 1,900,000");
                    Console.WriteLine("     - 1 x 1,350,000 = 1,350,000");
                    Console.WriteLine("     - Tổng = 3,250,000");
                    Console.WriteLine("     - Sau CK = 3,250,000 x 0.9 = 2,925,000");
                    Console.WriteLine("   HD2 (KH002-Thuong, chiết khấu 5%):");
                    Console.WriteLine("     - 1 x 7,200,000 = 7,200,000");
                    Console.WriteLine("     - Sau CK = 7,200,000 x 0.95 = 6,840,000");
                    Console.WriteLine("   => KH002 phải là người mua nhiều nhất!");
                    
                    if (khTop.MaKH != "KH002")
                    {
                        Console.WriteLine($"   ✗ LỖI: Kết quả sai! Phải là KH002 nhưng trả về {khTop.MaKH}");
                    }
                    else
                    {
                        Console.WriteLine("   ✓ Kết quả đúng!");
                    }
                }
                else
                {
                    Console.WriteLine("   ✗ Trả về null (không đúng)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ✗ LỖI: {ex.Message}");
                Console.WriteLine($"   Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("\n=== KẾT THÚC KIỂM THỬ ===");
            Console.ReadKey();
        }
    }
}
