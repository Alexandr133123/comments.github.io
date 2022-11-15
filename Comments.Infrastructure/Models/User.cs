using System.Collections.Generic;

namespace Comments.Infrastructure.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string HomePage { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
