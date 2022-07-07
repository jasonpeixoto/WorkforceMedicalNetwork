// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////


using System;

namespace WorkforceMedicalNetwork.Api.Utils
{
    public static class Secure
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(this string content)
        {
            string final = "";
            if ((content == null) || (content == "")) return "";
            try
            {
                final = Crypto.EncryptString(content);
            } catch (Exception ex) { }
            return final;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Decrypt(this string content)
        {
            string final = "";
            if ((content == null) || (content == ""))  return "";
            try
            {
                final = Crypto.DecryptString(content);
            }
            catch (Exception ex) { }
            return final;
        }
    }
}

