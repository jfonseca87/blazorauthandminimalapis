namespace BlazorAuth.Shared.Models;

public class ResponseModel
{
    public bool Success { get; set; }
    public string[] Errors { get; set; } = [];
}