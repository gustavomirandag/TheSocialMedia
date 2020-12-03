using System;
using System.Collections.Generic;
using System.Text;

namespace TheSocialMedia.Domain.AggregatesModel.ProfileAggregate
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Phone { get; set; }
    }
}
