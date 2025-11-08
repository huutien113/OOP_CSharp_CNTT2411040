using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    abstract class NhanVien
    {
        string maNV;
        string hoTen;
        string email;

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Email { get => email; set => email = value; }

        public virtual void NhapThongTin()
        {
            Console.Write("Nhap MaNV: ");
            MaNV = Console.ReadLine();
            Console.Write("Nhap Ho Ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap Email: ");
            Email = Console.ReadLine();

        }
        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"MaNV: {MaNV}, Ho Ten: {HoTen}, Email: {Email}");
        }
        public abstract double TinhLuong();
    }
}
