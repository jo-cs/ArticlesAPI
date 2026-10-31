
using Dapper;
using ArticlesAPI.Features.Chat.DTOs;
using ArticlesAPI.Infrastructure.Data;

namespace ArticlesAPI.Features.Chat.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly DapperContext _context;

    public ChatRepository(DapperContext context)
    {
        _context = context;
    }

    // 1. Create Chat
    public async Task<int> CreateChatAsync(int userId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QuerySingleAsync<int>(
            "Chat_Create",
            new { UserId = userId },
            commandType: System.Data.CommandType.StoredProcedure);
    }

    // 2. Get Chat By Id
    public async Task<ChatDto?> GetChatByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();

        return await connection.QuerySingleOrDefaultAsync<ChatDto>(
            "Chat_GetById",
            new { Id = id },
            commandType: System.Data.CommandType.StoredProcedure);
    }

    // 3. Get Chats By User Id
    public async Task<IEnumerable<ChatDto>> GetChatsByUserIdAsync(
        int userId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<ChatDto>(
            "Chat_GetByUserId",
            new { UserId = userId },
            commandType: System.Data.CommandType.StoredProcedure);
    }

    // 4. Get Unassigned Chats
    public async Task<IEnumerable<ChatDto>> GetUnassignedChatsAsync()
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<ChatDto>(
            "Chat_GetUnassigned",
            commandType: System.Data.CommandType.StoredProcedure);
    }

    // 5. Get Chats By Support Id
    public async Task<IEnumerable<ChatDto>> GetChatsBySupportIdAsync(
        int supportId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<ChatDto>(
            "Chat_GetBySupportId",
            new { SupportId = supportId },
            commandType: System.Data.CommandType.StoredProcedure);
    }

    // 6. Assign Support
    public async Task<bool> AssignSupportAsync(
        int chatId,
        int supportId)
    {
        using var connection = _context.CreateConnection();

        var result = await connection.QuerySingleAsync<int>(
            "Chat_AssignSupport",
            new
            {
                ChatId = chatId,
                SupportId = supportId
            },
            commandType: System.Data.CommandType.StoredProcedure);

        return result == 1;
    }

    // 7. Send Message
    public async Task<int> SendMessageAsync(
        string messageBody,
        int senderId,
        int receiverId,
        int chatId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QuerySingleAsync<int>(
            "Conversation_SendMessage",
            new
            {
                MessageBody = messageBody,
                SenderId = senderId,
                ReceiverId = receiverId,
                ChatId = chatId
            },
            commandType: System.Data.CommandType.StoredProcedure);
    }

    // 8. Get Messages
    public async Task<IEnumerable<MessageDto>> GetMessagesAsync(
        int chatId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<MessageDto>(
            "Conversation_GetMessage",
            new { ChatId = chatId },
            commandType: System.Data.CommandType.StoredProcedure);
    }

    // 9. Mark Messages As Read
    public async Task<int> MarkAsReadAsync(
        int chatId,
        int userId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QuerySingleAsync<int>(
            "Conversation_MarkAsRead",
            new
            {
                ChatId = chatId,
                UserId = userId
            },
            commandType: System.Data.CommandType.StoredProcedure);
    }
}
