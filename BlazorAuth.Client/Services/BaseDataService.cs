using System.Net.Http.Headers;
using System.Net.Http.Json;
using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public class BaseDataService<T>(HttpClient http, ILocalStorageService localStorageService) 
    : IBaseDataService<T>
{
    private readonly HttpClient _http = http;
    private readonly ILocalStorageService _localStorageService = localStorageService;

    public async Task<ResponseModelData<U>> Get<U>(string url, bool addHeaders = true)
    {
        ArgumentNullException.ThrowIfNull(url);
        if (addHeaders)
            await SetHeaders();

        var result = await _http.GetFromJsonAsync<ResponseModelData<U>>(url);
        return result!;
    }

    public async Task<ResponseModelData<U>> Post<U>(string url, T data, bool addHeaders = true)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(data);

        if (addHeaders)
            await SetHeaders();

        HttpResponseMessage response = await _http.PostAsJsonAsync(url, data);

        if (!response.IsSuccessStatusCode && 
            response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        {
            // Handle HTTP request failure (e.g., logging, throwing custom exception)
            throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
        }

        // Deserialize the response body to ResponseModelData<T>
        var result = await response.Content.ReadFromJsonAsync<ResponseModelData<U>>();
        return result!;
    }

    public async Task<ResponseModelData<U>> Put<U>(string url, T data, bool addHeaders = true)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(data);

        if (addHeaders)
            await SetHeaders();

        HttpResponseMessage response = await _http.PutAsJsonAsync(url, data);

        if (!response.IsSuccessStatusCode && 
            response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        {
            // Handle HTTP request failure (e.g., logging, throwing custom exception)
            throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
        }

        // Deserialize the response body to ResponseModelData<T>
        var result = await response.Content.ReadFromJsonAsync<ResponseModelData<U>>();
        return result!;
    }

    public async Task<ResponseModelData<U>> Delete<U>(string url, bool addHeaders = true)
    {
        ArgumentNullException.ThrowIfNull(url);

        if (addHeaders)
            await SetHeaders();

        var result = await _http.DeleteFromJsonAsync<ResponseModelData<U>>(url);
        return result!;
    }

    private async Task SetHeaders()
    {
        string token = await _localStorageService.GetItem("token");
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}