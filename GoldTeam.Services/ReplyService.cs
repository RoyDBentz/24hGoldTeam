using GoldTeam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Services
{
    public class ReplyService
    {

        private readonly Guid _replyId;

        public ReplyService(Guid replyId)
        {
            _replyId = replyId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    ReplyId = replyId,
                    Text = model.Title,
                    Content = model.Text,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(r => r.ReplyId == _replyId)
                        .Select(
                            ref =>
                                new ReplyItem
                                {
                                    ReplyId = r.ReplyId,
                                    Text = r.Text,
                                    CreatedUtc = ref.CreatedUtc
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
                        .Single(r => r.ReplyId == id && r.RepliesId == _userId);
                return
                    new ReplyDetail
                    {
                        _replyId = entity.ReplyId,
                        Text = entity.Text,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

    }

}
