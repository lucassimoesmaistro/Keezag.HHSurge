using Keezag.Common.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Keezag.HHSurge.Domain
{
    public interface IUserRepository : IRepository<User>
    {
        Task Add(User request);
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(User user);
        Task AddProfile(User user);
        Task UpdateProfile(User user);
        Task DeleteProfile(Guid userId);
        Task ChangeProfileType(User user);
        Task Update(User user);
        Task<User> Get(User user, ProfileType type);
        Task Delete(Guid userId);
    }
}
