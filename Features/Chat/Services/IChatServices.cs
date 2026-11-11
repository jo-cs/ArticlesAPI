using ArticlesAPI.Features.Chat.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Chat.Services;
public interface IChatService
{
    Task<ServiceResult<int>> CreateChatAsync(int userId);
    Task<ServiceResult<ChatDto>> GetChatByIdAsync(int id);
    Task<ServiceResult<IEnumerable<ChatDto>>> GetChatsByUserIdAsync(int userId);
    Task<ServiceResult<IEnumerable<ChatDto>>> GetUnassignedChatsAsync();
    Task<ServiceResult<IEnumerable<ChatDto>>> GetChatsBySupportIdAsync(int supportId);
    Task<ServiceResult<bool>> AssignSupportAsync(int chatId, int supportId);
    Task<ServiceResult<int>> SendMessageAsync(string messageBody, int senderId, int receiverId, int chatId);
    Task<ServiceResult<IEnumerable<MessageDto>>> GetMessagesAsync(int chatId);
    Task<ServiceResult<int>> MarkAsReadAsync(int chatId, int userId);
}
