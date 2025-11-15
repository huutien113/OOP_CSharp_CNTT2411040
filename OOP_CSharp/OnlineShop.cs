using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;

namespace OOP_CSharp
{
    class OnlineShop
    {
        public List<Product> Products = new List<Product>();
        public List<Order> Orders = new List<Order>();

        public void AddProduct(Product sp)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductId == sp.ProductId)
                {
                    Console.WriteLine("Mã sản phẩm đã tồn tại");
                    return;
                }
            }
            Products.Add(sp);
        }

        public bool RemoveProduct(string id)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductId == id)
                {
                    Products.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Product FindProductById(string id)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductId == id)
                {
                    return Products[i];
                }
            }
            return null;
        }

        public List<Product> GetProductsByCategory(string LoaiSP)
        {
            List<Product> Lst_SP = new List<Product>();
            if (LoaiSP.ToUpper() == "LAPTOP")
            {
                for (int i = 0; i < Products.Count - 1; i++)
                {
                    if (Products[i] is Laptop)
                    {
                        Lst_SP.Add(Products[i]);
                    }
                }
                return Lst_SP;
            }
            else if (LoaiSP.ToUpper() == "SMARTPHONE")
            {
                for (int i = 0; i < Products.Count - 1; i++)
                {
                    if (Products[i] is Smartphone)
                    {
                        Lst_SP.Add(Products[i]);
                    }
                }
                return Lst_SP;
            }
            return Lst_SP;
        }

        public void SortProductsByPriceDescending()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < Products.Count - i - 1; j++)
                {
                    if (Products[j].Price < Products[j + 1].Price)
                    {
                        Product temp = Products[j];
                        Products[j] = Products[j + 1];
                        Products[j + 1] = temp;
                    }
                }
            }
        }

        public Dictionary<string, int> CountProductsByCategory()
        {
            Dictionary<string, int> ThongKe = new Dictionary<string, int>()
            {
                { "Laptop", 0 }, { "Smartphone", 0 }
            };

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i] is Laptop)
                {
                    ThongKe["Laptop"]++;
                }
                else if (Products[i] is Smartphone)
                {
                    ThongKe["Smartphone"]++;
                }
            }
            return ThongKe;
        }

        public List<Product> GetTopHighestPrice(int topCount)
        {
            List<Product> Top = new List<Product>();
            SortProductsByPriceDescending();

            for (int i = 0;i < topCount;i++)
            {
                Top.Add(Products[i]);
            }    
            return Top;
        }

        public double CalculateTotalInventoryValue()
        {
            double Tong = 0;

            for (int i = 0; i < Products.Count; i++)
            {
                Tong = Tong + Products[i].Price * Products[i].StockQuantity;
            }
            return Tong;
        }


        public bool PlaceOrder(Order order)
        {
            if (order == null || order.Items.Count == 0)
                return false;

            for (int i = 0; i < order.Items.Count; i++)
            {
                Product SanPham = order.Items[i].Item;
                int SoLuong = order.Items[i].Quantity;

                Product SPTonKho = FindProductById(SanPham.ProductId);
                if (SPTonKho == null)
                {
                    return false;
                }
                if (SPTonKho.StockQuantity < SoLuong)
                {
                    return false;
                }    
            }

            for (int i = 0; i < order.Items.Count; i++)
            {
                Product SanPham = order.Items[i].Item;
                int SoLuong = order.Items[i].Quantity;

                Product SPTonKho = FindProductById(SanPham.ProductId);
                SPTonKho.ReduceStock(SoLuong);
            }

            Orders.Add(order);
            return true;
        }

        public double CalculateRevenue(DateTime from, DateTime to)
        {
            double Tong = 0;
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderDate >= from && Orders[i].OrderDate <= to)
                {
                    Tong = Tong + Orders[i].CalculateTotal();
                }
            }
            return Tong;
        }

        //public List<Product> GetBestSellingProducts(int topCount)
        //{
        //    List<Product> Lst_Top = new List<Product>();

        //}
    }
}
