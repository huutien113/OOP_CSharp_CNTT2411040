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
        public SanPham SanPhamBanChayNhat()
        {
            if (DanhSachHD.Count == 0)
            {
                return null;
            }

            Dictionary<int, int> Dict_SoLuongBan = new Dictionary<int, int>();

            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                for (int j = 0; j < DanhSachHD[i].ChiTiet.Count; j++)
                {
                    int maSP = DanhSachHD[i].ChiTiet[j].MaSP;
                    int soLuongBan = DanhSachHD[i].ChiTiet[j].SoLuongBan;

                    if (Dict_SoLuongBan.ContainsKey(maSP))
                    {
                        Dict_SoLuongBan[maSP] += soLuongBan;
                    }
                    else
                    {
                        Dict_SoLuongBan[maSP] = soLuongBan;
                    }
                }
            }

            if (Dict_SoLuongBan.Count == 0)
            {
                return null;
            }

            int maSPMax = 0;
            int maxSoLuong = 0;
            List<int> Keys = Dict_SoLuongBan.Keys.ToList();

            for (int i = 0; i < Dict_SoLuongBan.Count; i++)
            {
                if (i == 0 || Dict_SoLuongBan[Keys[i]] > maxSoLuong)
                {
                    maSPMax = Keys[i];
                    maxSoLuong = Dict_SoLuongBan[Keys[i]];
                }
            }

            for (int i = 0; i < DanhSachSP.Count; i++)
            {
                if (DanhSachSP[i].MaSP == maSPMax)
                {
                    return DanhSachSP[i];
                }
            }

            return null;
        }
    }
}
