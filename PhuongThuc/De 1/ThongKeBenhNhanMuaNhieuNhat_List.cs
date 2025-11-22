using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLyNhaThuoc
    {
        public BenhNhan ThongKeBenhNhanMuaNhieuNhat_List(int thang, int nam)
        {
            List<DonThuoc> Lst_DT = new List<DonThuoc>();
            for (int i = 0; i < DanhSachDT.Count; i++)
            {
                if (DanhSachDT[i].NgayKe.Month == thang && DanhSachDT[i].NgayKe.Year == nam)
                {
                    Lst_DT.Add(DanhSachDT[i]);
                }
            }
            if (Lst_DT.Count == 0)
                return null;

            List<string> Lst_MaBN = new List<string>();
            List<double> Lst_TongTien = new List<double>();

            for (int i = 0; i < Lst_DT.Count; i++)
            {
                double Tong = 0;
                for (int j = 0; j < Lst_DT[i].ChiTiet.Count; j++)
                {
                    Tong += Lst_DT[i].ChiTiet[j].SoLuong * Lst_DT[i].ChiTiet[j].DonGia;
                }

                BenhNhan BN = null;
                for (int j = 0; j < DanhSachBN.Count; j++)
                {
                    if (DanhSachBN[j].MaBN == Lst_DT[i].MaBN)
                    {
                        BN = DanhSachBN[j];
                        break;
                    }
                }
                

                double ChietKhau = 0;
                if (ChietKhauTheoLoai.ContainsKey(BN.LoaiBN))
                {
                    ChietKhau = ChietKhauTheoLoai[BN.LoaiBN];
                }

                Tong = Tong * (1 - ChietKhau);

                int ViTri = -1;
                for (int k = 0; k < Lst_MaBN.Count; k++)
                {
                    if (Lst_MaBN[k] == BN.MaBN)
                    {
                        ViTri = k;
                        break;
                    }
                }

                if (ViTri == -1)
                {
                    Lst_MaBN.Add(BN.MaBN);
                    Lst_TongTien.Add(Tong);
                }
                else
                {
                    Lst_TongTien[ViTri] += Tong;
                }
            }

            if (Lst_MaBN.Count == 0)
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

            for (int i = 0; i < DanhSachBN.Count; i++)
            {
                if (DanhSachBN[i].MaBN == Lst_MaBN[ViTriMax])
                {
                    return DanhSachBN[i];
                }
            }

            return null;
        }
    }
}
