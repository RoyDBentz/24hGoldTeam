using GoldTeam.Models;
using GoldTeam.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24hGoldTeam.Controllers
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

            public IHttpActionResult Get()
            {
                CommentService commentService = CreateCommentService();
                var comments = commentService.GetComments();
                return Ok(comments);
            }

            public IHttpActionResult Comment(CommentCreate comment)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateCommentService();

                if (!service.CreateComment(comment))
                    return InternalServerError();

                return Ok("You created new comment successfully!");
            }

            public IHttpActionResult Get(int id)
            {
                CommentService commentService = CreateCommentService();
                var comment = commentService.GetCommentById(id);
                return Ok(comment);
            }

            public IHttpActionResult Put(CommentEdit comment)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateCommentService();

                if (!service.UpdateComment(comment))
                    return InternalServerError();

                return Ok("You updated successfuly");
            }
        }
    }

