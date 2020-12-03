using System;
using System.Collections.Generic;
using System.Text;
using TheSocialMedia.Domain.AggregatesModel.ProfileAggregate;

namespace TheSocialMedia.Domain.AggregatesModel.PostAggregate
{
    public class PostProfile
    {
        public Guid Id { get; set; }
        public Post Post { get; set; }
        public Profile Publisher { get; set; }
    }
}
