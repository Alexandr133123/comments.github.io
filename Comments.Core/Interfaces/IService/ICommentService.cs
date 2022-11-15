using Comments.Core.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Comments.Core.Interfaces.IService
{
    public interface ICommentService
    {
        CommentsResponseDTO GetComments(int pageNumber);
        void WriteComment(CommentDTO comment, List<IFormFile> uploadedFiles);

    }
}
