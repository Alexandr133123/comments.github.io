namespace Comments.API.ViewModels
{
    public class CommentsResponse
    {
        public List<CommentViewModel> Comments { get; set; }
        public int TotalCount { get; set; }
    }
}
