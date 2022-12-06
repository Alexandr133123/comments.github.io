using Comments.Infrastructure.DbContexts;
using Comments.Infrastructure.Interfaces.IRepository;
using Comments.Infrastructure.Models;
using Comments.Infrastructure.SqlScripts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Comments.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext context;
        private readonly CommentDataManager commentDataManager;

        public CommentRepository(ApplicationContext context, CommentDataManager commentDataManager)
        {
            this.context = context;
            this.commentDataManager = commentDataManager;
        }

        public List<Comment> GetComments(int pageNumber)
        {
            List<Comment> result = commentDataManager
                .BuildCommentAnswersTree(context.Comments
                .Include(c => c.User)
                .Include(c => c.Files)
                .AsNoTracking()
                .ToList());

            return result;
        }

        public void WriteComment(Comment comment)
        {
            context.Update(comment);
            context.SaveChanges();
        }
    }
}
