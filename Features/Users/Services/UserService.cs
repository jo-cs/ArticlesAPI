using AutoMapper;
using ArticlesAPI.Features.Users.DTOs;
using ArticlesAPI.Features.Users.Models;
using ArticlesAPI.Features.Users.Repositories;
using ArticlesAPI.Shared.Results;
using Microsoft.AspNetCore.Identity;

namespace ArticlesAPI.Features.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<ServiceResult<int>> CreateUserAsync(CreateUserDto dto)
    {
        if (await _userRepository.GetUserByEmailAsync(dto.Email) is not null)
            return ServiceResult<int>.Failure("A user with this email already exists.", 409);

        var user = _mapper.Map<User>(dto);
        user.HashPassword = _passwordHasher.HashPassword(user, dto.Password);
        var id = await _userRepository.CreateUserAsync(user);
        return ServiceResult<int>.Ok(id);
    }

    public async Task<ServiceResult<UserResponseDto>> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user is null
            ? ServiceResult<UserResponseDto>.Failure("User not found.", 404)
            : ServiceResult<UserResponseDto>.Ok(_mapper.Map<UserResponseDto>(user));
    }

    public async Task<ServiceResult<IEnumerable<UserResponseDto>>> GetAllUsersAsync(UserFilterDto filter)
    {
        if (filter.PageNumber < 1)
            return ServiceResult<IEnumerable<UserResponseDto>>.Failure("PageNumber must be greater than zero.");
        if (filter.PageSize < 1 || filter.PageSize > 100)
            return ServiceResult<IEnumerable<UserResponseDto>>.Failure("PageSize must be between 1 and 100.");
        if (filter.RoleId < 0)
            return ServiceResult<IEnumerable<UserResponseDto>>.Failure("RoleId cannot be negative.");

        var users = await _userRepository.GetAllUsersAsync();
        var query = users.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            query = query.Where(user => user.FullName.Contains(filter.SearchTerm, StringComparison.OrdinalIgnoreCase)
                || user.Email.Contains(filter.SearchTerm, StringComparison.OrdinalIgnoreCase));
        if (filter.RoleId > 0)
            query = query.Where(user => user.RoleId == filter.RoleId);
        var result = query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
        return ServiceResult<IEnumerable<UserResponseDto>>.Ok(_mapper.Map<IEnumerable<UserResponseDto>>(result));
    }

    public async Task<ServiceResult<bool>> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user is null)
            return ServiceResult<bool>.Failure("User not found.", 404);
        var existingUser = await _userRepository.GetUserByEmailAsync(dto.Email);
        if (existingUser is not null && existingUser.Id != id)
            return ServiceResult<bool>.Failure("A user with this email already exists.", 409);
        _mapper.Map(dto, user);
        return await _userRepository.UpdateUserAsync(user)
            ? ServiceResult<bool>.Ok(true)
            : ServiceResult<bool>.Failure("User update failed.");
    }

    public async Task<ServiceResult<bool>> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id)
            ? ServiceResult<bool>.Ok(true)
            : ServiceResult<bool>.Failure("User not found.", 404);
    }
}
