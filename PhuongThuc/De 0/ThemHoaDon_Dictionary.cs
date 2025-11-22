using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLyCuaHang
    {
        public bool ThemHoaDon_Dictionary(HoaDon hd)
        {
            Dictionary<string, KhachHang> Dict_KH = new Dictionary<string, KhachHang>();
            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (Dict_KH.ContainsKey(DanhSachKH[i].MaKH) == false)
                {
                    Dict_KH[DanhSachKH[i].MaKH] = DanhSachKH[i];
                }
            }

            if (Dict_KH.ContainsKey(hd.MaKH) == false)
            {
                return false;
            }

            Dictionary<int, SanPham> Dict_SP = new Dictionary<int, SanPham>();
            for (int i = 0; i < DanhSachSP.Count; i++)
            {
                if (Dict_SP.ContainsKey(DanhSachSP[i].MaSP) == false)
                {
                    Dict_SP[DanhSachSP[i].MaSP] = DanhSachSP[i];
                }
            }

            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                if (hd.ChiTiet[i].SoLuongBan <= 0)
                {
                    return false;
                }

                if (Dict_SP.ContainsKey(hd.ChiTiet[i].MaSP) == false)
                {
                    return false;
                }

                SanPham SP = Dict_SP[hd.ChiTiet[i].MaSP];

                if (SP.SoLuongTon < hd.ChiTiet[i].SoLuongBan || SP.GiaNhap * 1.1 > hd.ChiTiet[i].DonGiaBan)
                {
                    return false;
                }
            }

            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                if (Dict_SP.ContainsKey(hd.ChiTiet[i].MaSP))
                {
                    Dict_SP[hd.ChiTiet[i].MaSP].SoLuongTon -= hd.ChiTiet[i].SoLuongBan;
                }
            }

            DanhSachHD.Add(hd);
            return true;
        }
    }
}
