using AutoMapper;
using Comments.Core.DTOs;
using Comments.Infrastructure.Models;

namespace Comments.API.Mappings
{
    public class FileStorageProfile : Profile
    {
        public FileStorageProfile()
        {
            CreateMap<FileStorage, FileStorageDTO>();
            CreateMap<FileStorageDTO, FileStorageDTO>();

        }
    }
}
