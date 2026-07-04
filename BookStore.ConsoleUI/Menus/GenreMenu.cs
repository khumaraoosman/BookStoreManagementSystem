using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookStore.ConsoleUI.Menus
{
    public class GenreMenu
    {
        private readonly IGenreService _genreService;

        public GenreMenu(IServiceProvider serviceProvider)
        {
            _genreService = serviceProvider.GetRequiredService<IGenreService>();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== GENRE MENU =====");
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
            Console.Write("Janr adı: ");
            var name = Console.ReadLine() ?? "";

            _genreService.Add(new CreateGenreDto { Name = name });
            Console.WriteLine("Janr elave olundu.");
        }

        private void Update()
        {
            Console.Write("Yenilenecek janrın Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            Console.Write("Yeni ad: ");
            var name = Console.ReadLine() ?? "";

            _genreService.Update(new UpdateGenreDto { Id = id, Name = name });
            Console.WriteLine("Janr yenilendi.");
        }

        private void Delete()
        {
            Console.Write("Silinecek janrın Id: ");
            int.TryParse(Console.ReadLine(), out var id);

            _genreService.Delete(id);
            Console.WriteLine("Janr silindi.");
        }

        private void GetAll()
        {
            var genres = _genreService.GetAll();
            Console.WriteLine("\n--- Janr Siyahısı ---");
            foreach (var g in genres)
            {
                Console.WriteLine($"Id: {g.Id} | Ad: {g.Name} | Kitablar: {string.Join(", ", g.BookNames)}");
            }
        }

        private void GetById()
        {
            Console.Write("Janrın Id-si: ");
            int.TryParse(Console.ReadLine(), out var id);

            var genre = _genreService.GetById(id);
            if (genre == null)
            {
                Console.WriteLine("Janr tapılmadı.");
                return;
            }

            Console.WriteLine($"Id: {genre.Id} | Ad: {genre.Name} | Kitablar: {string.Join(", ", genre.BookNames)}");
        }
    }
}