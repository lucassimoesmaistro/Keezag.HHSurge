using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keezag.HHSurge.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       
        public async Task<bool> Add(User user)
        {
            if (!user.IsValid())
                return false;

            await _userRepository.Add(user);

            return await _userRepository.UnitOfWork.Commit();
        }       

        public async Task<bool> Delete(Guid userId)
        {
            await _userRepository.Delete(userId);
            return await _userRepository.UnitOfWork.Commit();
        }

       
        public async Task<User> Get(User user)
        {
            return await _userRepository.Get(user);
        }

        public async Task<User> GetUserAndProfileByType(User user, ProfileType type)
        {
            return await _userRepository.Get(user, type);
        }


        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<bool> Update(User user)
        {
            if (!user.IsValid())
                return false;

            await _userRepository.Update(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> AddProfile(User user)
        {
            if (!user.IsValid())
                return false;

            await _userRepository.AddProfile(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> UpdateProfile(User user)
        {
            if (!user.IsValid())
                return false;

            await _userRepository.UpdateProfile(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ChangeProfileType(User user, ProfileType newProfileType)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProfile(Guid profileId)
        {
            await _userRepository.DeleteProfile(profileId);
            return await _userRepository.UnitOfWork.Commit();
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
