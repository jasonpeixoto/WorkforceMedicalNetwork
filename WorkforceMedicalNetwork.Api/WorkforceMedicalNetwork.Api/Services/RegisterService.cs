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
            if ((requestModel == null) || requestModel.IsValid())
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

            // access DAL here

            return resultModel;
        }
    }
}
