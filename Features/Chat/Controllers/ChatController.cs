using ArticlesAPI.Features.Chat.DTOs;
using ArticlesAPI.Features.Chat.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Chat.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatController : BaseController
{
    private readonly IChatService _service;
    public ChatController(IChatService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> CreateChat()
    {
        if (CurrentUserId is not int userId) return Unauthorized();
        var result = await _service.CreateChatAsync(userId);
        return result.Success ? Ok(new { Id = result.Data }) : Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetChatById(int id)
    {
        var result = await _service.GetChatByIdAsync(id);
        if (!result.Success) return Ok(result);
        var chat = result.Data!;
        if (CurrentUserId is not int currentUserId) return Unauthorized();
        var isOwner = chat.UserId == currentUserId;
        var isAssignedSupport = User.IsInRole("Support") && chat.SupportId == currentUserId;
        if (!isOwner && !isAssignedSupport) return Forbid();
        return Ok(result);
    }

    [HttpGet("my-chats")]
    public async Task<IActionResult> GetMyChats()
    {
        if (CurrentUserId is not int userId) return Unauthorized();
        return Ok(await _service.GetChatsByUserIdAsync(userId));
    }

    [HttpGet("unassigned")]
    [Authorize(Roles = "Support")]
    public async Task<IActionResult> GetUnassignedChats() => Ok(await _service.GetUnassignedChatsAsync());

    [HttpGet("my-assigned-chats")]
    [Authorize(Roles = "Support")]
    public async Task<IActionResult> GetMyAssignedChats()
    {
        if (CurrentUserId is not int supportId) return Unauthorized();
        return Ok(await _service.GetChatsBySupportIdAsync(supportId));
    }

    [HttpPatch("{chatId:int}/assign")]
    [Authorize(Roles = "Support")]
    public async Task<IActionResult> AssignSupport(int chatId)
    {
        if (CurrentUserId is not int supportId) return Unauthorized();
        return Ok(await _service.AssignSupportAsync(chatId, supportId));
    }

    [HttpPost("{chatId:int}/messages")]
    public async Task<IActionResult> SendMessage(int chatId, [FromBody] SendMessageRequest request)
    {
        if (CurrentUserId is not int senderId) return Unauthorized();
        var chatResult = await _service.GetChatByIdAsync(chatId);
        if (!chatResult.Success) return Ok(chatResult);
        var chat = chatResult.Data!;
        int receiverId;
        if (chat.UserId == senderId && chat.SupportId.HasValue) receiverId = chat.SupportId.Value;
        else if (chat.SupportId == senderId) receiverId = chat.UserId;
        else return Forbid();
        var result = await _service.SendMessageAsync(request.MessageBody, senderId, receiverId, chatId);
        return result.Success ? Ok(new { Id = result.Data }) : Ok(result);
    }

    [HttpGet("{chatId:int}/messages")]
    public async Task<IActionResult> GetMessages(int chatId)
    {
        if (CurrentUserId is not int userId) return Unauthorized();
        var chatResult = await _service.GetChatByIdAsync(chatId);
        if (!chatResult.Success) return Ok(chatResult);
        var chat = chatResult.Data!;
        if (chat.UserId != userId && chat.SupportId != userId) return Forbid();
        return Ok(await _service.GetMessagesAsync(chatId));
    }

    [HttpPut("{chatId:int}/read")]
    public async Task<IActionResult> MarkAsRead(int chatId)
    {
        if (CurrentUserId is not int userId) return Unauthorized();
        var result = await _service.MarkAsReadAsync(chatId, userId);
        return result.Success ? Ok(new { RowsAffected = result.Data }) : Ok(result);
    }
}
