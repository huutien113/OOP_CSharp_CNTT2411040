using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    class NhanVienHopDong:NhanVien
    {
        int soGioLamViec;
        double donGiaGio;

        public int SoGioLamViec { get => soGioLamViec; set => soGioLamViec = value; }
        public double DonGiaGio { get => donGiaGio; set => donGiaGio = value; }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap So Gio Lam Viec: ");
            SoGioLamViec = int.Parse(Console.ReadLine());
            Console.Write("Nhap Don Gia Gio: ");
            DonGiaGio = double.Parse(Console.ReadLine());
        }
        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Loai: Hop Dong, So Gio Lam Viec: {SoGioLamViec}, Don Gia Gio: {DonGiaGio}");
        }

        public override double TinhLuong()
        {
            return SoGioLamViec * DonGiaGio;
        }
    }
}
