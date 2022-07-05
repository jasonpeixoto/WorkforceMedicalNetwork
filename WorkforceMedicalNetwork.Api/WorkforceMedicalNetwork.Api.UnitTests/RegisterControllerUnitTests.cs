using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
using WorkforceMedicalNetwork.Api.Controllers;
using WorkforceMedicalNetwork.Api.Models;
using WorkforceMedicalNetwork.Api.UnitTests.TestFramework;

namespace WorkforceMedicalNetwork.Api.UnitTests
{
    [Collection("UnitTests")]
    public class RegisterControllerUnitTests : ControllerUnitTests<RegisterServiceMock, RegisterController>
    {
        public RegisterControllerUnitTests()
        {
            _mockService = new RegisterServiceMock();
            _controller = new RegisterController(new NullLogger<RegisterController>(), _mockService);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("emailAddress", "fullName")]
        [InlineData(TestConstants.EmailAddress, TestConstants.Password)]
        public async System.Threading.Tasks.Task Login_Tests(string emailAddress, string fullName)
        {
            RegisterRequestModel requestModel = new RegisterRequestModel()
            {
                emailAddress = emailAddress,
                fullName = fullName,
                latitude = 0,
                longitude = 0
            };

            var verifyPassCodeResult = await _controller.Register(requestModel);

            Assert.NotNull(verifyPassCodeResult);

            // if all null also test passing a null object
            if ((emailAddress == null) && (fullName == null))
            {
                verifyPassCodeResult = await _controller.Register(null);
                Assert.NotNull(verifyPassCodeResult);
            }
        }

    }
}
