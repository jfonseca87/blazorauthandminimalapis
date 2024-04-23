using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public class UserDataService : IUserDataService
{
    private readonly IBaseDataService<User> _baseDataService;
    private const string USER_BASE_URL = "/api/user";

    public UserDataService(IBaseDataService<User> baseDataService) =>
        _baseDataService = baseDataService;
    

    public async Task<ResponseModelData<IEnumerable<User>>> GetUsersAsync() =>
        await _baseDataService.Get<IEnumerable<User>>($"{USER_BASE_URL}");
}