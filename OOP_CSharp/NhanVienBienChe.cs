using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    class NhanVienBienChe : NhanVien
    {
        double luongCoBan;
        double heSoLuong;
        double thuong;

        public NhanVienBienChe()
        {
        }

        public NhanVienBienChe(string maNV, string hoTen, string email = "") : base(maNV, hoTen, email)
        {
        }

        public double LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
        public double Thuong { get => thuong; set => thuong = value; }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhập lương cơ bản: ");
            LuongCoBan = double.Parse(Console.ReadLine());
            Console.Write("Nhập hệ số lương: ");
            HeSoLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhập lương thưởng: ");
            Thuong = double.Parse(Console.ReadLine());
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Lương cơ bản: {LuongCoBan}");
            Console.WriteLine($"Hệ số lương: {HeSoLuong}");
            Console.WriteLine($"Lương thưởng: {Thuong}");
        }

        public override double TinhLuong()
        {
            return LuongCoBan * HeSoLuong + Thuong;
        }
    }
}
