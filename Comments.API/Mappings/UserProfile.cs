using AutoMapper;
using Comments.API.ViewModels;
using Comments.Core.DTOs;
using Comments.Infrastructure.Models;

namespace Comments.Common.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
               
        }
    }
}
