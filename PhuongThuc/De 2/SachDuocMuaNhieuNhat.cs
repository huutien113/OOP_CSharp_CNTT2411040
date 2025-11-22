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
                return null;
            }

            List<int> Lst_MaSach = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < DanhSachHDMS.Count; i++)
            {
                for (int j = 0; j < DanhSachHDMS[i].ChiTiet.Count; j++)
                {
                    int MaSach = DanhSachHDMS[i].ChiTiet[j].MaSach;
                    int SoLuongBan = DanhSachHDMS[i].ChiTiet[j].SoLuong;
                    
                    int ViTri = -1;
                    for (int k = 0; k < Lst_MaSach.Count; k++)
                    {
                        if (Lst_MaSach[k] == MaSach)
                        {
                            ViTri = k;
                            break;
                        }
                    }

                    if (ViTri == -1)
                    {
                        Lst_MaSach.Add(MaSach);
                        Lst_SoLuongBan.Add(SoLuongBan);
                    }
                    else
                    {
                        Lst_SoLuongBan[ViTri] += SoLuongBan;
                    }
                }
            }
            if (Lst_MaSach.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < Lst_MaSach.Count - 1; i++)
            {
                for (int j = 0; j < Lst_MaSach.Count - i - 1; j++)
                {
                    if (Lst_SoLuongBan[j] < Lst_SoLuongBan[j+1])
                    { 
                        int TSLB = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = Lst_SoLuongBan[j+1];
                        Lst_SoLuongBan[j+1] = TSLB;

                        int TMaSach = Lst_MaSach[j];
                        Lst_MaSach[j] = Lst_MaSach[j+1];
                        Lst_MaSach[j+1] = TMaSach;
                    }
                }
            }

            List<int> Lst_SoLuongTop = new List<int>();
            for (int i = 0; i < Lst_SoLuongBan.Count; i++)
            {
                bool Kt = true;

                for (int j = 0; j < Lst_SoLuongTop.Count; j++)
                {
                    if (Lst_SoLuongBan[i] == Lst_SoLuongTop[j])
                    {
                        Kt = false;
                        break;
                    }
                }

                if (Kt == true)
                {
                    Lst_SoLuongTop.Add(Lst_SoLuongBan[i]);
                }

                if (Lst_SoLuongTop.Count >= topCount)
                {
                    break;
                }
            }

            int soLuongMin = Lst_SoLuongTop[Lst_SoLuongTop.Count - 1];
            for (int i = 0; i < Lst_SoLuongBan.Count; i++)
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
