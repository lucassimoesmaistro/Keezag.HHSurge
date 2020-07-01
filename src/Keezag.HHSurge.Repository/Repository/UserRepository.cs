using Keezag.Common.Data;
using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Keezag.HHSurge.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HHSurgeDbContext _db;

        public UserRepository(HHSurgeDbContext context)
        {
            _db = context;
        }

        public IUnitOfWork UnitOfWork => _db;

        public void Add(User user)
        {
            _db.User.Add(user);
        }

        public void Add(UserProfile profile)
        {
            _db.Profile.Update(profile);
        }
        
        public void Delete(User user)
        {
            _db.User.Remove(user);
        }

        public void Delete(UserProfile profile)
        {
            _db.Profile.Remove(profile);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public Task<User> Get(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(User user, ProfileType type)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            _db.User.Update(user);
        }

        public void Update(UserProfile profile)
        {
            _db.Profile.Update(profile);
        }
    }
}
