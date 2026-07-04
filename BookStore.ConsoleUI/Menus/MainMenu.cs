using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.ConsoleUI.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.ConsoleUI
{
    public class ConsoleApp
    {
        private readonly IServiceProvider _serviceProvider;

        public ConsoleApp(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==============================");
                Console.WriteLine("      BOOK STORE SYSTEM");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Authors");
                Console.WriteLine("3. Genres");
                Console.WriteLine("4. Customers");
                Console.WriteLine("5. Orders");
                Console.WriteLine("6. Order Items");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var bookMenu = new BookMenu(_serviceProvider);
                        bookMenu.Show();
                        break;

                    case "2":
                        var authorMenu = new AuthorMenu(_serviceProvider);
                        authorMenu.Show();
                        break;

                    case "3":
                        var genreMenu = new GenreMenu(_serviceProvider);
                        genreMenu.Show();
                        break;

                    case "4":
                        var customerMenu = new CustomerMenu(_serviceProvider);
                        customerMenu.Show();
                        break;

                    case "5":
                        var orderMenu = new OrderMenu(_serviceProvider);
                        orderMenu.Show();
                        break;

                    case "6":
                        var orderItemMenu = new OrderItemMenu(_serviceProvider);
                        orderItemMenu.Show();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
