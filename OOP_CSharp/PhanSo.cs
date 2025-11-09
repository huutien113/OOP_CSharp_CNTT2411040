using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace OOP_CSharp
{
    class PhanSo
    {
        int tu;
        int mau;

        public int Tu { get => tu; set => tu = value; }
        public int Mau 
        { 
            get => mau; 
            set
            {
                if (value != 0)
                {
                    mau = value;
                }
                else
                {
                    throw new ZeroException();
                }
            }
        }

        public PhanSo(int tu = 0, int mau = 1)
        {
            this.tu = tu;
            this.mau = mau;
            Rutgon();
        }

        public void Rutgon()
        {
            int a = Math.Abs(Tu);
            int b = Math.Abs(Mau);

            while (b != 0)
            {
                int c = a % b;
                a = b;
                b = c;
            }

            Tu = Tu / a;
            Mau = Mau / a;

            if (Mau < 0)
            {
                Tu = -Tu;
                Mau = -Mau;
            }
        }

        public string HienThi()
        {
            return $"{Tu}/{Mau}";
        }

        public static PhanSo operator + (PhanSo a, PhanSo b)
        {
            int TS=a.Tu*b.Mau + a.Mau * b.Tu;
            int MS = a.Mau * b.Mau;
            return new PhanSo(TS, MS);
        }

        public static PhanSo operator - (PhanSo a, PhanSo b)
        {
            int TS = a.Tu * b.Mau - a.Mau * b.Tu;
            int MS = a.Mau * b.Mau;
            return new PhanSo(TS, MS);
        }

        public static PhanSo operator * (PhanSo a, PhanSo b)
        {
            int TS = a.Tu * b.Tu;
            int MS = a.Mau * b.Mau;
            return new PhanSo(TS, MS);
        }

        public static PhanSo operator / (PhanSo a, PhanSo b)
        {
            int TS = a.Tu * b.Mau;
            int MS = a.Mau * b.Tu;
            return new PhanSo(TS, MS);
        }

        public static bool operator == (PhanSo a, PhanSo b)
        {
            return (a.Tu == b.Tu) && (a.Mau == b.Mau);
        }

        public static bool operator != (PhanSo a, PhanSo b)
        {
            return !(a == b);
        }

        public static bool operator > (PhanSo a, PhanSo b)
        {
            return a.Tu * b.Mau > a.Mau * b.Tu;
        }

        public static bool operator < (PhanSo a, PhanSo b)
        {
            return !(a > b);
        }

        public static bool operator >= (PhanSo a, PhanSo b)
        {
            return a.Tu * b.Mau >= a.Mau * b.Tu;
        }

        public static bool operator <= (PhanSo a, PhanSo b)
        {
            return a.Tu * b.Mau <= a.Mau * b.Tu;
        }

        public static implicit operator PhanSo(int a)
        {
            return new PhanSo(a);
        }

        public static implicit operator double(PhanSo a)
        {
            return (double)a.Tu / a.Mau;
        }

        public static explicit operator int(PhanSo a)
        {
            return (int)a.Tu / a.Mau;
        }
    }
}
