using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
using WorkforceMedicalNetwork.Api.Controllers;
using WorkforceMedicalNetwork.Api.Models;
using WorkforceMedicalNetwork.Api.UnitTests.TestFramework;

namespace WorkforceMedicalNetwork.Api.UnitTests
{
    [Collection("UnitTests")]
    public class LoginControllerUnitTests : ControllerUnitTests<LoginServiceMock, LoginController>
    {
        public LoginControllerUnitTests()
        {
            _mockService = new LoginServiceMock();
            _controller = new LoginController(new NullLogger<LoginController>(), _mockService);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("emailAddress", "password")]
        [InlineData(TestConstants.EmailAddress, TestConstants.Password)]
        public async System.Threading.Tasks.Task Login_Tests(string emailAddress, string password)
        {
            LoginRequestModel requestModel = new LoginRequestModel()
            {
                emailAddress = emailAddress, 
                password = password,
                latitude = 0,
                longitude = 0
            };

            var verifyPassCodeResult = await _controller.Login(requestModel);

            Assert.NotNull(verifyPassCodeResult);

            // if all null also test passing a null object
            if ((emailAddress == null) && (password == null))
            {
                verifyPassCodeResult = await _controller.Login(null);
                Assert.NotNull(verifyPassCodeResult);
            }
        }

        [Theory]
        [InlineData()]
        public void Test_Constants()
        {
            Assert.Equal(TestConstants.StartingWebHostString, Constants.StartingWebHostString);
            Assert.Equal(TestConstants.HostTerminatedString, Constants.HostTerminatedString);
            Assert.Equal(TestConstants.EnvironmentVariableString, Constants.EnvironmentVariableString);
        }

    }
}
