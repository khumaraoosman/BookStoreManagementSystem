using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookStore.ConsoleUI.Menus
{
    public class OrderMenu
    {
        private readonly IOrderService _orderService;

        public OrderMenu(IServiceProvider serviceProvider)
        {
            _orderService = serviceProvider.GetRequiredService<IOrderService>();
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
                        case "0": return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Xeta: {ex.Message}");
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
            Console.WriteLine("Sifaris yaradıldı. (Kitabları elave etmek üçün Order Items menyusundan istifade edin)");
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
            Console.Write("Sifarişin Id-si: ");
            int.TryParse(Console.ReadLine(), out var id);

            var order = _orderService.GetById(id);
            if (order == null)
            {
                Console.WriteLine("Sifariş tapılmadı.");
                return;
            }

            Console.WriteLine($"Id: {order.Id} | Tarix: {order.OrderDate} | Cemi: {order.TotalPrice} | Musteri: {order.CustomerName} | Kitablar: {string.Join(", ", order.BookNames)}");
        }
    }
}