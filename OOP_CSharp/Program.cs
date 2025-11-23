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




            //OnlineShop shop = new OnlineShop();

            //Laptop a = new Laptop("LP001", "Dell XPS 15", 35000000, 15, "i7-12700H", 16, "RTX 3050");
            //shop.AddProduct(a);
            //a = new Laptop("LP002", "MacBook Pro 14", 55000000, 13, "M2 Pro", 16, "Integrated");
            //shop.AddProduct(a);
            //a = new Laptop("LP003", "Asus ROG", 42000000, 11, "Ryzen 9", 32, "RTX 3070");
            //shop.AddProduct(a);
            //a = new Laptop("LP004", "HP Spectre", 30000000, 12, "i5-1235U", 8, "Iris Xe");
            //shop.AddProduct(a);


            //Smartphone b = new Smartphone("SP001", "iPhone 15", 25000000, 16, "6.1", 48);
            //shop.AddProduct(b);
            //b = new Smartphone("SP002", "Samsung S24", 22000000, 14, "6.2", 50);
            //shop.AddProduct(b);
            //b = new Smartphone("SP003", "Xiaomi 14", 15000000, 15, "6.36", 50);
            //shop.AddProduct(b);
            //b = new Smartphone("SP004", "Oppo Reno", 12000000, 17, "6.4", 64);
            //shop.AddProduct(b);



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
        }
    }
}
