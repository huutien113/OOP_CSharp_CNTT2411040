using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> nv = new List<NhanVien>();
            while (true)
            {
                Console.Write("Chọn loại nhân viên cần thêm (1: NV Biên chế; 2: NV Hợp đồng; 3: Thoát chương trình): ");
                string LuaChon = Console.ReadLine();
                if (LuaChon == "3")
                    break;
                while (true)
                {
                    if (LuaChon == "1")
                    {
                        Console.WriteLine("Bạn chọn thêm NV Biên chế");
                        NhanVienBienChe a = new NhanVienBienChe();
                        a.NhapThongTin();
                        nv.Add(a);
                        Console.Write("Thêm NV thành công! bấm 1 để thêm NV Biên chế khác hoặc bất kỳ nút nào để thoát: ");
                        string Thoat = Console.ReadLine();
                        if (Thoat != "1")
                            break;
                    }
                    else if (LuaChon == "2")
                    {
                        Console.WriteLine("Bạn chọn thêm NV Hợp đồng");
                        NhanVienHopDong a = new NhanVienHopDong();
                        a.NhapThongTin();
                        nv.Add(a);
                        Console.Write("Thêm NV thành công! bấm 1 để thêm NV Hợp đồng khác hoặc bất kỳ nút nào để thoát: ");
                        string Thoat = Console.ReadLine();
                        if (Thoat != "1")
                            break;
                    }
                }                                        
            }
            Console.WriteLine("Hello!");

            int max = 0;
            double TongLuong = 0;
            for (int i = 0; i < nv.Count; i++)
            {
                nv[i].HienThiThongTin();
                Console.Write($"Lương Tổng = {nv[i].TinhLuong()}\n");

                TongLuong = TongLuong + nv[i].TinhLuong();

                if  (nv[max].TinhLuong() < nv[i].TinhLuong())
                    max = i;

            }

            Console.WriteLine($"Tổng lương phải trả của công ty là: {TongLuong}");
            Console.WriteLine("----------------------------------------");
            Console.Write($"Nhân viên có lương cao nhất là: ");
            nv[max].HienThiThongTin();
            Console.WriteLine($"Lương = {nv[max].TinhLuong()}");
        }
    }
}
