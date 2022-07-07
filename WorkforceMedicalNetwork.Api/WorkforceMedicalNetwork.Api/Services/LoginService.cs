// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Db.Repository;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Models;
using WorkforceMedicalNetwork.Api.Utils;

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
            if ((requestModel == null) || !requestModel.IsValid())
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
            var userRepository = new UserRepository();

            if(await userRepository.IsUserExistAsync(requestModel.email, requestModel.password))
            {
                // create location record
                await Utils.Utils.CreateLocationAsync(requestModel);

                resultModel.authenticated = true;
                resultModel.token = requestModel.email.Encrypt();
            } else
            {
                resultModel.authenticated = false;
                resultModel.errorCode = "Invalid";
            }
            return resultModel;
        }
    }
}
