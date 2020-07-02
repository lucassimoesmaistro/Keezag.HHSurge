using Keezag.HHSurge.Application.Model;
using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keezag.HHSurge.Application
{
    public interface IUserApplication : IDisposable
    {
        Task<User> GetById(Guid id);
        Task<IEnumerable<User>> GetAll();

        Task<User> Add(UserModel userModel);
        Task<User> Update(UserModel user);
        Task<bool> Delete(Guid userId);
        Task<User> ChangeProfileType(Guid userId, string profile, string newprofile);
    }
}
