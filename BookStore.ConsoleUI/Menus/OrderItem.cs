using BookStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.ConsoleUI.Menus;

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

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Add Order Item");
                    break;
                case "2":
                    Console.WriteLine("Update Order Item");
                    break;
                case "3":
                    Console.WriteLine("Delete Order Item");
                    break;
                case "4":
                    Console.WriteLine("Get All Order Items");
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