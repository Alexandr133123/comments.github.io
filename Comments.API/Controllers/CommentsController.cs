
using AutoMapper;
using Comments.API.ViewModels;
using Comments.Core.DTOs;
using Comments.Core.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Comments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentsController (ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetComments")]
        public IActionResult GetComments([FromQuery] int pageNumber)
        {
            CommentsResponse commentsResponse = mapper.Map<CommentsResponse>(commentService.GetComments(pageNumber));

            return Ok(commentsResponse);
        }

        [HttpPost]
        [Route("WriteComment")]
        public IActionResult WriteComment([FromForm] string commentString, List<IFormFile> uploadedFiles)
        {

            CommentViewModel comment = Newtonsoft.Json.JsonConvert.DeserializeObject<CommentViewModel>(commentString);

            try
            {
                commentService.WriteComment(mapper.Map<CommentDTO>(comment), uploadedFiles);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
