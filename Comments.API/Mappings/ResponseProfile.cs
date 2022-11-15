using AutoMapper;
using Comments.API.ViewModels;
using Comments.Core.DTOs;

namespace Comments.API.Mappings
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<CommentsResponseDTO, CommentsResponse>();
        }
    }
}
