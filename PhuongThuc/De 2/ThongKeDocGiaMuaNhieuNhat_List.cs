using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLySach
    {
        public DocGia ThongKeDocGiaMuaNhieuNhat_List(int thang, int nam)
        {
            List<HoaDonMuaSach> Lst_HDMS = new List<HoaDonMuaSach>();
            for (int i = 0; i < DanhSachHDMS.Count; i++)
            {
                if (DanhSachHDMS[i].NgayMua.Month == thang && DanhSachHDMS[i].NgayMua.Year == nam)
                {
                    Lst_HDMS.Add(DanhSachHDMS[i]);
                }
            }
            if (Lst_HDMS.Count == 0)
                return null;

            List<string> Lst_MaDG = new List<string>();
            List<double> Lst_TongTien = new List<double>();

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
                
                if (DG == null)
                {
                    continue;
                }

                double ChietKhau = 0;
                if (ChietKhauTheoLoai.ContainsKey(DG.LoaiDG))
                {
                    ChietKhau = ChietKhauTheoLoai[DG.LoaiDG];
                }

                Tong = Tong * (1 - ChietKhau);

                int ViTri = -1;
                for (int k = 0; k < Lst_MaDG.Count; k++)
                {
                    if (Lst_MaDG[k] == DG.MaDG)
                    {
                        ViTri = k;
                        break;
                    }
                }

                if (ViTri == -1)
                {
                    Lst_MaDG.Add(DG.MaDG);
                    Lst_TongTien.Add(Tong);
                }
                else
                {
                    Lst_TongTien[ViTri] += Tong;
                }
            }

            if (Lst_MaDG.Count == 0)
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

            for (int i = 0; i < DanhSachDG.Count; i++)
            {
                if (DanhSachDG[i].MaDG == Lst_MaDG[ViTriMax])
                {
                    return DanhSachDG[i];
                }
            }

            return null;
        }
    }
}
