using Keezag.Common.DomainObjects;
using System;

namespace Keezag.HHSurge.Domain
{
    public class UserProfile : Entity
    {
        public Guid? UserId { get; private set; }
        public string Document { get; private set; }

        public string Address { get; private set; }
        public string Avatar { get; private set; }

        public ProfileType Type { get; set; }
        public User User { get; set; }

        protected UserProfile() { }

        public UserProfile(string document, string address, string avatar, ProfileType type)
        {
            Document = document;
            Address = address;
            Avatar = avatar;
            Type = type;
        }

        public void ConnectToUser(Guid id)
        {
            UserId = id;
        }
    }
}