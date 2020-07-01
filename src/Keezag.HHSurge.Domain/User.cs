using FluentValidation;
using FluentValidation.Results;
using Keezag.Common.DomainObjects;
using System;
using System.Collections.Generic;

namespace Keezag.HHSurge.Domain
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public string Email { get; private set; }
        public UserStatus UserStatus { get; private set; }

        private readonly List<UserProfile> _profiles;
        public IReadOnlyCollection<UserProfile> Profiles => _profiles;

        protected User()
        {
            _profiles = new List<UserProfile>();
        }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            _profiles = new List<UserProfile>();
        }

        public override bool IsValid()
        {
            ValidationResult = new UserValidations().Validate(this);
            return ValidationResult.IsValid;
        }
                     
        public void AddProfile(UserProfile profile)
        {
            profile.ConnectToUser(Id);

            _profiles.Add(profile);
        }
        public static class UserFactory
        {
            public static User NewUser(string name, string email)
            {
                var user = new User
                {
                    Name = name,
                    Email = email
                };

                user.SetAsInactive();
                return user;
            }
        }

        public void SetAsInactive()
        {
            UserStatus = UserStatus.Inactive;
        }

        public void SetAsActive()
        {
            UserStatus = UserStatus.Active;
        }
    }
    public class UserValidations : AbstractValidator<User>
    {
        public UserValidations()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please fill the Name");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
