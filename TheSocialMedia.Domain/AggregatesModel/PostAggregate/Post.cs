using System;
using System.Collections.Generic;
using System.Text;
using TheSocialMedia.Domain.AggregatesModel.ProfileAggregate;

namespace TheSocialMedia.Domain.AggregatesModel.PostAggregate
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}
