using System;
using System.Collections.Generic;
using System.Text;

namespace TheSocialMedia.Domain.AggregatesModel.ProfileAggregate
{
    public class ProfileService
    {
        //Functional Requirements: Use Cases

        private IProfileRepository _repository;

        public ProfileService(IProfileRepository repository)
        {
            _repository = repository;
        }

        public bool RegisterProfile(Profile profile)
        {
            if (String.IsNullOrEmpty(profile.Name))
                return false;

            profile.Id = Guid.NewGuid();
            var result = _repository.Create(profile);

            if (result == 0) //Significa que não conseguiu salvar por algum motivo
                return false;

            return true;
        }

        public IReadOnlyCollection<Profile> GetAllProfiles()
        {
            return _repository.ReadAll();
        }

        public Profile GetProfile(Guid id)
        {
            return _repository.Read(id);
        }

        public bool EditProfile(Profile profile)
        {
            var result = _repository.Update(profile);
            if (result == 0)
                return false;
            return true;
        }

        public bool DeleteProfile(Guid id)
        {
            var result = _repository.Delete(id);

            if (result == 0)
                return false;

            return true;
        }
    }
}
