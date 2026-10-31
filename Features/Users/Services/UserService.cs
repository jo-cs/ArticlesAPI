
using AutoMapper;
using ArticlesAPI.Features.Users.DTOs;
using ArticlesAPI.Features.Users.Models;
using ArticlesAPI.Features.Users.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ArticlesAPI.Features.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(
        IUserRepository userRepository,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<int> CreateUserAsync(CreateUserDto dto)
    {
        var existingUser =
            await _userRepository.GetUserByEmailAsync(dto.Email);

        if (existingUser is not null)
        {
            throw new InvalidOperationException(
                "A user with this email already exists.");
        }

        var user = _mapper.Map<User>(dto);

        user.HashPassword =
            _passwordHasher.HashPassword(user, dto.Password);

        return await _userRepository.CreateUserAsync(user);
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user is null)
        {
            return null;
        }

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync(
        UserFilterDto filter)
    {
        if (filter.PageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(filter.PageNumber),
                "PageNumber must be greater than zero.");
        }

        if (filter.PageSize < 1 || filter.PageSize > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(filter.PageSize),
                "PageSize must be between 1 and 100.");
        }

        if (filter.RoleId < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(filter.RoleId),
                "RoleId cannot be negative.");
        }

        var users = await _userRepository.GetAllUsersAsync();

        var query = users.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
        {
            query = query.Where(user =>
                user.FullName.Contains(
                    filter.SearchTerm,
                    StringComparison.OrdinalIgnoreCase)
                ||
                user.Email.Contains(
                    filter.SearchTerm,
                    StringComparison.OrdinalIgnoreCase));
        }

        if (filter.RoleId > 0)
        {
            query = query.Where(user =>
                user.RoleId == filter.RoleId);
        }

        var result = query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToList();

        return _mapper.Map<IEnumerable<UserResponseDto>>(result);
    }

    public async Task<bool> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user is null)
        {
            return false;
        }

        var existingUser =
            await _userRepository.GetUserByEmailAsync(dto.Email);

        if (existingUser is not null && existingUser.Id != id)
        {
            throw new InvalidOperationException(
                "A user with this email already exists.");
        }

        _mapper.Map(dto, user);

        return await _userRepository.UpdateUserAsync(user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
}
