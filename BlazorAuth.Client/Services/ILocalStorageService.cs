namespace BlazorAuth.Client.Services;

public interface ILocalStorageService
{
    Task SetItem(string key, string value);
    Task<string> GetItem(string key);
    Task RemoveItem(string key);
    Task Clear();
}