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
        public Thuoc ThuocBanChayNhat()
        {
            if (DanhSachDT.Count == 0)
            {
                return null;
            }

            List<int> Lst_MaThuoc = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < DanhSachDT.Count; i++)
            {
                for (int j = 0; j < DanhSachDT[i].ChiTiet.Count; j++)
                {
                    int maThuoc = DanhSachDT[i].ChiTiet[j].MaThuoc;
                    int soLuong = DanhSachDT[i].ChiTiet[j].SoLuong;

                    int viTri = -1;
                    for (int k = 0; k < Lst_MaThuoc.Count; k++)
                    {
                        if (Lst_MaThuoc[k] == maThuoc)
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
                        Lst_MaThuoc.Add(maThuoc);
                        Lst_SoLuongBan.Add(soLuong);
                    }
                }
            }

            if (Lst_MaThuoc.Count == 0)
            {
                return null;
            }

            int maThuocMax = 0;
            int maxSoLuong = 0;

            for (int i = 0; i < Lst_MaThuoc.Count; i++)
            {
                if (i == 0 || Lst_SoLuongBan[i] > maxSoLuong)
                {
                    maThuocMax = Lst_MaThuoc[i];
                    maxSoLuong = Lst_SoLuongBan[i];
                }
            }

            for (int i = 0; i < DanhSachThuoc.Count; i++)
            {
                if (DanhSachThuoc[i].MaThuoc == maThuocMax)
                {
                    return DanhSachThuoc[i];
                }
            }

            return null;
        }
    }
}
