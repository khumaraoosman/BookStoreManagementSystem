using BookStore.ConsoleUI.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.ConsoleUI
{
    var services = new ServiceCollection();

    services.AddApplication();
    services.AddInfrastructure();

// Menus
    services.AddSingleton<MainMenu>();
    services.AddSingleton<BookMenu>();
    services.AddSingleton<AuthorMenu>();
    services.AddSingleton<CustomerMenu>();
    services.AddSingleton<OrderMenu>();

    var provider = services.BuildServiceProvider();

    var main = provider.GetRequiredService<MainMenu>();
    main.Show();
       
    
}
    
