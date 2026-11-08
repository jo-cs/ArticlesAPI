
using ArticlesAPI.Features.Chat.DTOs;
using ArticlesAPI.Features.Chat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArticlesAPI.Shared.Base;

namespace ArticlesAPI.Features.Chat.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatController : BaseController
{
    private readonly IChatService _service;

    public ChatController(IChatService service)
    {
        _service = service;
    }

    // 1. Create Chat
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateChat()
    {
        if (CurrentUserId is not int userId)
            return Unauthorized();

        var id = await _service.CreateChatAsync(userId);

        return Ok(new { Id = id });
    }

    // 2. Get Chat By Id
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetChatById(int id)
    {
        var chat = await _service.GetChatByIdAsync(id);

        if (chat is null)
            return NotFound();

        if (CurrentUserId is not int currentUserId)
            return Unauthorized();

        var isOwner = chat.UserId == currentUserId;

        var isAssignedSupport =
            User.IsInRole("Support") &&
            chat.SupportId == currentUserId;

        if (!isOwner && !isAssignedSupport)
            return Forbid();

        return Ok(chat);
    }

    // 3. Get Chats By User Id
    [HttpGet("my-chats")]
    public async Task<IActionResult> GetMyChats()
    {
        if (CurrentUserId is not int userId)
            return Unauthorized();

        var chats = await _service.GetChatsByUserIdAsync(userId);
        return Ok(chats);

    }

    // 4. Get Unassigned Chats
    [HttpGet("unassigned")]
    [Authorize(Roles = "Support")]
    public async Task<IActionResult> GetUnassignedChats()
    {
        var chats = await _service.GetUnassignedChatsAsync();

        return Ok(chats);
    }

    // 5. Get Chats Assigned To Current Support Employee
    [HttpGet("my-assigned-chats")]
    [Authorize(Roles = "Support")]
    public async Task<IActionResult> GetMyAssignedChats()
    {
        if (CurrentUserId is not int supportId)
            return Unauthorized();

        var chats = await _service.GetChatsBySupportIdAsync(supportId);
        return Ok(chats);
    }

    // 6. Assign Support
    [HttpPatch("{chatId:int}/assign")]
    [Authorize(Roles = "Support")]
    public async Task<IActionResult> AssignSupport(int chatId)
    {
        if (CurrentUserId is not int supportId)
            return Unauthorized();

        var assigned = await _service.AssignSupportAsync(chatId, supportId);

        return assigned
            ? Ok(new { Message = "Chat assigned successfully." })
            : Conflict(new { Message = "Chat is already assigned." });
    }

    // 7. Send Message
    [HttpPost("{chatId:int}/messages")]
    public async Task<IActionResult> SendMessage(
        int chatId,
        [FromBody] SendMessageRequest request)
    {
        if (CurrentUserId is not int senderId)
            return Unauthorized();

        var chat = await _service.GetChatByIdAsync(chatId);

        if (chat is null)
            return NotFound();

        int receiverId;

        if (chat.UserId == senderId && chat.SupportId.HasValue)
        {
            receiverId = chat.SupportId.Value;
        }
        else if (chat.SupportId == senderId)
        {
            receiverId = chat.UserId;
        }
        else
        {
            return Forbid();
        }

        var messageId = await _service.SendMessageAsync(
            request.MessageBody,
            senderId,
            receiverId,
            chatId);

        return Ok(new { Id = messageId });
    }

    // 8. Get Messages
    [HttpGet("{chatId:int}/messages")]
    public async Task<IActionResult> GetMessages(int chatId)
    {
        if (CurrentUserId is not int userId)
            return Unauthorized();

        var chat = await _service.GetChatByIdAsync(chatId);

        if (chat is null)
            return NotFound();

        if (chat.UserId != userId && chat.SupportId != userId)
            return Forbid();

        var messages = await _service.GetMessagesAsync(chatId);

        return Ok(messages);
    }

    // 9. Mark Messages As Read
    [HttpPut("{chatId:int}/read")]
    public async Task<IActionResult> MarkAsRead(int chatId)
    {
        if (CurrentUserId is not int userId)
            return Unauthorized();

        var rowsAffected = await _service.MarkAsReadAsync(chatId, userId);

        return Ok(new { RowsAffected = rowsAffected });
    }
}
