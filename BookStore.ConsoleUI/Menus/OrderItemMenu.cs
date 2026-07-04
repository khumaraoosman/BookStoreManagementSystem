using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookStore.ConsoleUI.Menus
{
    public class OrderItemMenu
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemMenu(IServiceProvider serviceProvider)
        {
            _orderItemService = serviceProvider.GetRequiredService<IOrderItemService>();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== ORDER ITEM MENU =====");
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
                    Console.WriteLine($"Xəta: {ex.Message}");
                }

                Console.WriteLine("\nDavam etmek üçün istenilen düymeye basın...");
                Console.ReadKey();
            }
        }

        private void Add()
        {
            Console.Write("Order Id: ");
            int.TryParse(Console.ReadLine(), out var orderId);

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

            Console.WriteLine("Sifaris setri elave olundu.");
        }

        private void Update()
        {
            Console.Write("Yenilenecek setrin Id: ");
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

            Console.WriteLine("Sifaris setri yenilendi.");
        }

        private void Delete()
        {
            Console.Write("Silinecek setrin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            _orderItemService.Delete(id);
            Console.WriteLine("Sifaris setri silindi.");
        }

        private void GetAll()
        {
            var items = _orderItemService.GetAll();
            Console.WriteLine("\n--- Order Item Siyahısı ---");
            foreach (var i in items)
            {
                Console.WriteLine($"Id: {i.Id} | Kitab: {i.BookName} | Say: {i.Quantity}");
            }
        }

        private void GetById()
        {
            Console.Write("Sətrin Id-si: ");
            int.TryParse(Console.ReadLine(), out var id);

            var item = _orderItemService.GetById(id);
            if (item == null)
            {
                Console.WriteLine("Tapılmadı.");
                return;
            }

            Console.WriteLine($"Id: {item.Id} | Kitab: {item.BookName} | Say: {item.Quantity}");
        }
    }
}