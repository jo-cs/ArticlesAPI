namespace ArticlesAPI.Features.Chat.DTOs;

public class ChatDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public int? SupportId { get; set; }

    public string? SupportName { get; set; }

    public DateTime CreatedAt { get; set; }
}