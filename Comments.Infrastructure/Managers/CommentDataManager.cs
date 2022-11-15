using Comments.Infrastructure.DbContexts;
using System.Collections.Generic;
using Comments.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comments.Infrastructure.SqlScripts
{
    public class CommentDataManager
    {
        public List<Comment> BuildCommentAnswersTree(IEnumerable<Comment> comments)
        {

            List<IGrouping<int?, Comment>> groupedComments = comments.OrderBy(i => i.CommentId).GroupBy(i => i.HeadCommentId).ToList();
            List<Comment> headComments = groupedComments.FirstOrDefault(g => g.Key == null).OrderBy(headComment => headComment.CommentId).ToList();

            if (headComments.Count > 0)
            {
                Dictionary<int?, List<Comment>> dict = groupedComments.Where(g => g.Key != null).ToDictionary(g => g.Key, g => g.ToList());
                for (int i = 0; i < headComments.Count; i++)
                {
                    AddAnswer(headComments[i], dict);
                }
            }

            return headComments;
        }
        private void AddAnswer(Comment comment, Dictionary<int?, List<Comment>> answers)
        {

            if (answers.ContainsKey(comment.CommentId))
            {
                comment.Answers = answers[comment.CommentId];

                for (int i = 0; i < comment.Answers.Count; i++)
                    AddAnswer(comment.Answers[i], answers);
            }
            else
            {
                comment.Answers = new List<Comment>();
            }
        }

    }
}
