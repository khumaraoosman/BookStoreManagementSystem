using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleUI.Menus
{


    public class BookMenu(IBookService bookService)
    {
        private readonly IBookService _bookService = bookService;

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== BOOK MENU =========");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Show Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Update Book");
                Console.WriteLine("5. Delete Book");
                Console.WriteLine("0. Back");

                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": ShowBooks(); break;
                    case "3": SearchBook(); break;
                    case "4": UpdateBook(); break;
                    case "5": DeleteBook(); break;
                    case "0": return;
                }
            }
        
           
        }
        private void AddBook()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Price: ");
            var price = decimal.Parse(Console.ReadLine());

            _bookService.Create(new CreateBookDto
            {
                Name = name,
                Price = price
            });

            Console.WriteLine("Book added!");
            Console.ReadKey();
        }
        private void ShowBooks()
        {
            var books = _bookService.GetAll();

            Console.WriteLine("===== BOOK LIST =====");

            foreach (var b in books)
            {
                Console.WriteLine($"{b.Id} - {b.Name} - {b.Price}");
            }

            Console.ReadKey();
        }
        private void SearchBook()
        {
            Console.Write("Enter keyword: ");
            var keyword = Console.ReadLine();

            var result = _bookService.Search(keyword);

            foreach (var b in result)
            {
                Console.WriteLine($"{b.Id} - {b.Name}");
            }

            Console.ReadKey();
        }
        private void UpdateBook()
        {
            Console.Write("Enter book ID to update: ");
            var id = int.Parse(Console.ReadLine());
            var book = _bookService.GetById(id);
            if (book == null)
            {
                Console.WriteLine("Book not found!");
                Console.ReadKey();
                return;
            }
            Console.Write($"Name ({book.Name}): ");
            var name = Console.ReadLine();
            Console.Write($"Price ({book.Price}): ");
            var price = decimal.Parse(Console.ReadLine());
            _bookService.Update(new UpdateBookDto
            {
                Id = id,
                Name = string.IsNullOrEmpty(name) ? book.Name : name,
                Price = price
            });
            Console.WriteLine("Book updated!");
            Console.ReadKey();
        }
        private void DeleteBook()
        {
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());

            _bookService.Delete(id);

            Console.WriteLine("Deleted!");
            Console.ReadKey();
        }
    }

    internal interface IBookService
    {
    }
}
