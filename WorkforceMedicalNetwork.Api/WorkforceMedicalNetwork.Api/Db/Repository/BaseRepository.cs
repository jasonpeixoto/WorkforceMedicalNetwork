// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WorkforceMedicalNetwork.Api.Db.Tables;

namespace WorkforceMedicalNetwork.Api.Db.Repository
{
    public class BaseRepository<T> where T : BaseTbl
    {
        private IMongoCollection<T> collection;
        public IMongoCollection<T> Collection => collection;

        public BaseRepository(string collectionName)
        {
            var mongoClient = new MongoClient(Constants.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Constants.MongoDatabaseName);
            collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync() =>
            await collection.Find(_ => true).ToListAsync();

        public async Task<T> GetAsync(string id) =>
            await collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T newRecord) =>
            await collection.InsertOneAsync(newRecord);

        public async Task UpdateAsync(string id, T updateRecord) =>
            await collection.ReplaceOneAsync(x => x.Id == id, updateRecord);

        public async Task RemoveAsync(string id) =>
            await collection.DeleteOneAsync(x => x.Id == id);
    }
}

