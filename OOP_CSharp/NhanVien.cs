using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    abstract class NhanVien
    {
        string maNV;
        string hoTen;
        string email;

        public NhanVien()
        { }
        public NhanVien(string maNV, string hoTen, string email = "")
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            Email = email;
        }
        public string MaNV { get => maNV; }
        public string HoTen { get => hoTen;  }
        public string Email { get => email; set => email = value; }

        public virtual void NhapThongTin()
        {
            Console.Write("Nhập mã nhân viên: ");
            maNV = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhập email: ");
            Email = Console.ReadLine();
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã nhân viên: {MaNV}");
            Console.WriteLine($"Họ tên: {HoTen}");
            Console.WriteLine($"Email: {Email}");
        }

        public abstract double TinhLuong();

    }
}
