using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;

namespace OOP_CSharp
{
    class Company
    {
        public List<Employee> Employees = new List<Employee>();

        public void AddEmployee(Employee emp)
        {
            
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].EmployeeId == emp.EmployeeId)
                {
                    Console.WriteLine("ID Nhân viên đã tồn tại");
                    return;
                }
            }
            Employees.Add(emp);

        }
        public bool RemoveEmployee(string id)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].EmployeeId == id)
                {
                    Employees.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Employee FindEmployeeById(string id)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].EmployeeId == id)
                {
                    return Employees[i];
                }                                                             
            }
            return null;
        }

        public double CalculateTotalPayroll()
        {
            double Tong = 0;
            for (int i = 0; i < Employees.Count; i++)
            {
                Tong = Tong + Employees[i].CalculateSalary();
            }
            return Tong;
        }

        public List<Employee> GetEmployeesByDepartment(string dept)
        {
            List<Employee> lst_NV = new List<Employee>();

            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Department == dept)
                {
                    lst_NV.Add(Employees[i]);
                }
            }
            return lst_NV;

        }

        public Dictionary<string, int> CountEmployeesByType()
        {
            Dictionary<string, int> ThongKe = new Dictionary<string, int>()
            {
                { "Full time", 0 }, { "Part time", 0 }
            };

            for (int i = 0;i < Employees.Count;i++)
            {
                if (Employees[i] is FullTimeEmployee)
                {
                    ThongKe["Full time"]++;
                }
                else if (Employees[i] is PartTimeEmployee)
                {
                    ThongKe["Part time"]++;
                }
            }    
            return ThongKe;
        }
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

        public void SortEmployeesBySalaryDescending()
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                for (int j = 0; j < Employees.Count - i - 1; j++)
                {
                    if (Employees[j].CalculateSalary() < Employees[j + 1].CalculateSalary())
                    {
                        Employee temp = Employees[j];
                        Employees[j] = Employees[j + 1];
                        Employees[j + 1] = temp;
                    }
                }
            }
        }
           
        public int Count()
        {
            return Employees.Count;
        }
        public string HienThiTatCa()
        {
            string Full = "\n";
            for (int i = 0;i < Employees.Count;i++)
            {
                Full = Full + Employees[i].GetInfo() + "\n";
            }    
            return Full;
        }
    }
}
