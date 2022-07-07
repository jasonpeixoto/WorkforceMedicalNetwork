// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkforceMedicalNetwork.Api.Db.Tables
{
    public class UserTbl : BaseTbl
    {

        [BsonElement("FullName")]
        public string FullName { get; set; }

        [BsonElement("EmailAddress")]
        public string EmailAddress { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
    }
}

