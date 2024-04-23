namespace BlazorAuth.Shared.Models;

public record Login
{
    public string? Email { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
}