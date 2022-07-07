// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkforceMedicalNetwork.Api.Db.Tables
{
    public class BaseTbl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}

