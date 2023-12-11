namespace ShoppingSystem.Infrastructure.Services
{
    public interface ICacheService
    {
        T GetOrSet<T>(string key, Func<T> getItemCallback, TimeSpan expirationTime);
        T Get<T>(string key);
    }
}