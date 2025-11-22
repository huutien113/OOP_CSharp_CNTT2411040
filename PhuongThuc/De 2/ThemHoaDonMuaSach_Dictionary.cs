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
        public bool ThemHoaDonMuaSach_Dictionary(HoaDonMuaSach hdms)
        {
            Dictionary<string, DocGia> Dict_DG = new Dictionary<string, DocGia>();
            for (int i = 0; i < DanhSachDG.Count; i++)
            {
                if (!Dict_DG.ContainsKey(DanhSachDG[i].MaDG))
                {
                    Dict_DG[DanhSachDG[i].MaDG] = DanhSachDG[i];
                }
            }

            if (!Dict_DG.ContainsKey(hdms.MaDG))
            {
                return false;
            }

            Dictionary<int, Sach> Dict_Sach = new Dictionary<int, Sach>();
            for (int i = 0; i < DanhSachSach.Count; i++)
            {
                if (!Dict_Sach.ContainsKey(DanhSachSach[i].MaSach))
                {
                    Dict_Sach[DanhSachSach[i].MaSach] = DanhSachSach[i];
                }
            }

            for (int i = 0; i < hdms.ChiTiet.Count; i++)
            {
                if (hdms.ChiTiet[i].SoLuong <= 0)
                {
                    return false;
                }

                if (!Dict_Sach.ContainsKey(hdms.ChiTiet[i].MaSach))
                {
                    return false;
                }

                Sach S = Dict_Sach[hdms.ChiTiet[i].MaSach];

                if (S.SoLuongTon < hdms.ChiTiet[i].SoLuong || S.GiaNhap * 1.1 > hdms.ChiTiet[i].DonGia)
                {
                    return false;
                }
            }

            for (int i = 0; i < hdms.ChiTiet.Count; i++)
            {
                if (Dict_Sach.ContainsKey(hdms.ChiTiet[i].MaSach))
                {
                    Dict_Sach[hdms.ChiTiet[i].MaSach].SoLuongTon -= hdms.ChiTiet[i].SoLuong;
                }
            }

            DanhSachHDMS.Add(hdms);
            return true;
        }
    }
}
