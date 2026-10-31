using AutoMapper;
using ArticlesAPI.Features.Users.DTOs;
using ArticlesAPI.Features.Users.Models;

namespace ArticlesAPI.Features.Users.Mappings;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UserResponseDto>();
    }
}