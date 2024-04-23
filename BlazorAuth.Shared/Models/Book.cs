using System.ComponentModel.DataAnnotations;

namespace BlazorAuth.Shared.Models;

public record Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "Pages must be greater than 0")]
    public int Pages { get; set; }
}