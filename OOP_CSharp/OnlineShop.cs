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
                    Products[i].IncreaseStock(sp.StockQuantity);
                    return;
                }
            }
            Products.Add(sp);
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

        public bool PlaceOrder(Order order)
        {
            if (order == null || order.Items.Count == 0)
                return false;
            
            // Lưu ý: Tồn kho đã được kiểm tra và giảm trong Order.AddItem()
            // PlaceOrder() chỉ là bước cuối để xác nhận và lưu đơn hàng
            Orders.Add(order);
            return true;
        }

        public Order FindOrderById(string id)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderId == id)
                {
                    return Orders[i];
                }
            }
            return null;
        }

        public double CalculateRevenue(DateTime from, DateTime to)
        {
            double Tong = 0;
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderDate >= from && Orders[i].OrderDate <= to)
                {
                    Tong += Orders[i].CalculateTotal();
                }
            }
            return Tong;
        }

        public List<Product> GetBestSellingProducts(int topCount)
        {
            List<Product> Lst_Top = new List<Product>();
            Dictionary<string, int> ThongKe = new Dictionary<string, int>();

            if (Orders.Count < topCount)
            {
                return Lst_Top;
            }
            for (int i = 0; i < Orders.Count; i++)
            {
                for (int j = 0; j < Orders[i].Items.Count; j++)
                {
                    string ID = Orders[i].Items[j].Item.ProductId;
                    int SoLuongBan = Orders[i].Items[j].Quantity;

                    if (ThongKe.ContainsKey(ID))
                    {
                        ThongKe[ID] += SoLuongBan;
                    }
                    else
                    {
                        ThongKe[ID] = SoLuongBan;
                    }
                }
            }

            List<string> Lst_ID = new List<string>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < Products.Count; i++)
            {
                string ID = Products[i].ProductId;
                if (ThongKe.ContainsKey(ID))
                {
                    Lst_ID.Add(ID);
                    Lst_SoLuongBan.Add(ThongKe[ID]);
                }
            }

            for (int i = 0; i < Lst_SoLuongBan.Count; i++)
            {
                for (int j = 0; j < Lst_SoLuongBan.Count - i - 1; j++)
                {
                    if (Lst_SoLuongBan[j] < Lst_SoLuongBan[j + 1])
                    {
                        int temp = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = Lst_SoLuongBan[j + 1];
                        Lst_SoLuongBan[j + 1] = temp;

                        string tempID = Lst_ID[j];
                        Lst_ID[j] = Lst_ID[j + 1];
                        Lst_ID[j+1] = tempID;
                    }
                }
            }

            for (int i = 0; i < Lst_ID.Count && i < topCount; i++)
            {
                Product SanPham = FindProductById(Lst_ID[i]);
                if (SanPham != null)
                {
                    Lst_Top.Add(SanPham);
                }
            }

            return Lst_Top;
        }


        public Dictionary<string, double> RevenueByCategory()
        {
            Dictionary<string, double> ThongKe = new Dictionary<string, double>()
            {
                { "Laptop", 0 }, { "Smartphone", 0 }
            };

            for (int i = 0; i < Orders.Count; i++)
            {
                for (int j = 0; j < Orders[i].Items.Count; j++)
                {
                    if (Orders[i].Items[j].Item is Laptop)
                    {
                        ThongKe["Laptop"] += Orders[i].Items[j].GetSubTotal();
                    }
                    else if (Orders[i].Items[j].Item is Smartphone)
                    {
                        ThongKe["Smartphone"] += Orders[i].Items[j].GetSubTotal();
                    }
                }
            }
            return ThongKe;
        }

        public List<Order> GetOrdersByCustomerName(string name)
        {
            List <Order> Lst_DonHang = new List<Order>();
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].CustomerName == name)
                {
                    Lst_DonHang.Add(Orders[i]);
                }
            }
            return Lst_DonHang;
        }

        public List<string> ThongTinKH(string name)
        {
            List<string> Lst_Info = new List<string>();
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].CustomerName == name)
                {
                    Lst_Info.Add(Orders[i].OrderId);
                    Lst_Info.Add(Orders[i].CustomerName);
                    Lst_Info.Add(Orders[i].Discount.ToString());
                    break;
                }
            }
            return Lst_Info;
        }

        public string NewOrderID()
        {
            int MaDH = Orders.Count;
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders.Count <= 0)
                {
                    return "DH001";
                }
            }
            return $"DH00{MaDH + 1}";
        }

        public List<Product> CheckStock(int SoLuong)
        {
            List <Product> Lst_SanPham = new List<Product>();
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].StockQuantity < SoLuong)
                {
                    Lst_SanPham.Add(Products[i]);
                }
            }
            return Lst_SanPham;
        }

    }
}
