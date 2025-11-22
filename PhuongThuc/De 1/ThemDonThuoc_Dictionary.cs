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
        public bool ThemDonThuoc_Dictionary(DonThuoc dt)
        {
            Dictionary<string, BenhNhan> Dict_BN = new Dictionary<string, BenhNhan>();
            for (int i = 0; i < DanhSachBN.Count; i++)
            {
                if (!Dict_BN.ContainsKey(DanhSachBN[i].MaBN))
                {
                    Dict_BN[DanhSachBN[i].MaBN] = DanhSachBN[i];
                }
            }

            if (!Dict_BN.ContainsKey(dt.MaBN))
            {
                return false;
            }

            Dictionary<int, Thuoc> Dict_Thuoc = new Dictionary<int, Thuoc>();
            for (int i = 0; i < DanhSachThuoc.Count; i++)
            {
                if (!Dict_Thuoc.ContainsKey(DanhSachThuoc[i].MaThuoc))
                {
                    Dict_Thuoc[DanhSachThuoc[i].MaThuoc] = DanhSachThuoc[i];
                }
            }

            for (int i = 0; i < dt.ChiTiet.Count; i++)
            {
                if (dt.ChiTiet[i].SoLuong <= 0)
                {
                    return false;
                }

                if (!Dict_Thuoc.ContainsKey(dt.ChiTiet[i].MaThuoc))
                {
                    return false;
                }

                Thuoc T = Dict_Thuoc[dt.ChiTiet[i].MaThuoc];

                if (T.SoLuongTon < dt.ChiTiet[i].SoLuong || T.GiaNhap * 1.1 > dt.ChiTiet[i].DonGia)
                {
                    return false;
                }
            }

            for (int i = 0; i < dt.ChiTiet.Count; i++)
            {
                if (Dict_Thuoc.ContainsKey(dt.ChiTiet[i].MaThuoc))
                {
                    Dict_Thuoc[dt.ChiTiet[i].MaThuoc].SoLuongTon -= dt.ChiTiet[i].SoLuong;
                }
            }

            DanhSachDT.Add(dt);
            return true;
        }
    }
}
