using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Add Customer");
                        break;
                    case "2":
                        Console.WriteLine("Update Customer");
                        break;
                    case "3":
                        Console.WriteLine("Delete Customer");
                        break;
                    case "4":
                        Console.WriteLine("Get All Customers");
                        break;
                    case "5":
                        Console.WriteLine("Get By Id");
                        break;
                    case "0":
                        return;
                }

                Console.ReadKey();
            }
        }


    }
}
