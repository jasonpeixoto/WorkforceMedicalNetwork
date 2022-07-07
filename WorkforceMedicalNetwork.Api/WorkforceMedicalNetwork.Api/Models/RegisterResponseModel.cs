// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;

namespace WorkforceMedicalNetwork.Api.Models
{
    public class RegisterResponseModel
    {
        public bool authenticated { get; set; }
        public bool created { get; set; }
        public string token { get; set; }
        public string errorCode { get; set; }

        public RegisterResponseModel()
        {
            errorCode = "";
        }
    }
}
