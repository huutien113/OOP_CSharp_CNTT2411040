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
        public bool ThemHoaDonMuaSach(HoaDonMuaSach hdms)
        {
            bool KTDG = false;

            for (int i = 0; i < DanhSachDG.Count; i++)
            {
                if (DanhSachDG[i].MaDG == hdms.MaDG)
                {
                    KTDG = true;
                    break;
                }
            }

            if (KTDG == false)
            {
                return false;
            }

            for (int i = 0; i < hdms.ChiTiet.Count; i++)
            {
                if (hdms.ChiTiet[i].SoLuong <= 0)
                {
                    return false;
                }

                Sach S = null;

                for (int j = 0; j < DanhSachSach.Count; j++)
                {
                    if (hdms.ChiTiet[i].MaSach == DanhSachSach[j].MaSach)
                    {
                        S = DanhSachSach[j];
                        break;
                    }
                }

                if (S == null || S.SoLuongTon < hdms.ChiTiet[i].SoLuong || S.GiaNhap * 1.1 > hdms.ChiTiet[i].DonGia)
                {
                    return false;
                }

            }

            for (int i = 0; i < hdms.ChiTiet.Count; i++)
            {
                for (int j = 0; j < DanhSachSach.Count; j++)
                {
                    if (hdms.ChiTiet[i].MaSach == DanhSachSach[j].MaSach)
                    {
                        DanhSachSach[j].SoLuongTon -= hdms.ChiTiet[i].SoLuong;
                        break;
                    }
                }
            }

            DanhSachHDMS.Add(hdms);
            return true;
        }
    }
}
