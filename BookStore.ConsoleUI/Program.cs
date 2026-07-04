using BookStore.Application.DependencyInjection;
using BookStore.ConsoleUI;
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
        // 1. ServiceCollection yaradılır
        var services = new ServiceCollection();

        // 2. DbContext + Infrastructure servisləri
        services.AddInfrastructureServices();

        // 3. Application servisləri
        services.AddApplicationServices();

        // 4. ServiceProvider yaradılır
        var serviceProvider = services.BuildServiceProvider();

        // 5. ConsoleUI start edilir
        var app = new ConsoleApp(serviceProvider);
        app.Run();
    }
}
