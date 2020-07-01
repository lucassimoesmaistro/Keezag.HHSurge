using Keezag.Common.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Keezag.HHSurge.Domain
{
    public interface IUserRepository : IRepository<User>
    {
        void Add(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(User user);
        Task<User> GetById(Guid userId);
        void Add(UserProfile profile);
        void Update(UserProfile profile);
        void Delete(UserProfile profile);
        void Update(User user);
        Task<User> Get(User user, ProfileType type);
        void Delete(User user);
    }
}
