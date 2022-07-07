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
    public class RegisterService : IRegisterService
    {
        public RegisterService()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public Task<RegisterResponseModel> Register(RegisterRequestModel requestModel)
        {
            if ((requestModel == null) || !requestModel.IsValid())
            {
                throw new ArgumentNullException(nameof(requestModel));
            }

            return RegisterInternalAsync(requestModel);
        }

        /// <summary>
        /// User: catester
        /// Pass: password
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        private async Task<RegisterResponseModel> RegisterInternalAsync(RegisterRequestModel requestModel)
        {
            var resultModel = new RegisterResponseModel();
            var userRepository = new UserRepository();

            if (!await userRepository.IsEmailExistAsync(requestModel.email))
            {
                // create user here
                await userRepository.CreateUserAsync(requestModel);

                // create location record
                await Utils.Utils.CreateLocationAsync(requestModel);

                // ok user created here
                resultModel.created = true;
                resultModel.authenticated = true;
                resultModel.token = requestModel.email.Encrypt();
            }
            else
            {
                resultModel.created = false;
                resultModel.errorCode = "Invalid";
            }
            return resultModel;
        }
    }
}
