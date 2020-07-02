using Keezag.HHSurge.Application;
using Keezag.HHSurge.Domain;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Keezag.HHSurge.UnitTests
{
    [Collection(nameof(CrudTestsCollection))]
    public class CrudTests
    {
        private readonly CrudTestsFixture _crudTestsFixture;

        public CrudTests(CrudTestsFixture crudTestsFixture)
        {
            _crudTestsFixture = crudTestsFixture;
        }

        [Fact(DisplayName = "New Valid User")]
        [Trait("Domain Tests", "Create a valid user")]
        public void ShouldCreateValidUser()
        {
            // Arrange
            var user = _crudTestsFixture.GenerateValidUser();

            // Act
            var result = user.IsValid();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, user.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Get User")]
        [Trait("Application Tests", "Create a valid user")]
        public void ShouldGetUser()
        {
            // Arrange
            var mocker = new AutoMocker();
            var user = _crudTestsFixture.GenerateValidUser();
            var userApplication = mocker.CreateInstance<UserApplication>();

            mocker.GetMock<IUserRepository>().Setup(c => c.GetById(user.Id))
                .Returns(Task.FromResult(user));

            // Act
            var result = userApplication.GetById(user.Id);

            // Assert 
            mocker.GetMock<IUserRepository>().Verify(r => r.GetById(user.Id), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(user.Id.ToString(), result.Result.Id.ToString());
        }        
    }

    
}
