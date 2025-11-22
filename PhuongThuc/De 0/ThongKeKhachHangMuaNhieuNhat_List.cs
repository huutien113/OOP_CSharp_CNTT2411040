using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLyCuaHang
    {
        public KhachHang ThongKeKhachHangMuaNhieuNhat_List(int thang, int nam)
        {
            List<HoaDon> Lst_HD = new List<HoaDon>();
            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                if (DanhSachHD[i].NgayLap.Month == thang && DanhSachHD[i].NgayLap.Year == nam)
                {
                    Lst_HD.Add(DanhSachHD[i]);
                }
            }
            if (Lst_HD.Count == 0)
                return null;

            List<string> Lst_MaKH = new List<string>();
            List<double> Lst_TongTien = new List<double>();

            for (int i = 0; i < Lst_HD.Count; i++)
            {
                double Tong = 0;
                for (int j = 0; j < Lst_HD[i].ChiTiet.Count; j++)
                {
                    Tong += Lst_HD[i].ChiTiet[j].SoLuongBan * Lst_HD[i].ChiTiet[j].DonGiaBan;
                }

                KhachHang KH = null;
                for (int j = 0; j < DanhSachKH.Count; j++)
                {
                    if (DanhSachKH[j].MaKH == Lst_HD[i].MaKH)
                    {
                        KH = DanhSachKH[j];
                        break;
                    }
                }
                

                double ChietKhau = 0;
                if (ChietKhauTheoLoai.ContainsKey(KH.LoaiKH))
                {
                    ChietKhau = ChietKhauTheoLoai[KH.LoaiKH];
                }

                Tong = Tong * (1 - ChietKhau);

                int ViTri = -1;
                for (int k = 0; k < Lst_MaKH.Count; k++)
                {
                    if (Lst_MaKH[k] == KH.MaKH)
                    {
                        ViTri = k;
                        break;
                    }
                }

                if (ViTri == -1)
                {
                    Lst_MaKH.Add(KH.MaKH);
                    Lst_TongTien.Add(Tong);
                }
                else
                {
                    Lst_TongTien[ViTri] += Tong;
                }
            }

            if (Lst_MaKH.Count == 0)
            {
                return null;
            }
            int ViTriMax = 0;
            for (int i = 1; i < Lst_TongTien.Count; i++)
            {
                if (Lst_TongTien[i] > Lst_TongTien[ViTriMax])
                {
                    ViTriMax = i;
                }
            }

            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (DanhSachKH[i].MaKH == Lst_MaKH[ViTriMax])
                {
                    return DanhSachKH[i];
                }
            }

            return null;
        }
    }
}
