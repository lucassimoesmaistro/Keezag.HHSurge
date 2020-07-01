using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keezag.HHSurge.Application
{
    public interface IUserApplication : IDisposable
    {
        Task<User> Get(User user);
        Task<User> GetUserAndProfileByType(User user, ProfileType type);
        Task<IEnumerable<User>> GetAll();

        Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(Guid userId);

        Task<bool> AddProfile(UserProfile profile);
        Task<bool> UpdateProfile(UserProfile profile);
        Task<bool> ChangeProfileType(UserProfile profile, ProfileType newProfileType);
        Task<bool> DeleteProfile(Guid profileId);

    }
}
