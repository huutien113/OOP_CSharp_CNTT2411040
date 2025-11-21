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
            //for (int i = 0; i < order.Items.Count; i++)
            //{
            //    Product SanPham = order.Items[i].Item;
            //    int SoLuong = order.Items[i].Quantity;

            //    Product SPTonKho = FindProductById(SanPham.ProductId);
            //    if (SPTonKho == null)
            //    {
            //        return false;
            //    }
            //    if (SPTonKho.StockQuantity < SoLuong)
            //    {
            //        return false;
            //    }
            //}
            

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

































        /*while (true)
            {
                bool KT_Huy = false;
                Console.WriteLine("Nhập lựa chọn (1) Thêm đơn hàng, (2) Hủy");
                string LuaChon = Console.ReadLine();

                if (LuaChon == "1")
                {
                    Console.WriteLine("Nhập tên khách hàng: ");
                    string HoTen = Console.ReadLine();
                    Order DonHang = new Order(id: shop.NewOrderID(), customer: HoTen, discount: 0);
                    for (int i = 0; i < shop.ThongTinKH(HoTen).Count; i++)
                    {
                        if (shop.ThongTinKH(HoTen).Count > 0)
                        {                            
                            break;
                        }
                        else if (shop.ThongTinKH(HoTen)[1] == HoTen)
                        {
                            DonHang = new Order(id: shop.ThongTinKH(HoTen)[0], customer: HoTen, discount: int.Parse(shop.ThongTinKH(HoTen)[2]));
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.Write("Nhập mã sản phẩm (Enter để dừng): ");
                        string ID = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(ID.ToUpper()))
                        {
                            break;
                        }

                        Product SP = shop.FindProductById(ID.ToUpper());
                        if (SP == null)
                        {
                            Console.WriteLine("Không tìm thấy sản phẩm, mời nhập lại.");
                            continue;
                        }

                        Console.Write("Nhập số lượng: ");
                        int SoLuong;
                        if (!int.TryParse(Console.ReadLine(), out SoLuong) || SoLuong <= 0)
                        {
                            Console.WriteLine("Số lượng không hợp lệ.");
                            continue;
                        }
                        if (!DonHang.AddItem(SP, SoLuong))
                        {
                            Console.WriteLine("Không đủ hàng cho sản phẩm này.");
                        }
                        else
                        {
                            Console.WriteLine("Đã thêm sản phẩm vào đơn.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Chọn thao tác tiếp theo:");
                        Console.WriteLine("(1) Thêm món khác, (2) Hoàn tất đơn này, (Nút bất kỳ) Hủy toàn bộ đơn");                        
                        Console.Write("Lựa chọn: ");
                        LuaChon = Console.ReadLine();

                        if (LuaChon == "1")
                        {
                            continue;
                        }
                        else if (LuaChon == "2")
                        {
                            break;
                        }
                        else
                        {
                            KT_Huy = true;

                            break;
                        }
                    }

                    if (KT_Huy == true || DonHang.Items.Count == 0)
                    {
                        if (KT_Huy == true && DonHang.Items.Count > 0)
                        {
                            for (int i = 0; i < DonHang.Items.Count; i++)
                            {
                                Product SP = shop.FindProductById(DonHang.Items[i].Item.ProductId);
                                if (SP != null)
                                {
                                    SP.IncreaseStock(DonHang.Items[i].Quantity);
                                }
                            }
                            Console.WriteLine("Đơn hàng đã bị hủy");
                        }
                        else
                        {
                            Console.WriteLine("Đơn hàng không có sản phẩm nào");
                        }
                    }
                    else
                    {
                        if (shop.PlaceOrder(DonHang))
                        {
                            Console.WriteLine("Đặt hàng thành công");
                        }
                        else
                        {
                            Console.WriteLine("Đặt hàng không thành công");
                        }
                    }
                }

                else if (LuaChon == "2")
                    break;
                
            }
            



            for (int i = 0; i < shop.Orders.Count; i++)
            {
                Console.WriteLine(shop.Orders[i].GetOrderDetail());
            }

            //Console.Write("Từ (dd/MM/yyyy): ");
            //DateTime from = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            //Console.Write("Đến (dd/MM/yyyy): ");
            //DateTime to = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            //Console.WriteLine($"Tổng doanh thu từ ngày... tới ....: {shop.CalculateRevenue(from, to)}");

            int Top = 3;
            shop.GetBestSellingProducts(Top);
            Console.WriteLine("Top những sản phẩm bán chạy:");
            for (int i = 0; i < Top; i++)
            {
                if (shop.GetBestSellingProducts(Top).Count >= Top)
                {
                    Console.WriteLine($"Top {i + 1} {shop.GetBestSellingProducts(Top)[i].GetInfo()}");
                }              
            }

            Console.WriteLine("Thống kê doanh thu theo loại SP:");
            Dictionary<string, double> ThongKe = shop.RevenueByCategory();
            for (int i = 0; i < ThongKe.Count; i++)
            {
                string key = ThongKe.ElementAt(i).Key;
                double value = ThongKe.ElementAt(i).Value;

                Console.WriteLine($"{key}: {value}");
            }

            Console.WriteLine("---------------------------");

            List<Order> Lst_DonHang = shop.GetOrdersByCustomerName("Nguyễn Văn Cường");
            Console.WriteLine("Đơn hàng khách hàng:");
            for (int i = 0; i < Lst_DonHang.Count; i++)
            {
                Console.WriteLine($"{Lst_DonHang[i].GetOrderDetail()}");
            }

            Console.WriteLine("---------------------------");


            int KtSL = 15;
            Console.WriteLine($"Những sản phẩm còn tồn kho với số lượng < {KtSL}");
            for (int i = 0; i < shop.CheckStock(KtSL).Count; i++)
            {
                Console.WriteLine(shop.CheckStock(KtSL)[i].GetInfo());
            }
        */
    }
}
