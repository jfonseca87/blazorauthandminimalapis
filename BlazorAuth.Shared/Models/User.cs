using BlazorAuth.Shared.Utils;

namespace BlazorAuth.Shared.Models;

public record User(int Id, string Name, string Email, bool Active, Roles Role);