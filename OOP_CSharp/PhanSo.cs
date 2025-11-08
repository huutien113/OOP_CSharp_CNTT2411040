using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    class PhanSo
    {
        public int tu;
        public int mau;

        public int Tu { get => tu; set => tu = value; }
        public int Mau
        {
            get => mau;
            set
            {
                if (value > 0)
                    mau = value;
            }
        }

        public PhanSo(int tu = 1, int mau = 1)
        {
            this.tu = tu;
            this.mau = mau;
            RutGon();
        }


        public void RutGon()
        {
            int a = Math.Abs(tu);
            int b = Math.Abs(mau);

            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            tu = tu / a;
            mau = mau / a;

            if (mau < 0)
            {
                tu = -tu;
                mau = -mau;
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"{tu}/{mau}");
        }

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int t = (a.tu * b.mau) + (a.mau * b.tu);
            int m = a.mau * b.mau;
            return new PhanSo(t, m);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int t = (a.tu * b.mau) - (a.mau * b.tu);
            int m = a.mau * b.mau;
            return new PhanSo(t, m);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int t = (a.tu * b.tu);
            int m = (a.mau * b.mau);
            return new PhanSo(t, m);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.tu == 0)
            {
                Console.WriteLine("Phân số ko hợp lệ");
                return null;
            }
            else
            {

                int t = (a.tu * b.mau);
                int m = (a.mau * b.tu);
                return new PhanSo(t, m);
            }
        }

        public static bool operator == (PhanSo a, PhanSo b)
        {
            return a.Tu == b.Tu && a.Mau == b.Mau;
        }

        public static bool operator != (PhanSo a, PhanSo b)
        {
            return !(a == b);
        }

        public static bool operator > (PhanSo a, PhanSo b)
        {
            return (a.Tu * b.Mau > a.Mau * b.Tu); 
        }

        public static bool operator < (PhanSo a, PhanSo b)
        {
            return (a.Tu * b.Mau < a.Mau * b.Tu);
        }

        public static bool operator >= (PhanSo a, PhanSo b)
        {
            return (a.Tu * b.Mau >= a.Mau * b.Tu);
        }

        public static bool operator <= (PhanSo a, PhanSo b)
        {
            return (a.Tu * b.Mau <= a.Mau * b.Tu);
        }

        public static implicit operator PhanSo(int a)
        {
            return new PhanSo(a);
        }

        public static explicit operator double(PhanSo a)
        {
            return (double)a.Tu / a.Mau;
        }

    }
}
