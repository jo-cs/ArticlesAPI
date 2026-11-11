using ArticlesAPI.Features.Chat.DTOs;
using ArticlesAPI.Features.Chat.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Chat.Services;
public class ChatService : IChatService
{
    private readonly IChatRepository _repository;
    public ChatService(IChatRepository repository) => _repository = repository;
    public Task<ServiceResult<int>> CreateChatAsync(int userId) => userId <= 0 ? Task.FromResult(ServiceResult<int>.Failure("Invalid user ID.")) : ServiceResult<int>.FromAsync(_repository.CreateChatAsync(userId), "Chat creation failed.", 400);
    public Task<ServiceResult<ChatDto>> GetChatByIdAsync(int id) => id <= 0 ? Task.FromResult(ServiceResult<ChatDto>.Failure("Invalid chat ID.")) : ServiceResult<ChatDto>.FromAsync(_repository.GetChatByIdAsync(id), "Chat not found.");
    public Task<ServiceResult<IEnumerable<ChatDto>>> GetChatsByUserIdAsync(int userId) => userId <= 0 ? Task.FromResult(ServiceResult<IEnumerable<ChatDto>>.Failure("Invalid user ID.")) : ServiceResult<IEnumerable<ChatDto>>.FromAsync(_repository.GetChatsByUserIdAsync(userId), "Chats could not be retrieved.", 500);
    public Task<ServiceResult<IEnumerable<ChatDto>>> GetUnassignedChatsAsync() => ServiceResult<IEnumerable<ChatDto>>.FromAsync(_repository.GetUnassignedChatsAsync(), "Chats could not be retrieved.", 500);
    public Task<ServiceResult<IEnumerable<ChatDto>>> GetChatsBySupportIdAsync(int supportId) => supportId <= 0 ? Task.FromResult(ServiceResult<IEnumerable<ChatDto>>.Failure("Invalid support ID.")) : ServiceResult<IEnumerable<ChatDto>>.FromAsync(_repository.GetChatsBySupportIdAsync(supportId), "Chats could not be retrieved.", 500);
    public Task<ServiceResult<bool>> AssignSupportAsync(int chatId, int supportId) => chatId <= 0 || supportId <= 0 ? Task.FromResult(ServiceResult<bool>.Failure("Invalid chat or support ID.")) : ServiceResult<bool>.FromAsync(_repository.AssignSupportAsync(chatId, supportId), "Chat is already assigned or was not found.", 409);
    public Task<ServiceResult<int>> SendMessageAsync(string messageBody, int senderId, int receiverId, int chatId)
    {
        if (string.IsNullOrWhiteSpace(messageBody)) return Task.FromResult(ServiceResult<int>.Failure("Message cannot be empty."));
        if (senderId <= 0 || receiverId <= 0 || chatId <= 0) return Task.FromResult(ServiceResult<int>.Failure("Invalid sender, receiver, or chat ID."));
        return ServiceResult<int>.FromAsync(_repository.SendMessageAsync(messageBody, senderId, receiverId, chatId), "Message could not be sent.", 400);
    }
    public Task<ServiceResult<IEnumerable<MessageDto>>> GetMessagesAsync(int chatId) => chatId <= 0 ? Task.FromResult(ServiceResult<IEnumerable<MessageDto>>.Failure("Invalid chat ID.")) : ServiceResult<IEnumerable<MessageDto>>.FromAsync(_repository.GetMessagesAsync(chatId), "Messages could not be retrieved.", 500);
    public Task<ServiceResult<int>> MarkAsReadAsync(int chatId, int userId) => chatId <= 0 || userId <= 0 ? Task.FromResult(ServiceResult<int>.Failure("Invalid chat or user ID.")) : ServiceResult<int>.FromAsync(_repository.MarkAsReadAsync(chatId, userId), "Messages could not be marked as read.", 400);
}
