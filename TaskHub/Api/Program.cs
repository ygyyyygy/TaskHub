using LoggingLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api;

public sealed class Program
{
    /// <summary>
    /// Запуск приложения
    /// </summary>
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<SingletonService1>();
                services.AddSingleton<SingletonService2>();
                services.AddScoped<ScopedService1>();
                services.AddScoped<ScopedService2>();
                services.AddTransient<TransientService1>();
                services.AddTransient<TransientService2>();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();

        using (var scope1 = host.Services.CreateScope())
        {
            Console.WriteLine("Scope 1:");
            var sp = scope1.ServiceProvider;
            
            sp.ResolveTwiceAndCompare<SingletonService1>();
            sp.ResolveTwiceAndCompare<SingletonService2>();
            sp.ResolveTwiceAndCompare<ScopedService1>();
            sp.ResolveTwiceAndCompare<ScopedService2>();
            sp.ResolveTwiceAndCompare<TransientService1>();
            sp.ResolveTwiceAndCompare<TransientService2>();
        }
        
        using (var scope2 = host.Services.CreateScope())
        {
            Console.WriteLine("\nScope 2:");
            var sp = scope2.ServiceProvider;
            
            sp.ResolveTwiceAndCompare<SingletonService1>();
            sp.ResolveTwiceAndCompare<SingletonService2>();
            sp.ResolveTwiceAndCompare<ScopedService1>();
            sp.ResolveTwiceAndCompare<ScopedService2>();
            sp.ResolveTwiceAndCompare<TransientService1>();
            sp.ResolveTwiceAndCompare<TransientService2>();
        }
        
        Console.WriteLine("\n=== Запуск веб-приложения ===\n");
        host.Run();
    }
}