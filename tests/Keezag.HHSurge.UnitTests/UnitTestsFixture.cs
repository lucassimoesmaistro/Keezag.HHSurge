using Bogus;
using Bogus.DataSets;
using Keezag.HHSurge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keezag.HHSurge.UnitTests
{
    [CollectionDefinition(nameof(UnitTestsCollection))]
    public class UnitTestsCollection : ICollectionFixture<UnitTestsFixture>
    { }

    public class UnitTestsFixture : IDisposable
    {
        public User GenerateValidUser()
        {
            return GenerateUser(1, true).FirstOrDefault();
        }

        public IEnumerable<User> GenerateUser(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var users = new Faker<User>("pt_BR")
                .CustomInstantiator(u => new User(
                    u.Name.FullName(genero),
                    ""))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(f.Person.FirstName, f.Person.LastName));

            return users.Generate(quantidade);
        }

        public void Dispose()
        {
        }
    }
}
