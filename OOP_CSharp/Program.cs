using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            PhanSo a = new PhanSo(3,6);
            PhanSo b = new PhanSo(2,5);
            (a + b).HienThi();
            Console.WriteLine(a<b);
            Console.WriteLine(((double)a));
        }
    }
}
