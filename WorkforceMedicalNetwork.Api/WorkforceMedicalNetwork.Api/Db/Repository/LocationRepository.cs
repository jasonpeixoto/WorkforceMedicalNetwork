// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using WorkforceMedicalNetwork.Api.Db.Tables;

namespace WorkforceMedicalNetwork.Api.Db.Repository
{
    public class LocationRepository : BaseRepository<LocationTbl>
    {
        public LocationRepository() : base(Constants.LocationsCollectionName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="date"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<LocationTbl> CreateLocationAsync(string email, string date, double latitude, double longitude)
        {
            LocationTbl record = new LocationTbl() {
                    FullName = email,
                    Date = date,
                    Latitude = latitude,
                    Longitude = longitude
             };

            // add to collection
            await CreateAsync(record);

            return record;
        }
    }
}