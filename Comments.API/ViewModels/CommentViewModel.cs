using Comments.Core.DTOs;

namespace Comments.API.ViewModels
{
    public class CommentViewModel
    {
        public int? CommentId { get; set; }
        public int? HeadCommentId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CommentText { get; set; }  
        public List<CommentViewModel>? Answers { get; set; }
        public List<FileStorageDTO>? Files { get; set; }

    }
}
