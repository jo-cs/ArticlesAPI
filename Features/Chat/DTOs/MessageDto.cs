namespace ArticlesAPI.Features.Chat.DTOs;

public class MessageDto
{
    public int Id { get; set; }

    public int ChatId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string MessageBody { get; set; } = string.Empty;

    public bool IsRead { get; set; }

    public DateTime SentAt { get; set; }
}