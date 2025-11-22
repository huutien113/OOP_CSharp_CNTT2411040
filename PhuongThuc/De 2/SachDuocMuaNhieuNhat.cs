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
        public List<Sach> SachDuocMuaNhieuNhat(int topCount)
        {
            List<Sach> Lst_Top = new List<Sach>();
            if (DanhSachSach.Count == 0 || topCount <= 0)
            {
                return Lst_Top;
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
                return Lst_Top;
            }

            // Sắp xếp theo số lượng bán giảm dần (bubble sort)
            for (int i = 0; i < Lst_MaSach.Count - 1; i++)
            {
                for (int j = 0; j < Lst_MaSach.Count - i - 1; j++)
                {
                    if (Lst_SoLuongBan[j] < Lst_SoLuongBan[j+1])
                    { 
                        int TSLB = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = Lst_SoLuongBan[j+1];
                        Lst_SoLuongBan[j+1] = TSLB;
            
                        int TMAS = Lst_MaSach[j];
                        Lst_MaSach[j] = Lst_MaSach[j+1];
                        Lst_MaSach[j+1] = TMAS;
                    }
                }
            }

            // Lấy top N số lượng bán cao nhất (tương tự Lst_Luong trong GetTopHighestPaid)
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

                if (Lst_SoLuong.Count >= topCount)
                {
                    break;
                }
            }

            int soLuongMin = Lst_SoLuong[Lst_SoLuong.Count - 1];

            // Trả về tất cả sách có số lượng bán >= soLuongMin
            for (int i = 0; i < Lst_MaSach.Count; i++)
            {
                if (Lst_SoLuongBan[i] >= soLuongMin)
                {
                    for (int j = 0; j < DanhSachSach.Count; j++)
                    {
                        if (DanhSachSach[j].MaSach == Lst_MaSach[i])
                        {
                            Lst_Top.Add(DanhSachSach[j]);
                            break;
                        }
                    }
                }
            }

            return Lst_Top;
        }
    }
}
