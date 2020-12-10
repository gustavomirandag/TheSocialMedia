using System;
using System.Collections.Generic;
using System.Text;

namespace TheSocialMedia.Domain.AggregatesModel.ProfileAggregate
{
    public interface IProfileRepository
    {
        //CRUD - Create, Read, Update and Delete

        public int Create(Profile profile);
        public IReadOnlyCollection<Profile> ReadAll();
        public Profile Read(Guid id);
        public int Update(Profile profile);
        public int Delete(Guid id);
    }
}
