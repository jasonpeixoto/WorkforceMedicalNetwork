using Moq;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.UnitTests
{
    public class LoginServiceMock : ILoginService
    {
        private readonly ILoginService _ILoginService;
        protected LoginResponseModel _LoginResponseModel;
        public Mock<ILoginService> Mock { get; set; }
        public bool WillSucceed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LoginServiceMock()
        {
            WillSucceed = true;
            Mock = new Mock<ILoginService>();

            Mock.Setup(vs => vs.Login(It.IsAny<LoginRequestModel>()))
                .Returns(() =>
                {
                    return Task.FromResult(_LoginResponseModel);
                })
                .Verifiable();

            _ILoginService = Mock.Object;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            _LoginResponseModel = await _ILoginService.Login(requestModel);
            return _LoginResponseModel;
        }
    }
}
