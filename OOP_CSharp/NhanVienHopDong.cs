using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    class NhanVienHopDong : NhanVien
    {
        int soGioLamViec;
        double donGiaGio;

        public NhanVienHopDong()
        {
        }

        public NhanVienHopDong(string maNV, string hoTen, string email = "") : base(maNV, hoTen, email)
        {
        }

        public int SoGioLamViec { get => soGioLamViec; set => soGioLamViec = value; }
        public double DonGiaGio { get => donGiaGio; set => donGiaGio = value; }


        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhập Số giờ làm việc: ");
            SoGioLamViec = int.Parse(Console.ReadLine());
            Console.Write("Nhập Đơn giá giờ: ");
            DonGiaGio = double.Parse(Console.ReadLine());
            
        }
        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Số giờ làm việc: {SoGioLamViec}");
            Console.WriteLine($"Đơn giá giờ: {DonGiaGio}");
        }
        public override double TinhLuong()
        {
            return SoGioLamViec * DonGiaGio;
        }

    }
}
