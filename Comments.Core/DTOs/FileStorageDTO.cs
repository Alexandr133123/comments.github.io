using Comments.Common.Enums;
using Comments.Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace Comments.Core.DTOs
{
    public class FileStorageDTO
    {
        public int FileId { get; set; }
        public string FileData { get; set; }
    }
}
