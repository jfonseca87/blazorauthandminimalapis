namespace BlazorAuth.Shared.Models;

public class ResponseModelData<T> : ResponseModel
{
    public T Data { get; set; } = default!;
}

