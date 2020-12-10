using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TheSocialMedia.Domain.AggregatesModel.PostAggregate
{
    public class PostService
    {
        //Functional Requirements / Use Cases

        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void PublishPost(Post post)
        {
            _postRepository.Create(post);
        }

        public void EditPost(Post post)
        {
            _postRepository.Update(post);
        }

        public IReadOnlyCollection<Post> ReadAllPosts()
        {
            return _postRepository.ReadAll();
        }

        public Post ReadPost(Guid id)
        {
            return _postRepository.Read(id);
        }

        public void DeletePost(Guid id)
        {
            _postRepository.Delete(id);

        }
    }
}
