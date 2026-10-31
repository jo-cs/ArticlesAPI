
namespace ArticlesAPI.Features.Chat.DTOs;

public class SendMessageRequest
{
    public string MessageBody { get; set; } = string.Empty;

    public int ReceiverId { get; set; }

    public int ChatId { get; set; }
}
