namespace ArticlesAPI.Features.Authors.DTOs;
public class AuthorResponseDto
{
    public int Id { get; set; }
    public string LiteraryName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public int UserId { get; set; }
}
