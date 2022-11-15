using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Comments.Core.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public int? HeadCommentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentText { get; set; }
        public UserDTO User { get; set; }
        public List<CommentDTO> Answers { get; set; }
        public List<FileStorageDTO> Files { get; set; }

    }
}
