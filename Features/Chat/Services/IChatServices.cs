using ArticlesAPI.Features.Chat.DTOs;

namespace ArticlesAPI.Features.Chat.Services;

public interface IChatService
{
    Task<int> CreateChatAsync(int userId);

    Task<ChatDto?> GetChatByIdAsync(int id);

    Task<IEnumerable<ChatDto>> GetChatsByUserIdAsync(int userId);

    Task<IEnumerable<ChatDto>> GetUnassignedChatsAsync();

    Task<IEnumerable<ChatDto>> GetChatsBySupportIdAsync(int supportId);

    Task<bool> AssignSupportAsync(int chatId, int supportId);

    Task<int> SendMessageAsync(
        string messageBody,
        int senderId,
        int receiverId,
        int chatId);

    Task<IEnumerable<MessageDto>> GetMessagesAsync(int chatId);

    Task<int> MarkAsReadAsync(int chatId, int userId);
}