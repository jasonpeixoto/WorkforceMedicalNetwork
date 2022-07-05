// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Models;

namespace WorkforceMedicalNetwork.Api.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            if ((requestModel == null) || requestModel.IsValid())
            {
                throw new ArgumentNullException(nameof(requestModel));
            }

            return LoginInternalAsync(requestModel);
        }

        /// <summary>
        /// User: catester
        /// Pass: password
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        private async Task<LoginResponseModel> LoginInternalAsync(LoginRequestModel requestModel)
        {
            var resultModel = new LoginResponseModel();

            // access DAL here

            return resultModel;
        }
    }
}
