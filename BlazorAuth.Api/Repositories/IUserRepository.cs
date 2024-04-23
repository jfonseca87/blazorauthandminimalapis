
using BlazorAuth.Shared.Models;

namespace BlazorAuth.Api.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    LoginResponse Login(Login login);
}