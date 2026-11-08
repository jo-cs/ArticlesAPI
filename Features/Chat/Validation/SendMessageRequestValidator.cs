using ArticlesAPI.Features.Chat.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Chat.Validation;

public class SendMessageRequestValidator : AbstractValidator<SendMessageRequest>
{
    public SendMessageRequestValidator()
    {
        RuleFor(request => request.MessageBody).NotEmpty();
    }
}
