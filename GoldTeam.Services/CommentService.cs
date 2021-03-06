using GoldTeam.Data;
using GoldTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate comment)
        {
            var entity = new Comment()
            {
                AuthorId = _userId,
                Text = comment.Text,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments.Where(a => a.AuthorId == _userId).Select(a => new CommentListItem
                {
                    CommentId = a.CommentId,
                    Text = a.Text
                });

                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(a => a.CommentId == id && a.AuthorId == _userId);
                return new CommentDetail
                {
                    CommentId = entity.CommentId,
                    Text = entity.Text
                };
            }
        }

        public bool UpdateComment(CommentEdit comment)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(a => a.AuthorId == _userId);

                entity.Text = comment.Text;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(c => c.CommentId == commentId && c.AuthorId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
