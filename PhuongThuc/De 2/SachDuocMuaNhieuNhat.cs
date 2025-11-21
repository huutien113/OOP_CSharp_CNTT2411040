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

            List<int> Lst_MaSach = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < DanhSachHDMS.Count; i++)
            {
                for (int j = 0; j < DanhSachHDMS[i].ChiTiet.Count; j++)
                {
                    int maSach = DanhSachHDMS[i].ChiTiet[j].MaSach;
                    int soLuong = DanhSachHDMS[i].ChiTiet[j].SoLuong;

                    int viTri = -1;
                    for (int k = 0; k < Lst_MaSach.Count; k++)
                    {
                        if (Lst_MaSach[k] == maSach)
                        {
                            viTri = k;
                            break;
                        }
                    }

                    if (viTri != -1)
                    {
                        Lst_SoLuongBan[viTri] += soLuong;
                    }
                    else
                    {
                        Lst_MaSach.Add(maSach);
                        Lst_SoLuongBan.Add(soLuong);
                    }
                }
            }

            if (Lst_MaSach.Count == 0)
            {
                return null;
            }

            int maSachMax = 0;
            int maxSoLuong = 0;

            for (int i = 0; i < Lst_MaSach.Count; i++)
            {
                if (i == 0 || Lst_SoLuongBan[i] > maxSoLuong)
                {
                    maSachMax = Lst_MaSach[i];
                    maxSoLuong = Lst_SoLuongBan[i];
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
