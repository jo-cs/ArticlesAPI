namespace ArticlesAPI.Infrastructure.Errors;

public static class SqlErrorMapper
{
    public static (int StatusCode, string Message) Map(int errorNumber)
    {
        return errorNumber switch
        {
            //Articles
            50001 => (404, "Category does not exist."),
            50002 => (404, "Author does not exist."),
            50003 => (404, "Article does not exist."),
            
            //Chat
            50101 => (404, "User does not exist."),
            50102 => (404, "Chat does not exist."),
            50103 => (403, "User is not a Support employee."),
            50104 => (409, "Chat has already been assigned."),
            50105 => (400, "Message body cannot be empty."),
            50106 => (400, "Sender or receiver is not assigned to this chat."),
            50107 => (403, "User is not assigned to this chat."),

            _ => (500, "An unexpected database error occurred.")
        };
    }
}