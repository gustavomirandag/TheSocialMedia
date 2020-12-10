using System;
using System.Collections.Generic;
using System.Text;

namespace TheSocialMedia.Domain.AggregatesModel.PostAggregate
{
    public interface IPostRepository
    {
        //CRUD - Create, Read, Update and Delete

        public int Create(Post profile);
        public IReadOnlyCollection<Post> ReadAll();
        public Post Read(Guid id);
        public int Update(Post profile);
        public int Delete(Guid id);
    }
}
