using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.ConsoleUI.Menus;

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

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Add Order");
                    break;
                case "2":
                    Console.WriteLine("Update Order");
                    break;
                case "3":
                    Console.WriteLine("Delete Order");
                    break;
                case "4":
                    Console.WriteLine("Get All Orders");
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