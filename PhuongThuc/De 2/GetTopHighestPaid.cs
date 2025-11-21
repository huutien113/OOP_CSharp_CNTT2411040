using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;

namespace OOP_CSharp
{
    partial class Company
    {
        public List<Employee> GetTopHighestPaid(int topCount)
        {
            List<Employee> Lst_Top = new List<Employee>();
            if (Employees.Count == 0 || topCount <= 0)
            {
                return Lst_Top;
            }

            List <double> Lst_Luong = new List<double>();
            SortEmployeesBySalaryDescending();
            for (int i = 0; i < Employees.Count; i++)
            {
                bool Kt = true;
                               
                for (int j = 0; j < Lst_Luong.Count; j++)
                {
                    if (Employees[i].CalculateSalary() == Lst_Luong[j])
                    {
                        Kt = false;
                        break;
                    }
                }
                
                if (Kt == true)
                {
                    Lst_Luong.Add(Employees[i].CalculateSalary());
                }

                if (Lst_Luong.Count >= topCount)
                {
                    break;
                }
            }    
            double LuongMin = Lst_Luong[Lst_Luong.Count-1];
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].CalculateSalary() >= LuongMin)
                {
                    Lst_Top.Add(Employees[i]);
                }
            }
            return Lst_Top;
        }
    }
}
