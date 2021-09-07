using GoldTeam.Data;
using GoldTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate post)
        {
            var entity = new Post()
            {
                AuthorId = _userId,
                Title = post.Title,
                Text = post.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Where(a => a.AuthorId == _userId).Select(a => new PostListItem
                {
                    Id = a.Id,
                    Title = a.Title
                });

                return query.ToArray();
            }
        }

        public PostDetails GetPostById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(a => a.Id == id && a.AuthorId == _userId);
                return new PostDetails
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Text = entity.Text
                };
            }
        }

        public bool UpdatePost(PostEdit post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(a =>  a.AuthorId == _userId);

                entity.Title = post.Title;
                entity.Text = post.Text;

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
