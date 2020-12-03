using System;
using System.Collections.Generic;
using System.Text;

namespace TheSocialMedia.Domain.AggregatesModel.ProfileAggregate
{
    public interface IProfileRepository
    {
        //CRUD - Create, Read, Update and Delete

        public void Create(Profile profile);
        public IReadOnlyCollection<Profile> ReadAll();
        public void Update(Profile profile);
        public void Delete(Guid id);
    }
}
