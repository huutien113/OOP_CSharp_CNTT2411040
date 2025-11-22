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
        public BenhNhan ThongKeBenhNhanMuaNhieuNhat(int thang, int nam)
        {
            List<DonThuoc> Lst_DT = new List<DonThuoc>();
            for (int i = 0; i < DanhSachDT.Count; i++)
            {
                if (DanhSachDT[i].NgayKe.Month == thang && DanhSachDT[i].NgayKe.Year == nam)
                {
                    Lst_DT.Add(DanhSachDT[i]);
                }
            }
            if (Lst_DT.Count <= 0)
            {
                return null;
            }

            Dictionary<string, double> Dict_Tong = new Dictionary<string, double>();
            
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

                Tong = Tong * (1- ChietKhau);

                if (Dict_Tong.ContainsKey(Lst_DT[i].MaBN))
                {
                    Dict_Tong[Lst_DT[i].MaBN] += Tong;
                }

                else
                {
                    Dict_Tong[Lst_DT[i].MaBN] = Tong;
                }
            }


            string MaBNMAX = null;
            double MaxTong = 0;
            List<string> Key = new List<string>();
            foreach (string k in Dict_Tong.Keys)
            {
                Key.Add(k);
            }
            for (int i = 0; i < Dict_Tong.Count; i++)
            {
                if (MaBNMAX == null || Dict_Tong[Key[i]] > MaxTong)
                {
                    MaBNMAX = Key[i];
                    MaxTong = Dict_Tong[Key[i]];
                }
            }

            for (int i = 0; i < DanhSachBN.Count; i++)
            {
                if (MaBNMAX == DanhSachBN[i].MaBN)
                {
                    return DanhSachBN[i];
                }
            }
            return null;
        }
    }
}
