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
        public KhachHang ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
        {
            List<HoaDon> Lst_HD = new List<HoaDon>();
            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                if (DanhSachHD[i].NgayLap.Month == thang && DanhSachHD[i].NgayLap.Year == nam)
                {
                    Lst_HD.Add(DanhSachHD[i]);
                }
            }
            if (Lst_HD.Count <= 0)
            {
                return null;
            }

            Dictionary<string, double> Dict_Tong = new Dictionary<string, double>();
            
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

                if (KH != null)
                {
                    double ChietKhau = 0;
                    if (ChietKhauTheoLoai.ContainsKey(KH.LoaiKH))
                    {
                        ChietKhau = ChietKhauTheoLoai[KH.LoaiKH];
                    }

                    Tong = Tong * (1- ChietKhau);

                    if (Dict_Tong.ContainsKey(Lst_HD[i].MaKH))
                    {
                        Dict_Tong[Lst_HD[i].MaKH] += Tong;
                    }

                    else
                    {
                        Dict_Tong[Lst_HD[i].MaKH] = Tong;
                    }
                }
            }


            string MaKHMAX = null;
            double MaxTong = 0;
            List<string> Key = Dict_Tong.Keys.ToList();
            for (int i = 0; i < Dict_Tong.Count; i++)
            {
                if (MaKHMAX == null || Dict_Tong[Key[i]] > MaxTong)
                {
                    MaKHMAX = Key[i];
                    MaxTong = Dict_Tong[Key[i]];
                }
            }

            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (MaKHMAX == DanhSachKH[i].MaKH)
                {
                    return DanhSachKH[i];
                }
            }
            return null;
        }
    }
}
