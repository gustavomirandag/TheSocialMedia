using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSocialMedia.Domain.AggregatesModel.PostAggregate;
using TheSocialMedia.Infra.DataAccess.Context;

namespace TheSocialMedia.Infra.DataAccess.Repositories
{
    public class PostSqlDbRepository : IPostRepository
    {
        private readonly TheSocialMediaContext _context;

        public PostSqlDbRepository(TheSocialMediaContext context)
        {
            _context = context;
        }

        public int Create(Post profile)
        {
            _context.Posts.Add(profile);
            return _context.SaveChanges();
        }

        public int Delete(Guid id)
        {
            Post post = _context.Posts.Find(id);
            _context.Posts.Remove(post);
            return _context.SaveChanges();
        }

        public Post Read(Guid id)
        {
            Post post = _context.Posts.Find(id);
            return post;
        }

        public IReadOnlyCollection<Post> ReadAll()
        {
            return _context.Posts.ToList();
        }

        public int Update(Post profile)
        {
            _context.Update(profile);
            return _context.SaveChanges();
            
        }
    }
}
