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
            int a = Math.Abs(Tu);
            int b = Math.Abs(Mau);

            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            Tu = Tu / a;
            Mau = Mau / a;

            if (mau < 0)
            {
                Tu = -Tu;
                Mau = -Mau;
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"{Tu}/{Mau}");
        }

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int t = (a.Tu * b.Mau) + (a.Mau * b.Tu);
            int m = a.Mau * b.Mau;
            return new PhanSo(t, m);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int t = (a.Tu * b.Mau) - (a.Mau * b.Tu);
            int m = a.Mau * b.Mau;
            return new PhanSo(t, m);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int t = (a.Tu * b.Tu);
            int m = (a.Mau * b.Mau);
            return new PhanSo(t, m);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.Tu == 0)
            {
                Console.WriteLine("Phân số ko hợp lệ");
                return null;
            }
            else
            {

                int t = (a.Tu * b.Mau);
                int m = (a.Mau * b.Tu);
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
