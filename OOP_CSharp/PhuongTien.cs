using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    abstract class PhuongTien
    {
        string bienSoXe, tenPhuongTien;
        int namSanXuat;

        public string BienSoXe { get => bienSoXe; set => bienSoXe = value; }
        public string TenPhuongTien { get => tenPhuongTien; set => tenPhuongTien = value; }
        public int NamSanXuat { get => namSanXuat; set => namSanXuat = value; }

        public virtual void Nhap()
        {
            Console.Write("");
        }
    }
}
