using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookStore.ConsoleUI.Menus
{
    public class OrderMenu
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderMenu(IServiceProvider serviceProvider)
        {
            _orderService = serviceProvider.GetRequiredService<IOrderService>();
            _orderItemService = serviceProvider.GetRequiredService<IOrderItemService>();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== ORDER MENU =====");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Get All");
                Console.WriteLine("5. Get By Id");
                Console.WriteLine("6. Manage Order Items");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": Add(); break;
                        case "2": Update(); break;
                        case "3": Delete(); break;
                        case "4": GetAll(); break;
                        case "5": GetById(); break;
                        case "6": ManageOrderItems(); break;
                        case "0": return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Xeta: {ex.Message}");
                    var inner = ex.InnerException;
                    while (inner != null)
                    {
                        Console.WriteLine($"  -> {inner.Message}");
                        inner = inner.InnerException;
                    }
                }

                Console.WriteLine("\nDavam etmek üçün istenilen düymeye basın...");
                Console.ReadKey();
            }
        }

        

        private void Add()
        {
            Console.Write("Musteri Id: ");
            int.TryParse(Console.ReadLine(), out var customerId);

            _orderService.Add(new CreateOrderDto { CustomerId = customerId });
            Console.WriteLine("Sifaris yaradıldı.");
        }

        private void Update()
        {
            Console.Write("Yenilenecek sifarisin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            Console.Write("Musteri Id: ");
            int.TryParse(Console.ReadLine(), out var customerId);

            _orderService.Update(new UpdateOrderDto { Id = id, CustomerId = customerId });
            Console.WriteLine("Sifaris yenilendi.");
        }

        private void Delete()
        {
            Console.Write("Silinecek sifarisin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            _orderService.Delete(id);
            Console.WriteLine("Sifaris silindi.");
        }

        private void GetAll()
        {
            var orders = _orderService.GetAll();
            Console.WriteLine("\n--- Sifariş Siyahısı ---");
            foreach (var o in orders)
            {
                Console.WriteLine($"Id: {o.Id} | Tarix: {o.OrderDate} | Cemi: {o.TotalPrice} | Musteri: {o.CustomerName} | Kitablar: {string.Join(", ", o.BookNames)}");
            }
        }

        private void GetById()
        {
            Console.Write("Sifarisin Id-si: ");
            int.TryParse(Console.ReadLine(), out var id);

            var order = _orderService.GetById(id);
            if (order == null)
            {
                Console.WriteLine("Sifaris tapılmadı.");
                return;
            }

            Console.WriteLine($"Id: {order.Id} | Tarix: {order.OrderDate} | Cemi: {order.TotalPrice} | Musteri: {order.CustomerName} | Kitablar: {string.Join(", ", order.BookNames)}");
        }

       

        private void ManageOrderItems()
        {
            Console.Write("Hansi sifarisi idare etmek isteyirsen? Order Id: ");

            int.TryParse(Console.ReadLine(), out var orderId);

            var order = _orderService.GetById(orderId);
            if (order == null)
            {
                Console.WriteLine("Sifaris tapılmadı.");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"===== ORDER #{orderId} ITEMS =====");
                Console.WriteLine("1. Item Elave Et");
                Console.WriteLine("2. Item Yenile");
                Console.WriteLine("3. Item Sil");
                Console.WriteLine("4. Itemlere Bax");
                Console.WriteLine("0. Geri");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": AddItem(orderId); break;
                        case "2": UpdateItem(); break;
                        case "3": DeleteItem(); break;
                        case "4": ShowItems(orderId); break;
                        case "0": return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Xeta: {ex.Message}");
                    var inner = ex.InnerException;
                    while (inner != null)
                    {
                        Console.WriteLine($"  -> {inner.Message}");
                        inner = inner.InnerException;
                    }
                }

                Console.WriteLine("\nDavam etmek üçün istenilen düymeye basın...");
                Console.ReadKey();
            }
        }

        private void AddItem(int orderId)
        {
            Console.Write("Book Id: ");
            int.TryParse(Console.ReadLine(), out var bookId);

            Console.Write("Say (Quantity): ");
            int.TryParse(Console.ReadLine(), out var quantity);

            _orderItemService.Add(new CreateOrderItemDto
            {
                OrderId = orderId,
                BookId = bookId,
                Quantity = quantity
            });

            Console.WriteLine("Item elave olundu.");
        }

        private void UpdateItem()
        {
            Console.Write("Yenilenecek Item Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            Console.Write("Order Id: ");
            int.TryParse(Console.ReadLine(), out var orderId);

            Console.Write("Book Id: ");
            int.TryParse(Console.ReadLine(), out var bookId);

            Console.Write("Say (Quantity): ");
            int.TryParse(Console.ReadLine(), out var quantity);

            _orderItemService.Update(new UpdateOrderItemDto
            {
                Id = id,
                OrderId = orderId,
                BookId = bookId,
                Quantity = quantity
            });

            Console.WriteLine("Item yenilendi.");
        }

        private void DeleteItem()
        {
            Console.Write("Silinecek Item Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            _orderItemService.Delete(id);
            Console.WriteLine("Item silindi.");
        }

        private void ShowItems(int orderId)
        {
            var order = _orderService.GetById(orderId);
            Console.WriteLine($"\n--- Order #{orderId} Kitabları ---");
            if (order != null)
            {
                foreach (var bookName in order.BookNames)
                {
                    Console.WriteLine($"- {bookName}");
                }
            }
        }
    }
}