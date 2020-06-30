using System;
using Xunit;

namespace Keezag.HHSurge.UnitTests
{
    [Collection(nameof(UnitTestsCollection))]
    public class CrudTests
    {
        private readonly UnitTestsFixture _crudTestsFixture;

        public CrudTests(UnitTestsFixture crudTestsFixture)
        {
            _crudTestsFixture = crudTestsFixture;
        }

        [Fact(DisplayName = "New Valid User")]
        [Trait("Unit Tests", "Create a valid user")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var user = _crudTestsFixture.GenerateValidUser();

            // Act
            var result = user.IsValid();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, user.ValidationResult.Errors.Count);
        }
    }
}
