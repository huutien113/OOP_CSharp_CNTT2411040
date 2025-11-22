using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLyNhaThuoc
    {
        public List<Thuoc> ThuocBanChayNhat_Dictionary(int topCount)
        {
            List<Thuoc> Lst_Top = new List<Thuoc>();
            if (DanhSachThuoc.Count == 0 || topCount <= 0)
            {
                return null;
            }

            Dictionary<int, int> Dict_SoLuongBan = new Dictionary<int, int>();

            for (int i = 0; i < DanhSachDT.Count; i++)
            {
                for (int j = 0; j < DanhSachDT[i].ChiTiet.Count; j++)
                {
                    int MaThuoc = DanhSachDT[i].ChiTiet[j].MaThuoc;
                    int SoLuongBan = DanhSachDT[i].ChiTiet[j].SoLuong;

                    if (Dict_SoLuongBan.ContainsKey(MaThuoc))
                    {
                        Dict_SoLuongBan[MaThuoc] += SoLuongBan;
                    }
                    else
                    {
                        Dict_SoLuongBan[MaThuoc] = SoLuongBan;
                    }
                }
            }

            if (Dict_SoLuongBan.Count == 0)
            {
                return null;
            }

            List<int> Lst_MaThuoc = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            foreach (int MaThuoc in Dict_SoLuongBan.Keys)
            {
                Lst_MaThuoc.Add(MaThuoc);
                Lst_SoLuongBan.Add(Dict_SoLuongBan[MaThuoc]);
            }

            for (int i = 0; i < Lst_MaThuoc.Count - 1; i++)
            {
                for (int j = 0; j < Lst_MaThuoc.Count - i - 1; j++)
                {
                    if (Lst_SoLuongBan[j] < Lst_SoLuongBan[j+1])
                    { 
                        int TSLB = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = Lst_SoLuongBan[j+1];
                        Lst_SoLuongBan[j+1] = TSLB;

                        int TMaThuoc = Lst_MaThuoc[j];
                        Lst_MaThuoc[j] = Lst_MaThuoc[j+1];
                        Lst_MaThuoc[j+1] = TMaThuoc;
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
                    for (int j = 0; j < DanhSachThuoc.Count; j++)
                    {
                        if (DanhSachThuoc[j].MaThuoc == Lst_MaThuoc[i])
                        {
                            Lst_Top.Add(DanhSachThuoc[j]);
                            break;
                        }
                    }
                }
            }

            return Lst_Top;
        }
    }
}
