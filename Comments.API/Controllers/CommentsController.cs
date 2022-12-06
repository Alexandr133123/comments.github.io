
using AutoMapper;
using Comments.API.Hubs;
using Comments.API.ViewModels;
using Comments.Core.DTOs;
using Comments.Core.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Comments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly IHubContext<CommentsHub> commentsHub;

        public CommentsController (ICommentService commentService, IMapper mapper, IHubContext<CommentsHub> commentsHub)
        {
            this.commentService = commentService;
            this.mapper = mapper;
            this.commentsHub = commentsHub;
        }

        [HttpGet]
        [Route("GetComments")]
        public IActionResult GetComments([FromQuery] int pageNumber)
        {
            CommentsResponseDTO commentsResponse = commentService.GetComments(pageNumber);

            return Ok(commentsResponse);
        }

        [HttpPost]
        [Route("WriteComment")]
        public IActionResult WriteComment([FromForm] string commentString, List<IFormFile> uploadedFiles)
        {

            CommentViewModel comment = Newtonsoft.Json.JsonConvert.DeserializeObject<CommentViewModel>(commentString);

            try
            {
                comment = mapper.Map<CommentViewModel>(commentService.WriteComment(mapper.Map<CommentDTO>(comment), uploadedFiles));

                commentsHub.Clients.All.SendAsync("updateComments", comment);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
