using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookStore.ConsoleUI.Menus
{
    public class BookMenu
    {
        private readonly IBookService _bookService;

        public BookMenu(IServiceProvider serviceProvider)
        {
            _bookService = serviceProvider.GetRequiredService<IBookService>();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== BOOK MENU =====");
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
            Console.Write("Kitab adı: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Price: ");
            double.TryParse(Console.ReadLine(), out var price);

            Console.Write("Author Id: ");
            int.TryParse(Console.ReadLine(), out var authorId);

            Console.Write("Genre Id: ");
            int.TryParse(Console.ReadLine(), out var genreId);

            _bookService.Add(new CreateBookDto
            {
                Name = name,
                Price = price,
                AuthorId = authorId,
                GenreId = genreId
            });

            Console.WriteLine("Kitab elave olundu.");
        }

        private void Update()
        {
            Console.Write("Yenilenecek kitabin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            Console.Write("Yeni ad: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Yeni qiymet: ");
            double.TryParse(Console.ReadLine(), out var price);

            Console.Write("Author Id: ");
            int.TryParse(Console.ReadLine(), out var authorId);

            Console.Write("Genre Id: ");
            int.TryParse(Console.ReadLine(), out var genreId);

            _bookService.Update(new UpdateBookDto
            {
                Id = id,
                Name = name,
                Price = price,
                AuthorId = authorId,
                GenreId = genreId
            });

            Console.WriteLine("Kitab yenilendi.");
        }

        private void Delete()
        {
            Console.Write("Silinecek kitabin Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            _bookService.Delete(id);
            Console.WriteLine("Kitab silindi.");
        }

        private void GetAll()
        {
            var books = _bookService.GetAll();
            Console.WriteLine("\n--- Kitab Siyahısı ---");
            foreach (var b in books)
            {
                Console.WriteLine($"Id: {b.Id} | Ad: {b.Name} | Qiymet: {b.Price} | Muellif: {b.AuthorName} | Janr: {b.GenreName}");
            }
        }

        private void GetById()
        {
            Console.Write("Kitabın Id-si: ");
            int.TryParse(Console.ReadLine(), out var id);

            var book = _bookService.GetById(id);
            if (book == null)
            {
                Console.WriteLine("Kitab tapılmadı.");
                return;
            }

            Console.WriteLine($"Id: {book.Id} | Ad: {book.Name} | Qiymet: {book.Price} | Muellif: {book.AuthorName} | Janr: {book.GenreName}");
        }
    }
}