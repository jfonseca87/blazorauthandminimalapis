using BlazorAuth.Shared.Models;

namespace BlazorAuth.Client.Services;

public interface IUserDataService
{
    Task<ResponseModelData<IEnumerable<User>>> GetUsersAsync();
}