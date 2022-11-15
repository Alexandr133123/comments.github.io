namespace Comments.Infrastructure.Models
{
    public class FileStorage
    {
        public int FileId { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public string FileData { get; set; }
    }
}
