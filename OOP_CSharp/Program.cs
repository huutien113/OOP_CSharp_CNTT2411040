using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleApp1;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //QuanLyCongTy CongTy = new QuanLyCongTy();
            //CongTy.ThemNhanVien();
            //CongTy.ThemNhanVien();
            //CongTy.ThemNhanVien();

            //CongTy.HienThiBangLuong();
            //Console.WriteLine($"Tổng quỹ lương: {CongTy.TinhTongQuyLuong()}");
            //CongTy.LuongCaoNhat();
            //Console.WriteLine($"Tổng số giờ làm việc của NVHĐ là: { CongTy.TinhTongSoGio()}");



            //PhanSo a = new PhanSo();
            //PhanSo b = new PhanSo();
            //try
            //{
            //    a = new PhanSo(2, 1);
            //    b = new PhanSo(2, 0);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //(a * b).HienThi();
            //Console.WriteLine(a > b);



            //Company CongTy = new Company();
            //Employee a = new FullTimeEmployee(id: "FT001", name: "Cristiano Ronaldo", dept: "HR", hireDate: DateTime.Parse("11/3/2022"), baseSalary: 6000000, bonusRate: 0.2);
            //CongTy.AddEmployee(a);
            //a = new FullTimeEmployee(id: "FT002", name: "Trịnh Trần Phương Tuấn", dept: "MKT", hireDate: DateTime.Parse("7/26/2023"), baseSalary: 4000000, bonusRate: 0.25);
            //CongTy.AddEmployee(a);
            //a = new FullTimeEmployee(id: "FT003", name: "Lionel Messi", dept: "HR", hireDate: DateTime.Parse("3/24/2022"), baseSalary: 5000000, bonusRate: 0.3);
            //CongTy.AddEmployee(a);
            //a = new FullTimeEmployee(id: "FT004", name: "Nguyễn Văn Cường", dept: "IT", hireDate: DateTime.Parse("5/14/2021"), baseSalary: 6000000, bonusRate: 0.25);
            //CongTy.AddEmployee(a);
            //a = new PartTimeEmployee(id: "PT001", name: "Phạm Yến Nhi", dept: "IT", hireDate: DateTime.Parse("12/31/2023"), hourlyRate: 30000, hoursWorked: 240);
            //CongTy.AddEmployee(a);
            //a = new PartTimeEmployee(id: "PT002", name: "Nguyễn Duy Khương", dept: "IT", hireDate: DateTime.Parse("1/22/2023"), hourlyRate: 32000, hoursWorked: 240);
            //CongTy.AddEmployee(a);
            //a = new PartTimeEmployee(id: "PT003", name: "Lê Ngọc Triết", dept: "MKT", hireDate: DateTime.Parse("10/25/2015"), hourlyRate: 32000, hoursWorked: 240);
            //CongTy.AddEmployee(a);
            //a = new Manager(id: "FT005", name: "Nguyễn Thanh Tùng", dept: "MKT", hireDate: DateTime.Parse("5/24/2018"), baseSalary: 7000000, bonusRate: 0.3, subordinates: 2);
            //CongTy.AddEmployee(a);
            //a = new Manager(id: "FT006", name: "Phạm Nhật Vượng", dept: "HR", hireDate: DateTime.Parse("9/9/2018"), baseSalary: 9000000, bonusRate: 0.3, subordinates: 2);
            //CongTy.AddEmployee(a);
            //a = new Manager(id: "FT007", name: "Huỳnh Hữu Tiến", dept: "IT", hireDate: DateTime.Parse("3/11/2018"), baseSalary: 9000000, bonusRate: 0.3, subordinates: 4);
            //CongTy.AddEmployee(a);

            //Console.WriteLine($"Toàn bộ nhân viên: {CongTy.HienThiTatCa()}");

            //Console.WriteLine($"Tổng quỹ lương là: {CongTy.CalculateTotalPayroll()}");



            //Dictionary<string, int> ThongKe = CongTy.CountEmployeesByType();
            //for (int i = 0; i < ThongKe.Count; i++)
            //{
            //    string key = ThongKe.ElementAt(i).Key;
            //    int value = ThongKe.ElementAt(i).Value;

            //    Console.WriteLine($"{key}: {value}");
            //}


            //Console.Write("Nhập phòng ban muốn thống kê: ");
            //string pb = Console.ReadLine().ToUpper();
            //List<Employee> ThongKePB = CongTy.GetEmployeesByDepartment(pb);

            //if (ThongKePB.Count == 0)
            //{
            //    Console.WriteLine("Phòng ban không có nhân viên hoặc phòng ban ko tồn tại");
            //}
            //else
            //{
            //    for (int i = 0; i < ThongKePB.Count; i++)
            //    {
            //        Console.WriteLine(ThongKePB[i].GetInfo());
            //    }
            //}

            //int Top = 3;
            //Console.WriteLine($"Top {Top} lương cao nhất: ");            
            //List<Employee> Top5 = CongTy.GetTopHighestPaid(Top);
            //for (int i = 0;i < Top5.Count;i++)
            //{
            //    Console.WriteLine(Top5[i].GetInfo());
            //}

            //Console.WriteLine("---------------------------------");
            //Console.WriteLine($"Toàn bộ nhân viên: {CongTy.HienThiTatCa()}");




            OnlineShop shop = new OnlineShop();

            Laptop a = new Laptop("LP001", "Dell XPS 15", 35000000, 15, "i7-12700H", 16, "RTX 3050");
            shop.AddProduct(a);
            a = new Laptop("LP002", "MacBook Pro 14", 55000000, 13, "M2 Pro", 16, "Integrated");
            shop.AddProduct(a);
            a = new Laptop("LP003", "Asus ROG", 42000000, 11, "Ryzen 9", 32, "RTX 3070");
            shop.AddProduct(a);
            a = new Laptop("LP004", "HP Spectre", 30000000, 12, "i5-1235U", 8, "Iris Xe");
            shop.AddProduct(a);


            Smartphone b = new Smartphone("SP001", "iPhone 15", 25000000, 16, "6.1", 48);
            shop.AddProduct(b);
            b = new Smartphone("SP002", "Samsung S24", 22000000, 14, "6.2", 50);
            shop.AddProduct(b);
            b = new Smartphone("SP003", "Xiaomi 14", 15000000, 15, "6.36", 50);
            shop.AddProduct(b);
            b = new Smartphone("SP004", "Oppo Reno", 12000000, 17, "6.4", 64);
            shop.AddProduct(b);



            //Order DonHang = new Order(id: "DH001", customer: "Nguyễn Văn Cường", discount: 0);
            //DonHang.AddItem(new Laptop("LP002", "MacBook Pro 14", 55000000, 3, "M2 Pro", 16, "Integrated"), 3);
            //DonHang.AddItem(new Smartphone("SP004", "Oppo Reno", 12000000, 8, "6.4", 64), 2);

            //if (shop.PlaceOrder(DonHang))
            //{
            //    Console.WriteLine("Đặt hàng thành công");               
            //}
            //else if (shop.PlaceOrder(DonHang) == false)
            //{
            //    Console.WriteLine("Đặt hàng không thành công");
            //}



            var ql = new QLCH();

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
            if (khTop != null)
                Console.WriteLine("Khách mua nhiều nhất: " + khTop.HoTen);
            else
                Console.WriteLine("Không có khách mua hàng vào thời gian này!");


        }
    }
}
