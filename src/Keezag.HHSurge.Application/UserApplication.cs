using Keezag.Common.Extensions;
using Keezag.HHSurge.Application.Model;
using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Keezag.HHSurge.Domain.User;

namespace Keezag.HHSurge.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public async Task<User> Add(UserModel userModel)
        {
            var user = UserFactory.NewUser(userModel.Name, userModel.Email);

            user.AddProfile(new UserProfile(userModel.Document, userModel.Address, userModel.Avatar, EnumExtension.Parse<ProfileType>(userModel.Type).Value));

            user.SetAsActive();

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.Commit();
            return user;
        }       

        public async Task<bool> Delete(Guid userId)
        {
            var user = await _userRepository.GetById(userId);
            _userRepository.Delete(user);
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

            _userRepository.Update(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<UserProfile> AddProfile(UserProfile profile)
        {
            _userRepository.Add(profile);
            await _userRepository.UnitOfWork.Commit();
            return profile;
        }

        public async Task<bool> UpdateProfile(UserProfile profile)
        {

            _userRepository.Update(profile);

            return await _userRepository.UnitOfWork.Commit();
        }
        
        public async Task<bool> DeleteProfile(Guid profileId)
        {
            //await _userRepository.Delete(profileId);
            //return await _userRepository.UnitOfWork.Commit();
            throw new NotImplementedException();
        }



        public void Dispose()
        {
            _userRepository?.Dispose();
        }

        public Task<bool> ChangeProfileType(UserProfile profile, ProfileType newProfileType)
        {
            throw new NotImplementedException();
        }
    }
}
