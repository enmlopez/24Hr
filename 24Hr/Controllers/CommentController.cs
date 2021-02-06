using _24Hr.Models;
using _24Hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hr.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        
        
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }

         
        [HttpPost]
        public IHttpActionResult CreateComment(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCommentService();
            if (!service.CreateComment(comment))
            {
                return InternalServerError();
            }
            return Ok();
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            if(comments != null)
                return Ok(comments);
            return BadRequest("No comments available");
        }

        [HttpGet]
        public IHttpActionResult GetCommentById(int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            if (comment != null)
                return Ok(comment);
            return BadRequest("Could not find comment");
        }


        [HttpPut]
        public IHttpActionResult UpdateComment(CommentEdit newComment, int id)
        {
            CommentService commentService = CreateCommentService();
            var updated = commentService.UpdateComment(newComment, id);
            if (updated)
                return Ok();
            return BadRequest("Could not update comment");
        }

        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            CommentService commentService = CreateCommentService();
            var deleted = commentService.DeleteComment(id);
            if (deleted)
                return Ok();
            return BadRequest("Could not remove comment");
        }
    }
}
