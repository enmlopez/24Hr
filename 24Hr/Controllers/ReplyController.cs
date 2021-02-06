using _24Hr.Models;
using _24Hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _24Hr.Controllers
{
    
    
        [Authorize]
        public class ReplyController : ApiController
        {
            private ReplyService CreateReplyService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var replyService = new ReplyService(userId);
                return replyService;
            }
            public IHttpActionResult Get()
            {
                ReplyService replyService = CreateReplyService();
                var reply = replyService.GetNotes();
                return Ok(reply);
            }

        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }
        private ReplyService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new ReplyService(userId);
            return noteService;
        }
    }
    
}