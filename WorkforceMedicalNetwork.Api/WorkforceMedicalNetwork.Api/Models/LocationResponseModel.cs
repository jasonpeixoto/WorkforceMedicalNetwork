﻿// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////


namespace WorkforceMedicalNetwork.Api.Models
{
    public class LocationResponseModel
    {
        public bool login { get; set; }
        public bool success { get; set; }
        public string errorCode { get; set; }

        public LocationResponseModel()
        {
            errorCode = "";
        }        
    }
}
