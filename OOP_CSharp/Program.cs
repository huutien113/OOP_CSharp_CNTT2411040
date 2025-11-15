using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using ConsoleApplication3;

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



            Company CongTy = new Company();
            Employee a = new FullTimeEmployee(id: "FT001", name: "Cristiano Ronaldo", dept: "HR", hireDate: DateTime.Parse("11/3/2022"), baseSalary: 6000000, bonusRate: 0.2);
            CongTy.AddEmployee(a);
            a = new FullTimeEmployee(id: "FT002", name: "Trịnh Trần Phương Tuấn", dept: "MKT", hireDate: DateTime.Parse("7/26/2023"), baseSalary: 4000000, bonusRate: 0.25);
            CongTy.AddEmployee(a);
            a = new FullTimeEmployee(id: "FT003", name: "Lionel Messi", dept: "HR", hireDate: DateTime.Parse("3/24/2022"), baseSalary: 5000000, bonusRate: 0.3);
            CongTy.AddEmployee(a);
            a = new FullTimeEmployee(id: "FT004", name: "Nguyễn Văn Cường", dept: "IT", hireDate: DateTime.Parse("5/14/2021"), baseSalary: 6000000, bonusRate: 0.25);
            CongTy.AddEmployee(a);
            a = new PartTimeEmployee(id: "PT001", name: "Phạm Yến Nhi", dept: "IT", hireDate: DateTime.Parse("12/31/2023"), hourlyRate: 30000, hoursWorked: 240);
            CongTy.AddEmployee(a);
            a = new PartTimeEmployee(id: "PT002", name: "Nguyễn Duy Khương", dept: "IT", hireDate: DateTime.Parse("1/22/2023"), hourlyRate: 32000, hoursWorked: 240);
            CongTy.AddEmployee(a);
            a = new PartTimeEmployee(id: "PT003", name: "Lê Ngọc Triết", dept: "MKT", hireDate: DateTime.Parse("10/25/2015"), hourlyRate: 32000, hoursWorked: 240);
            CongTy.AddEmployee(a);
            a = new Manager(id: "FT005", name: "Nguyễn Thanh Tùng", dept: "MKT", hireDate: DateTime.Parse("5/24/2018"), baseSalary: 7000000, bonusRate: 0.3, subordinates: 2);
            CongTy.AddEmployee(a);
            a = new Manager(id: "FT006", name: "Phạm Nhật Vượng", dept: "HR", hireDate: DateTime.Parse("9/9/2018"), baseSalary: 9000000, bonusRate: 0.3, subordinates: 2);
            CongTy.AddEmployee(a);
            a = new Manager(id: "FT007", name: "Huỳnh Hữu Tiến", dept: "IT", hireDate: DateTime.Parse("3/11/2018"), baseSalary: 9000000, bonusRate: 0.3, subordinates: 4);
            CongTy.AddEmployee(a);

            Console.WriteLine($"Toàn bộ nhân viên: {CongTy.HienThiTatCa()}");

            Console.WriteLine($"Tổng quỹ lương là: {CongTy.CalculateTotalPayroll()}");



            Dictionary<string, int> ThongKe = CongTy.CountEmployeesByType();
            for (int i = 0; i < ThongKe.Count; i++)
            {
                string key = ThongKe.ElementAt(i).Key;
                int value = ThongKe.ElementAt(i).Value;

                Console.WriteLine($"{key}: {value}");
            }


            Console.Write("Nhập phòng ban muốn thống kê: ");
            string pb = Console.ReadLine().ToUpper();
            List<Employee> ThongKePB = CongTy.GetEmployeesByDepartment(pb);

            if (ThongKePB.Count == 0)
            {
                Console.WriteLine("Phòng ban không có nhân viên hoặc phòng ban ko tồn tại");
            }
            else
            {
                for (int i = 0; i < ThongKePB.Count; i++)
                {
                    Console.WriteLine(ThongKePB[i].GetInfo());
                }
            }

            int Top = 5;
            Console.WriteLine($"Top {Top} lương cao nhất: ");            
            List<Employee> Top5 = CongTy.GetTopHighestPaid(Top);
            for (int i = 0;i < Top5.Count;i++)
            {
                Console.WriteLine(Top5[i].GetInfo());
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Toàn bộ nhân viên: {CongTy.HienThiTatCa()}");
        }
    }
}
