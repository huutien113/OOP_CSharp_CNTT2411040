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
        public bool ThemHoaDon(HoaDon hd)
        {
            bool KTKH = false;

            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (DanhSachKH[i].MaKH == hd.MaKH)
                {
                    KTKH = true;
                    break;
                }
            }

            if (KTKH == false)
            {
                return false;
            }

            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                if (hd.ChiTiet[i].SoLuongBan <= 0)
                {
                    return false;
                }

                SanPham SP = null;

                for (int j = 0; j < DanhSachSP.Count; j++)
                {
                    if (hd.ChiTiet[i].MaSP == DanhSachSP[j].MaSP)
                    {
                        SP = DanhSachSP[j];
                        break;
                    }
                }

                if (SP == null || SP.SoLuongTon < hd.ChiTiet[i].SoLuongBan || SP.GiaNhap * 1.1 > hd.ChiTiet[i].DonGiaBan)
                {
                    return false;
                }

            }

            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                for (int j = 0; j < DanhSachSP.Count; j++)
                {
                    if (hd.ChiTiet[i].MaSP == DanhSachSP[j].MaSP)
                    {
                        DanhSachSP[j].SoLuongTon -= hd.ChiTiet[i].SoLuongBan;
                        break;
                    }
                }
            }

            DanhSachHD.Add(hd);
            return true;
        }
    }
}
