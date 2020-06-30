using Keezag.Common.DomainObjects;

namespace Keezag.HHSurge.Domain
{
    public class Profile : Entity
    {
        public string Document { get; private set; }

        public string Address { get; private set; }
        public string Avatar { get; private set; }

        public ProfileType Type { get; set; }

        protected Profile() { }

        public Profile(string document, string address, string avatar, ProfileType type)
        {
            Document = document;
            Address = address;
            Avatar = avatar;
            Type = type;
        }
    }
}