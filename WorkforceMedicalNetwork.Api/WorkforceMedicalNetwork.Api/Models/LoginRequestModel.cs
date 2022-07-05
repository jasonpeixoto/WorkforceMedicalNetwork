// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace WorkforceMedicalNetwork.Api.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string emailAddress { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public double latitude { get; set; }

        [Required]
        public double longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return  !string.IsNullOrEmpty(emailAddress) &&
                    !string.IsNullOrEmpty(password);
        }
    }
}
