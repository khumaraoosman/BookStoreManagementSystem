using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleUI.Menus
{
    

    public class MainMenu(
        BookMenu bookMenu,
        AuthorMenu authorMenu,
        CustomerMenu customerMenu,
        OrderMenu orderMenu
    )
    {
        private readonly BookMenu _bookMenu = bookMenu;
        private readonly AuthorMenu _authorMenu = authorMenu;
        private readonly CustomerMenu _customerMenu = customerMenu;
        private readonly OrderMenu _orderMenu = orderMenu;
        public void Show()
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
                Console.WriteLine("0. Exit");

                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _bookMenu.Show();
                        break;

                    case "2":
                        _authorMenu.Show();
                        break;

                    case "3":
                        break;

                    case "4":
                        _customerMenu.Show();
                        break;

                    case "5":
                        _orderMenu.Show();
                        break;

                    case "0":
                        return;
                }
            }
        }
    }
}
