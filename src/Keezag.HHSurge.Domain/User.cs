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

        private readonly List<Profile> _profiles;
        public IReadOnlyCollection<Profile> Profiles => _profiles;

        protected User() { }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new UserValidations().Validate(this);
            return ValidationResult.IsValid;
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
