using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    class NhanVienBienChe : NhanVien
    {
        double luongCoBan;
        double heSoLuong;
        double thuong;

        public double LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
        public double Thuong { get => thuong; set => thuong = value; }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap Luong Co Ban: ");
            LuongCoBan = double.Parse(Console.ReadLine());
            Console.Write("Nhap He So Luong: ");
            HeSoLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap Thuong: ");
            Thuong = double.Parse(Console.ReadLine());

        }

        public override double TinhLuong()
        {
            double LuongThucLinh = LuongCoBan * HeSoLuong + Thuong;
            return LuongThucLinh;
        }
        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Loai: Bien Che, Luong Co Ban: {LuongCoBan}, He So: {HeSoLuong}, Thuong: {Thuong}");
        }


    }
}
