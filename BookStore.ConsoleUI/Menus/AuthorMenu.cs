using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookStore.ConsoleUI.Menus
{
    public class AuthorMenu
    {
        private readonly IAuthorService _authorService;

        public AuthorMenu(IServiceProvider serviceProvider)
        {
            _authorService = serviceProvider.GetRequiredService<IAuthorService>();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== AUTHOR MENU =====");
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
            Console.Write("Müellifin adı: ");
            var fullName = Console.ReadLine() ?? "";

            _authorService.Add(new CreateAuthorDto { FullName = fullName });
            Console.WriteLine("Muellif əlavə olundu.");
        }

        private void Update()
        {
            Console.Write("Yenilenecek muellifin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            Console.Write("Yeni ad: ");
            var fullName = Console.ReadLine() ?? "";

            _authorService.Update(new UpdateAuthorDto { Id = id, FullName = fullName });
            Console.WriteLine("Muellif yenilendi.");
        }

        private void Delete()
        {
            Console.Write("Silinecek muellifin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            _authorService.Delete(id);
            Console.WriteLine("Muellif silindi.");
        }

        private void GetAll()
        {
            var authors = _authorService.GetAll();
            Console.WriteLine("\n--- Muellif Siyahısı ---");
            foreach (var a in authors)
            {
                Console.WriteLine($"Id: {a.Id} | Ad: {a.FullName} | Kitablar: {string.Join(", ", a.BookNames)}");
            }
        }

        private void GetById()
        {
            Console.Write("Muellifin Id-si: ");
            int.TryParse(Console.ReadLine(), out var id);

            var author = _authorService.GetById(id);
            if (author == null)
            {
                Console.WriteLine("Muellif tapılmadı.");
                return;
            }

            Console.WriteLine($"Id: {author.Id} | Ad: {author.FullName} | Kitablar: {string.Join(", ", author.BookNames)}");
        }
    }
}