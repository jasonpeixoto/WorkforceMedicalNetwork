// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace WorkforceMedicalNetwork.Api.Models
{
    public class LoginRequestModel : BaseLocationRequestModel
    {
        [Required]
        public string password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return  !string.IsNullOrEmpty(email) &&
                    !string.IsNullOrEmpty(password);
        }
    }
}
