namespace ArticlesAPI.Features.Chat.Models;

public class ConversationMessage
{
    public int  Id { get; set; }
    public DateTime SentAt { get; set; }
    public int ChatId { get; set; }
    public string MessageBody { get; set; } = string.Empty;
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public bool IsRead { get; set; }
}