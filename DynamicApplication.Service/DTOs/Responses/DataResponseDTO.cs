namespace DynamicApplication.Service.DTOs.Responses;

public record DataResponseDTO<T>
{
    public bool Success { get; set; } = true;

    public T Data { get; set; }
}