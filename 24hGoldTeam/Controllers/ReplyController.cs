using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24hGoldTeam.Controllers
{
    public class ReplyController : ApiController
    {
        [Authorize]
        public class ReplyService CreateReplyService()
        {
            var replyId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(replyId);
            return replyService;
        }

        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var replies = noteService.GetReplies();
            return Ok(replies);
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

        public IHttpActionResult Get(reply id)
        {
            ReplyService replyService = CreateReplyService();
            var note = noteService.GetReplyById;
            return Ok(reply);
        }
    }
}
