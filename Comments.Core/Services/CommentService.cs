using AutoMapper;
using Comments.Core.DTOs;
using Comments.Core.Interfaces.IService;
using Comments.Infrastructure.Interfaces.IRepository;
using Comments.Infrastructure.Models;
using Comments.Core.Managers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Comments.Common.Enums;

namespace Comments.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly FileStorageFormatManager fileStorageFormatManager;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserService userService, FileStorageFormatManager fileStorageFormatManager)
        {
            this.commentRepository = commentRepository;
            this.userService = userService;
            this.mapper = mapper;
            this.userService = userService;
            this.fileStorageFormatManager = fileStorageFormatManager;
        }

        public CommentsResponseDTO GetComments(int pageNumber)
        {
            List<CommentDTO> commentsDTO = mapper.Map<List<CommentDTO>>(commentRepository.GetComments(pageNumber));       
                        
            int pageSize = (int)CommentsPagination.PageSize;

            int totalCount = commentsDTO.Count;
            commentsDTO = commentsDTO
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();

            return new CommentsResponseDTO() { Comments = commentsDTO, TotalCount = totalCount};
        }

        public CommentDTO WriteComment(CommentDTO commentDTO, List<IFormFile> uploadedFiles)
        {
            int? userId = userService.GetUserIdByEmail(commentDTO.User.Email);

            if (userId.HasValue)
            {
                commentDTO.User.UserId = userId.Value;
                if (!String.IsNullOrEmpty(commentDTO.User.HomePage) && !commentDTO.User.HomePage.Contains($"http://"))
                {
                    commentDTO.User.HomePage = "http://" + commentDTO.User.HomePage;
                }
            }

            Comment comment = mapper.Map<Comment>(commentDTO);
            comment.CreatedDate = DateTime.Now;

            if (uploadedFiles.Count > 0)
            {
              comment.Files = fileStorageFormatManager.FormatFilesToBase64(uploadedFiles);
            }

            commentRepository.WriteComment(comment);

            return mapper.Map<CommentDTO>(comment);
        }
    }
}
