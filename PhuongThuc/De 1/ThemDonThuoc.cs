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
        public bool ThemDonThuoc(DonThuoc dt)
        {
            bool KTBN = false;

            for (int i = 0; i < DanhSachBN.Count; i++)
            {
                if (DanhSachBN[i].MaBN == dt.MaBN)
                {
                    KTBN = true;
                    break;
                }
            }

            if (KTBN == false)
            {
                return false;
            }

            for (int i = 0; i < dt.ChiTiet.Count; i++)
            {
                if (dt.ChiTiet[i].SoLuong <= 0)
                {
                    return false;
                }

                Thuoc T = null;

                for (int j = 0; j < DanhSachThuoc.Count; j++)
                {
                    if (dt.ChiTiet[i].MaThuoc == DanhSachThuoc[j].MaThuoc)
                    {
                        T = DanhSachThuoc[j];
                        break;
                    }
                }

                if (T == null || T.SoLuongTon < dt.ChiTiet[i].SoLuong || T.GiaNhap * 1.1 > dt.ChiTiet[i].DonGia)
                {
                    return false;
                }

            }

            for (int i = 0; i < dt.ChiTiet.Count; i++)
            {
                for (int j = 0; j < DanhSachThuoc.Count; j++)
                {
                    if (dt.ChiTiet[i].MaThuoc == DanhSachThuoc[j].MaThuoc)
                    {
                        DanhSachThuoc[j].SoLuongTon -= dt.ChiTiet[i].SoLuong;
                        break;
                    }
                }
            }

            DanhSachDT.Add(dt);
            return true;
        }
    }
}
