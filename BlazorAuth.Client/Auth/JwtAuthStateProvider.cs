
using System.Security.Claims;
using BlazorAuth.Client.Helpers;
using BlazorAuth.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAuth.Client.Auth;

public class JwtAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly ILogger<JwtAuthStateProvider> _logger;

    public JwtAuthStateProvider(
        ILocalStorageService localStorage,
        ILogger<JwtAuthStateProvider> logger)
    {
        _localStorage = localStorage;
        _logger = logger;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        var savedToken = await _localStorage.GetItem("token");
        _logger.LogInformation("Token: {savedToken}", savedToken);

        if (!string.IsNullOrWhiteSpace(savedToken))
        {
            identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(savedToken), "jwt");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public void LogOut()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(
            new AuthenticationState(
                new ClaimsPrincipal(
                    new ClaimsIdentity()
                )
            )
        ));
    }
}