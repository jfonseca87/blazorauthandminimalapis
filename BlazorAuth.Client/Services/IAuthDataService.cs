using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public interface IAuthDataService
{
    Task<ResponseModelData<LoginResponse>> Login(Login login);
}