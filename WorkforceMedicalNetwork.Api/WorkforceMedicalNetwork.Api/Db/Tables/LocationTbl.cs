// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkforceMedicalNetwork.Api.Db.Tables
{
    public class LocationTbl : BaseTbl
    {
        
        [BsonElement("EmailAddress")]
        public string FullName { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("Latitude")]
        public double Latitude { get; set; }

        [BsonElement("Longitude")]
        public double Longitude { get; set; }
    }
}