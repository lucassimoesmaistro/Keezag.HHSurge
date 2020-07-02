using Keezag.HHSurge.Application.Model;
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

        Task<User> Add(UserModel userModel);
        Task<bool> Update(User user);
        Task<bool> Delete(Guid userId);

        Task<UserProfile> AddProfile(UserProfile profile);
        Task<bool> UpdateProfile(UserProfile profile);
        Task<bool> ChangeProfileType(UserProfile profile, ProfileType newProfileType);
        Task<bool> DeleteProfile(Guid profileId);

    }
}
