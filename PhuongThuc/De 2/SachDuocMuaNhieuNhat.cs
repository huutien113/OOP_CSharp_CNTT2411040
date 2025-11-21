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
        public Sach SachDuocMuaNhieuNhat()
        {
            if (DanhSachHDMS.Count == 0)
            {
                return null;
            }

            Dictionary<int, int> Dict_SoLuongBan = new Dictionary<int, int>();

            for (int i = 0; i < DanhSachHDMS.Count; i++)
            {
                for (int j = 0; j < DanhSachHDMS[i].ChiTiet.Count; j++)
                {
                    int maSach = DanhSachHDMS[i].ChiTiet[j].MaSach;
                    int soLuong = DanhSachHDMS[i].ChiTiet[j].SoLuong;

                    if (Dict_SoLuongBan.ContainsKey(maSach))
                    {
                        Dict_SoLuongBan[maSach] += soLuong;
                    }
                    else
                    {
                        Dict_SoLuongBan[maSach] = soLuong;
                    }
                }
            }

            if (Dict_SoLuongBan.Count == 0)
            {
                return null;
            }

            int maSachMax = 0;
            int maxSoLuong = 0;
            List<int> Keys = Dict_SoLuongBan.Keys.ToList();

            for (int i = 0; i < Dict_SoLuongBan.Count; i++)
            {
                if (i == 0 || Dict_SoLuongBan[Keys[i]] > maxSoLuong)
                {
                    maSachMax = Keys[i];
                    maxSoLuong = Dict_SoLuongBan[Keys[i]];
                }
            }

            for (int i = 0; i < DanhSachSach.Count; i++)
            {
                if (DanhSachSach[i].MaSach == maSachMax)
                {
                    return DanhSachSach[i];
                }
            }

            return null;
        }
    }
}
