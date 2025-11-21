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

            List<int> Lst_MaSP = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                for (int j = 0; j < DanhSachHD[i].ChiTiet.Count; j++)
                {
                    int maSP = DanhSachHD[i].ChiTiet[j].MaSP;
                    int soLuongBan = DanhSachHD[i].ChiTiet[j].SoLuongBan;

                    int viTri = -1;
                    for (int k = 0; k < Lst_MaSP.Count; k++)
                    {
                        if (Lst_MaSP[k] == maSP)
                        {
                            viTri = k;
                            break;
                        }
                    }

                    if (viTri != -1)
                    {
                        Lst_SoLuongBan[viTri] += soLuongBan;
                    }
                    else
                    {
                        Lst_MaSP.Add(maSP);
                        Lst_SoLuongBan.Add(soLuongBan);
                    }
                }
            }

            if (Lst_MaSP.Count == 0)
            {
                return null;
            }

            int maSPMax = 0;
            int maxSoLuong = 0;

            for (int i = 0; i < Lst_MaSP.Count; i++)
            {
                if (i == 0 || Lst_SoLuongBan[i] > maxSoLuong)
                {
                    maSPMax = Lst_MaSP[i];
                    maxSoLuong = Lst_SoLuongBan[i];
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
