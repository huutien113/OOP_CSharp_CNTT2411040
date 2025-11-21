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
            if (DanhSachSach.Count == 0 || DanhSachHDMS.Count == 0)
            {
                return null;
            }

            // Tính tổng số lượng bán cho từng sách
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

            // Sắp xếp theo số lượng bán giảm dần (bubble sort)
            for (int i = 0; i < Lst_MaSach.Count - 1; i++)
            {
                for (int j = i + 1; j < Lst_MaSach.Count; j++)
                {
                    if (Lst_SoLuongBan[i] < Lst_SoLuongBan[j])
                    {
                        // Swap số lượng bán
                        int tempSL = Lst_SoLuongBan[i];
                        Lst_SoLuongBan[i] = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = tempSL;

                        // Swap mã sách
                        int tempMa = Lst_MaSach[i];
                        Lst_MaSach[i] = Lst_MaSach[j];
                        Lst_MaSach[j] = tempMa;
                    }
                }
            }

            // Lấy số lượng bán cao nhất (tương tự Lst_Luong trong GetTopHighestPaid)
            List<int> Lst_SoLuong = new List<int>();
            for (int i = 0; i < Lst_MaSach.Count; i++)
            {
                bool Kt = true;
                
                for (int j = 0; j < Lst_SoLuong.Count; j++)
                {
                    if (Lst_SoLuongBan[i] == Lst_SoLuong[j])
                    {
                        Kt = false;
                        break;
                    }
                }
                
                if (Kt == true)
                {
                    Lst_SoLuong.Add(Lst_SoLuongBan[i]);
                }

                if (Lst_SoLuong.Count >= 1)
                {
                    break;
                }
            }

            int soLuongMax = Lst_SoLuong[Lst_SoLuong.Count - 1];

            // Trả về sách đầu tiên có số lượng bán >= soLuongMax
            for (int i = 0; i < Lst_MaSach.Count; i++)
            {
                if (Lst_SoLuongBan[i] >= soLuongMax)
                {
                    for (int j = 0; j < DanhSachSach.Count; j++)
                    {
                        if (DanhSachSach[j].MaSach == Lst_MaSach[i])
                        {
                            return DanhSachSach[j];
                        }
                    }
                }
            }

            return null;
        }
    }
}
