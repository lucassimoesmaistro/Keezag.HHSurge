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

       
        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }


        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> Update(UserModel userModel)
        {
            User user = await _userRepository.GetById(userModel.UserId);

            user.ChangeNameOrEmail(userModel.Name, userModel.Email);

            _userRepository.Update(user);

            await _userRepository.UnitOfWork.Commit();
            return user;
        }

        public async Task<User> ChangeProfileType(Guid userId, string profile, string newprofile)
        {
            User user = await _userRepository.GetById(userId);
            user.ChangeProfileType(profile, newprofile);
            _userRepository.Update(user);
            await _userRepository.UnitOfWork.Commit();
            return user;
        }



        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
