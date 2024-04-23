using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAuth.Client.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity([
            new Claim("UserId", "1"),
            new Claim(ClaimTypes.Name, "Pepito Perez"),
            new Claim("Email", "pperez@domain.com"),
            new Claim("Role", "Admin")
        ], "JWTAuth");
        // var identity = new ClaimsIdentity();
        var principal = new ClaimsPrincipal(identity);
        return Task.FromResult(new AuthenticationState(principal));
    }
}