using ArticlesAPI.Features.Chat.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.Chat.Repositories;
public class ChatRepository : BaseRepository, IChatRepository
{
    public ChatRepository(DapperContext context) : base(context) { }
    public Task<int> CreateChatAsync(int userId) => QuerySingleAsync<int>("Chat_Create", new { UserId = userId });
    public Task<ChatDto?> GetChatByIdAsync(int id) => QuerySingleOrDefaultAsync<ChatDto>("Chat_GetById", new { Id = id });
    public Task<IEnumerable<ChatDto>> GetChatsByUserIdAsync(int userId) => QueryAsync<ChatDto>("Chat_GetByUserId", new { UserId = userId });
    public Task<IEnumerable<ChatDto>> GetUnassignedChatsAsync() => QueryAsync<ChatDto>("Chat_GetUnassigned");
    public Task<IEnumerable<ChatDto>> GetChatsBySupportIdAsync(int supportId) => QueryAsync<ChatDto>("Chat_GetBySupportId", new { SupportId = supportId });
    public async Task<bool> AssignSupportAsync(int chatId, int supportId) => await QuerySingleAsync<int>("Chat_AssignSupport", new { ChatId = chatId, SupportId = supportId }) == 1;
    public Task<int> SendMessageAsync(string messageBody, int senderId, int receiverId, int chatId) => QuerySingleAsync<int>("Conversation_SendMessage", new { MessageBody = messageBody, SenderId = senderId, ReceiverId = receiverId, ChatId = chatId });
    public Task<IEnumerable<MessageDto>> GetMessagesAsync(int chatId) => QueryAsync<MessageDto>("Conversation_GetMessage", new { ChatId = chatId });
    public Task<int> MarkAsReadAsync(int chatId, int userId) => QuerySingleAsync<int>("Conversation_MarkAsRead", new { ChatId = chatId, UserId = userId });
}
