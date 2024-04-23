using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public class AuthDataService : IAuthDataService
{
    private readonly IBaseDataService<Login> _baseDataService;
    private const string USER_BASE_URL = "/api/user";

    public AuthDataService(IBaseDataService<Login> baseDataService)
    {
        _baseDataService = baseDataService;
    }

    public async Task<ResponseModelData<LoginResponse>> Login(Login login)
    {
        return await _baseDataService.Post<LoginResponse>($"{USER_BASE_URL}/login", login, false);
    }
}