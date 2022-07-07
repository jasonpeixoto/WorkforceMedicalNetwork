// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace WorkforceMedicalNetwork.Api.Models
{
    public class RegisterRequestModel : BaseLocationRequestModel
    {
        [Required]
        public string fullName { get; set; }

        [Required]
        public string password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return  !string.IsNullOrEmpty(fullName) &&
                    !string.IsNullOrEmpty(email) &&
                    !string.IsNullOrEmpty(password);
        }
    }
}
