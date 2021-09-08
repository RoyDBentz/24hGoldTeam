using GoldTeam.Data;
using GoldTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Services
{
    public class ReplyService
    {

        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate reply)
        {
            var entity =
                new Reply()
                {                   
                    Text = reply.Text,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        public IEnumerable<ReplyItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(r => r.AuthorId == _userId)
                        .Select(
                            r => 
                                new ReplyItem
                                {
                                    ReplyId = r.CommentId,
                                    Text = r.Text,
                                    CreatedUtc = r.CreatedUtc
                                }
                    );
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(r => r.CommentId == id && r.AuthorId == _userId);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.CommentId,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateReply(ReplyEdit reply)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(r => r.CommentId ==reply.CommentId && r.AuthorId == _userId);
               
                entity.Text = reply.Text;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(r => r.ReplyId == replyId && r.AuthorId == _userId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }

}
