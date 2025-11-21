using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLySach
    {
        public DocGia ThongKeDocGiaMuaNhieuNhat(int thang, int nam)
        {
            List<HoaDonMuaSach> Lst_HDMS = new List<HoaDonMuaSach>();
            for (int i = 0; i < DanhSachHDMS.Count; i++)
            {
                if (DanhSachHDMS[i].NgayMua.Month == thang && DanhSachHDMS[i].NgayMua.Year == nam)
                {
                    Lst_HDMS.Add(DanhSachHDMS[i]);
                }
            }
            if (Lst_HDMS.Count <= 0)
            {
                return null;
            }

            Dictionary<string, double> Dict_Tong = new Dictionary<string, double>();
            
            for (int i = 0; i < Lst_HDMS.Count; i++)
            {
                double Tong = 0;
                for (int j = 0; j < Lst_HDMS[i].ChiTiet.Count; j++)
                {
                    Tong += Lst_HDMS[i].ChiTiet[j].SoLuong * Lst_HDMS[i].ChiTiet[j].DonGia;
                }

                DocGia DG = null;
                for (int j = 0; j < DanhSachDG.Count; j++)
                {
                    if (DanhSachDG[j].MaDG == Lst_HDMS[i].MaDG)
                    {
                        DG = DanhSachDG[j];
                        break;
                    }
                }

                if (DG != null)
                {
                    double ChietKhau = 0;
                    if (ChietKhauTheoLoai.ContainsKey(DG.LoaiDG))
                    {
                        ChietKhau = ChietKhauTheoLoai[DG.LoaiDG];
                    }

                    Tong = Tong * (1- ChietKhau);

                    if (Dict_Tong.ContainsKey(Lst_HDMS[i].MaDG))
                    {
                        Dict_Tong[Lst_HDMS[i].MaDG] += Tong;
                    }

                    else
                    {
                        Dict_Tong[Lst_HDMS[i].MaDG] = Tong;
                    }
                }
            }


            string MaDGMAX = null;
            double MaxTong = 0;
            List<string> Key = Dict_Tong.Keys.ToList();
            for (int i = 0; i < Dict_Tong.Count; i++)
            {
                if (MaDGMAX == null || Dict_Tong[Key[i]] > MaxTong)
                {
                    MaDGMAX = Key[i];
                    MaxTong = Dict_Tong[Key[i]];
                }
            }

            for (int i = 0; i < DanhSachDG.Count; i++)
            {
                if (MaDGMAX == DanhSachDG[i].MaDG)
                {
                    return DanhSachDG[i];
                }
            }
            return null;
        }
    }
}
