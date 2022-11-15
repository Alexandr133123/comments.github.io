using System;
using System.Collections.Generic;

namespace Comments.Infrastructure.Models
{
    public class Comment  
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public int? HeadCommentId { get; set; }
        public Comment HeadComment { get; set; }        
        public List<Comment> Answers { get; set; }        
        public ICollection<FileStorage> Files { get; set; }                 
    }
}
