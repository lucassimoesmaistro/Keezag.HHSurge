using Bogus;
using Bogus.DataSets;
using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Keezag.HHSurge.Domain.User;

namespace Keezag.HHSurge.UnitTests
{
    [CollectionDefinition(nameof(CrudTestsCollection))]
    public class CrudTestsCollection : ICollectionFixture<CrudTestsFixture>
    { }

    public class CrudTestsFixture : IDisposable
    {
        public User GenerateValidUser()
        {
            return GenerateUser(1).FirstOrDefault();
        }

        public IEnumerable<User> GenerateUser(int count)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var users = new Faker<User>("pt_BR")
                .CustomInstantiator(u => UserFactory.NewUser(
                    u.Name.FullName(genero),
                    ""))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(f.Person.FirstName, f.Person.LastName));

            return users.Generate(count);
        }

        public void Dispose()
        {
        }
    }
}
