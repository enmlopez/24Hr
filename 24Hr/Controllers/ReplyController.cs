using _24Hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _24Hr.Controllers
{
    public class ReplyController
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
                ReplyService noteService = ReplyNoteService();
                var notes = noteService.GetNotes();
                return Ok(notes);
            }
        }
    }
}