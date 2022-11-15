using AutoMapper;
using Comments.API.ViewModels;
using Comments.Core.DTOs;
using Comments.Core.Managers;
using Comments.Infrastructure.Models;

namespace Comments.API.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDTO, CommentViewModel>();
            CreateMap<CommentViewModel, CommentDTO>();
            CreateMap<CommentDTO, Comment>();                
            CreateMap<Comment, CommentDTO>();
        }
    }
}
