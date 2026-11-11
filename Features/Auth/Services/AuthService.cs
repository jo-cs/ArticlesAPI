using ArticlesAPI.Features.Auth.DTOs;
using ArticlesAPI.Features.AccessControl.Repositories;
using ArticlesAPI.Features.Users.Models;
using ArticlesAPI.Features.Users.Repositories;
using ArticlesAPI.Infrastructure.Security;
using ArticlesAPI.Shared.Results;
using Microsoft.AspNetCore.Identity;

namespace ArticlesAPI.Features.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly IAccessControlRepository _accessControlRepository;

    public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher,
        JwtTokenGenerator jwtTokenGenerator, IAccessControlRepository accessControlRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
        _accessControlRepository = accessControlRepository;
    }

    public async Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userRepository.GetUserByEmailAsync(dto.Email);
        if (user is null)
            return ServiceResult<LoginResponseDto>.Failure("Invalid email or password.", 401);

        var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.HashPassword, dto.Password);
        if (passwordResult == PasswordVerificationResult.Failed)
            return ServiceResult<LoginResponseDto>.Failure("Invalid email or password.", 401);

        var permissions = await _accessControlRepository.GetPermissionsByRoleIdAsync(user.RoleId);
        var token = _jwtTokenGenerator.GenerateToken(user, permissions);
        return ServiceResult<LoginResponseDto>.Ok(new LoginResponseDto
        {
            Token = token,
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            RoleId = user.RoleId
        });
    }
}
