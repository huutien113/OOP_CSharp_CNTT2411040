using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    class CBVC
    {
        string hoTen;

        int namSinh;

        public string HoTen 
        {
            get
            {
                return hoTen;
            }
            set
            {
                hoTen = value;
            }
        }

        public int NamSinh
        {
            get
            {
                return namSinh;
            }
            set
            {
                namSinh = value;
            }
        }

        public virtual void GioiThieu()
        {
            Console.WriteLine($"{hoTen}\n{namSinh}");
        }

        public CBVC()
        { }
        public CBVC(string HoTen):this()
        {
            hoTen= HoTen;
        }
        public CBVC(string HoTen, int NamSinh):this(HoTen)
        {
            namSinh= NamSinh;
        }
    }
}
