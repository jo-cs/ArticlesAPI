using ArticlesAPI.Features.Auth.DTOs;
using ArticlesAPI.Features.Auth.Services;
using ArticlesAPI.Features.AccessControl.Repositories;
using ArticlesAPI.Features.Users.Models;
using ArticlesAPI.Features.Users.Repositories;
using ArticlesAPI.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;

namespace ArticlesAPI.Features.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly IAccessControlRepository _accessControlRepository;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher,
        JwtTokenGenerator jwtTokenGenerator,
        IAccessControlRepository accessControlRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
        _accessControlRepository=accessControlRepository;
    }

    public async Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto dto)
    {
        var user = await _userRepository
            .GetUserByEmailAsync(dto.Email);

  
        if (user is null)
            return null;

 
        var passwordResult = _passwordHasher.VerifyHashedPassword(
            user,
            user.HashPassword,
            dto.Password
        );

   
        if (passwordResult == PasswordVerificationResult.Failed)
            return null;


// ADDED: جلب صلاحيات الدور الخاص بالمستخدم من قاعدة البيانات
        var permissions = await _accessControlRepository
            .GetPermissionsByRoleIdAsync(user.RoleId);

// CHANGED: تمرير المستخدم والصلاحيات إلى مولّد JWT
        var token = _jwtTokenGenerator.GenerateToken(user, permissions);


        return new LoginResponseDto
        {
            Token = token,
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            RoleId = user.RoleId
        };
    }
}