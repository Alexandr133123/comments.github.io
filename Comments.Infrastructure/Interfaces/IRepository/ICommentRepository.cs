using Comments.Infrastructure.Models;
using System.Collections.Generic;

namespace Comments.Infrastructure.Interfaces.IRepository
{
    public interface ICommentRepository
    {
        List<Comment> GetComments(int pageSize);
        void WriteComment(Comment comment);
    }
}
