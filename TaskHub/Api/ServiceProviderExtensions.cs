namespace Api;

public static class ServiceProviderExtensions
{
    public static void ResolveTwiceAndCompare<T>(this IServiceProvider serviceProvider) where T : IHasInstanceId
    {
        var first = serviceProvider.GetRequiredService<T>();
        var second = serviceProvider.GetRequiredService<T>();
        
        Console.WriteLine($"{typeof(T).Name}:");
        Console.WriteLine($"  First: {first.InstanceId}");
        Console.WriteLine($"  Second: {second.InstanceId}");
        Console.WriteLine($"  Same: {first.InstanceId == second.InstanceId}");
    }
}