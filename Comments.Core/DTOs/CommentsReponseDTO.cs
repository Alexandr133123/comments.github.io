using System.Collections.Generic;

namespace Comments.Core.DTOs
{
    public class CommentsResponseDTO
    {
        public List<CommentDTO> Comments { get; set; }
        public int TotalCount { get; set; }
    }
}
