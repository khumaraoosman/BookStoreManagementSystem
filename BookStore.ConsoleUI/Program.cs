using BookStore.Application.DependencyInjection;
using BookStore.ConsoleUI;
using BookStore.ConsoleUI.Menus;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.DependencyInjection;
using BookStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using System;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        // Repozitoriyaları qeydiyyatdan keçirən mövcud metodların
        services.AddInfrastructureServices();
        services.AddApplicationServices();

        // 👇 MENYULARIN QEYDİYYATINI BİRBAŞA BURADA YAZ:
        services.AddTransient<ConsoleApp>();
       
        services.AddTransient<BookMenu>();
        services.AddTransient<AuthorMenu>();
        services.AddTransient<GenreMenu>();
        services.AddTransient<CustomerMenu>();
        services.AddTransient<OrderMenu>();

        // Provider yaradılır
        var serviceProvider = services.BuildServiceProvider();

        // Start
        var app = new ConsoleApp(serviceProvider);
        app.Run();
    }
}
