using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSocialMedia.Domain.AggregatesModel.ProfileAggregate;
using TheSocialMedia.Infra.DataAccess.Context;

namespace TheSocialMedia.Infra.DataAccess.Repositories
{
    public class ProfileSqlDbRepository : IProfileRepository
    {
        private readonly TheSocialMediaContext _context;

        public ProfileSqlDbRepository(TheSocialMediaContext context)
        {
            _context = context;
        }

        public int Create(Profile profile)
        {
            _context.Profiles.Add(profile);
            return _context.SaveChanges();
        }

        public int Delete(Guid id)
        {
            Profile p = _context.Profiles.Find(id);

            if (p == null)
                return 0; //Não encontrou ninguém

            _context.Profiles.Remove(p);

            return _context.SaveChanges();
        }

        public IReadOnlyCollection<Profile> ReadAll()
        {
            return _context.Profiles.ToList();
        }

        public Profile Read(Guid id)
        {
            return _context.Profiles.Find(id);
        }

        public int Update(Profile profile)
        {
            Profile p = _context.Profiles.Find(profile.Id);
            p.Name = profile.Name;
            p.Phone = profile.Phone;
            p.PhotoUrl = profile.PhotoUrl;
            _context.Update(p);
            return _context.SaveChanges();

        }
    }
}
