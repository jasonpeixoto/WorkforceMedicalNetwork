// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////


namespace WorkforceMedicalNetwork.Api.Models
{
    public class LoginResponseModel
    {
        public bool authenticated { get; set; }
        public string token { get; set; }
        public string errorCode { get; set; }

        public LoginResponseModel()
        {
            errorCode = "";
        }
    }
}
