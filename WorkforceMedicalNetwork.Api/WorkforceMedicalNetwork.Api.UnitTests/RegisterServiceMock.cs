using Moq;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.UnitTests
{
    public class RegisterServiceMock : IRegisterService
    {
        private readonly IRegisterService _IRegisterService;
        protected RegisterResponseModel _RegisterResponseModel;
        public Mock<IRegisterService> Mock { get; set; }
        public bool WillSucceed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RegisterServiceMock()
        {
            WillSucceed = true;
            Mock = new Mock<IRegisterService>();

            Mock.Setup(vs => vs.Register(It.IsAny<RegisterRequestModel>()))
                .Returns(() =>
                {
                    return Task.FromResult(_RegisterResponseModel);
                })
                .Verifiable();

            _IRegisterService = Mock.Object;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<RegisterResponseModel> Register(RegisterRequestModel requestModel)
        {
            _RegisterResponseModel = await _IRegisterService.Register(requestModel);
            return _RegisterResponseModel;
        }
    }
}
