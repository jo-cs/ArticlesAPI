
using ArticlesAPI.Features.Chat.DTOs;
using ArticlesAPI.Features.Chat.Repositories;

namespace ArticlesAPI.Features.Chat.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _repository;

    public ChatService(IChatRepository repository)
    {
        _repository = repository;
    }

    // 1. Create Chat
    public async Task<int> CreateChatAsync(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("Invalid user ID.");

        return await _repository.CreateChatAsync(userId);
    }

    // 2. Get Chat By Id
    public async Task<ChatDto?> GetChatByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid chat ID.");

        return await _repository.GetChatByIdAsync(id);
    }

    // 3. Get Chats By User Id
    public async Task<IEnumerable<ChatDto>> GetChatsByUserIdAsync(
        int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("Invalid user ID.");

        return await _repository.GetChatsByUserIdAsync(userId);
    }

    // 4. Get Unassigned Chats
    public async Task<IEnumerable<ChatDto>> GetUnassignedChatsAsync()
    {
        return await _repository.GetUnassignedChatsAsync();
    }

    // 5. Get Chats By Support Id
    public async Task<IEnumerable<ChatDto>> GetChatsBySupportIdAsync(
        int supportId)
    {
        if (supportId <= 0)
            throw new ArgumentException("Invalid support ID.");

        return await _repository.GetChatsBySupportIdAsync(supportId);
    }

    // 6. Assign Support
    public async Task<bool> AssignSupportAsync(
        int chatId,
        int supportId)
    {
        if (chatId <= 0)
            throw new ArgumentException("Invalid chat ID.");

        if (supportId <= 0)
            throw new ArgumentException("Invalid support ID.");

        return await _repository.AssignSupportAsync(chatId, supportId);
    }

    // 7. Send Message
    public async Task<int> SendMessageAsync(
        string messageBody,
        int senderId,
        int receiverId,
        int chatId)
    {
        if (string.IsNullOrWhiteSpace(messageBody))
            throw new ArgumentException("Message cannot be empty.");

        if (senderId <= 0)
            throw new ArgumentException("Invalid sender ID.");

        if (receiverId <= 0)
            throw new ArgumentException("Invalid receiver ID.");

        if (chatId <= 0)
            throw new ArgumentException("Invalid chat ID.");

        return await _repository.SendMessageAsync(
            messageBody,
            senderId,
            receiverId,
            chatId);
    }

    // 8. Get Messages
    public async Task<IEnumerable<MessageDto>> GetMessagesAsync(
        int chatId)
    {
        if (chatId <= 0)
            throw new ArgumentException("Invalid chat ID.");

        return await _repository.GetMessagesAsync(chatId);
    }

    // 9. Mark As Read
    public async Task<int> MarkAsReadAsync(
        int chatId,
        int userId)
    {
        if (chatId <= 0)
            throw new ArgumentException("Invalid chat ID.");

        if (userId <= 0)
            throw new ArgumentException("Invalid user ID.");

        return await _repository.MarkAsReadAsync(chatId, userId);
    }
}
