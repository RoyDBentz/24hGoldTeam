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
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                   
                    Text = model.Text,
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
                                    ReplyId = r.ReplyId,
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
                        .Single(r => r.ReplyId == id && r.AuthorId == _userId);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

    }

}
