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

            Dictionary<int, int> Dict_SoLuongBan = new Dictionary<int, int>();

            for (int i = 0; i < DanhSachDT.Count; i++)
            {
                for (int j = 0; j < DanhSachDT[i].ChiTiet.Count; j++)
                {
                    int maThuoc = DanhSachDT[i].ChiTiet[j].MaThuoc;
                    int soLuong = DanhSachDT[i].ChiTiet[j].SoLuong;

                    if (Dict_SoLuongBan.ContainsKey(maThuoc))
                    {
                        Dict_SoLuongBan[maThuoc] += soLuong;
                    }
                    else
                    {
                        Dict_SoLuongBan[maThuoc] = soLuong;
                    }
                }
            }

            if (Dict_SoLuongBan.Count == 0)
            {
                return null;
            }

            int maThuocMax = 0;
            int maxSoLuong = 0;
            List<int> Keys = Dict_SoLuongBan.Keys.ToList();

            for (int i = 0; i < Dict_SoLuongBan.Count; i++)
            {
                if (i == 0 || Dict_SoLuongBan[Keys[i]] > maxSoLuong)
                {
                    maThuocMax = Keys[i];
                    maxSoLuong = Dict_SoLuongBan[Keys[i]];
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
