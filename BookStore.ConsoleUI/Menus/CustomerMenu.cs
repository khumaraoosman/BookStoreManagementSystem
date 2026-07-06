using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.ConsoleUI.Menus
{
    public class CustomerMenu
    {
        private readonly ICustomerService _customerService;

        public CustomerMenu(IServiceProvider serviceProvider)
        {
            _customerService = serviceProvider.GetRequiredService<ICustomerService>();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== CUSTOMER MENU =====");
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
            Console.Write("Musteri adi: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Address:");
            var address = Console.ReadLine() ?? "";

            _customerService.Add(new CreateCustomerDto { Name = name, Address = address });
            Console.WriteLine("Musteri elave olundu.");
        }

        private void Update()
        {
            Console.Write("Yenilenecek musterinin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            Console.Write("Yeni ad: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Yeni unvan: ");
            var address = Console.ReadLine() ?? "";

            _customerService.Update(new UpdateCustomerDto { Id = id, Name = name, Address = address });
            Console.WriteLine("Musteri yenilendi.");
        }

        private void Delete()
        {
            Console.Write("Silinecek musterinin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            _customerService.Delete(id);
            Console.WriteLine("Musteri silindi.");
        }

        private void GetAll()
        {
            var customers = _customerService.GetAll();
            Console.WriteLine("\n--- Musteri Siyahısı ---");
            foreach (var c in customers)
            {
                Console.WriteLine($"Id: {c.Id} | Ad: {c.Name} | Unvan: {c.Address} | Sifaris sayı: {c.OrderIds.Count}");
            }
        }

        private void GetById()
        {
            Console.Write("Musterinin Id-si: ");
            int.TryParse(Console.ReadLine(), out var id);

            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                Console.WriteLine("Musteri tapılmadı.");
                return;
            }

            Console.WriteLine($"Id: {customer.Id} | Ad: {customer.Name} | Unvan: {customer.Address} | Sifaris Id-leri: {string.Join(", ", customer.OrderIds)}");
        }
    }
}