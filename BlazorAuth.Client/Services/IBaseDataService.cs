using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public interface IBaseDataService<T>
{
    Task<ResponseModelData<U>> Get<U>(string url, bool addHeaders = true);
    Task<ResponseModelData<U>> Post<U>(string url, T data, bool addHeaders = true);
    Task<ResponseModelData<U>> Put<U>(string url, T data, bool addHeaders = true);
    Task<ResponseModelData<U>> Delete<U>(string url, bool addHeaders = true);
}