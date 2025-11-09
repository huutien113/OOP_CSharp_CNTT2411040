using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

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
            PhanSo a = new PhanSo();
            PhanSo b = new PhanSo();
            try
            {
                a = new PhanSo(2, 1);
                b = new PhanSo(2, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            (a * b).HienThi();
            Console.WriteLine(a > b);
        }
    }
}
