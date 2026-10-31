
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// NEW: نحتاج هذا النوع لاستقبال قائمة الصلاحيات
using System.Collections.Generic;

using ArticlesAPI.Features.Users.Models;
using Microsoft.IdentityModel.Tokens;

namespace ArticlesAPI.Infrastructure.Security;

public class JwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // CHANGED: أضفنا permissions لاستقبال صلاحيات المستخدم
    // التي سيتم جلبها من قاعدة البيانات في خدمة تسجيل الدخول
    public string GenerateToken(User user, IEnumerable<string> permissions)
    {
        var secretKey = _configuration["Jwt:Key"]
                        ?? throw new InvalidOperationException(
                            "JWT Key is not configured.");

        var issuer = _configuration["Jwt:Issuer"]
                     ?? throw new InvalidOperationException(
                         "JWT Issuer is not configured.");

        var audience = _configuration["Jwt:Audience"]
                       ?? throw new InvalidOperationException(
                           "JWT Audience is not configured.");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        // CHANGED: استخدمنا List<Claim> بدل المصفوفة
        // حتى نستطيع إضافة Claims الصلاحيات إليها لاحقًا
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, user.RoleName),

            new Claim(
                JwtRegisteredClaimNames.Sub,
                user.Id.ToString()),

            new Claim(
                JwtRegisteredClaimNames.Email,
                user.Email),

            new Claim(
                ClaimTypes.Name,
                user.FullName),

            new Claim(
                "roleId",
                user.RoleId.ToString()),

            new Claim(
                JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
        };

        // NEW: إضافة كل صلاحية إلى الـ JWT كـ Claim مستقلة
        // نوع الـ Claim هو "permission"، والقيمة هي اسم الصلاحية
        // مثل: Articles.Create أو Articles.Delete
        foreach (var permission in permissions)
        {
            claims.Add(new Claim("permission", permission));
        }

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,

            // CHANGED: تمرير القائمة التي تحتوي على الدور والصلاحيات
            claims: claims,

            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
