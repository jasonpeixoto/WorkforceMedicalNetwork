// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using MongoDB.Driver;
using WorkforceMedicalNetwork.Api.Db.Tables;
using WorkforceMedicalNetwork.Api.Utils;

namespace WorkforceMedicalNetwork.Api.Db.Repository
{
    public class UserRepository : BaseRepository<UserTbl>
    {
        public UserRepository() : base(Constants.UsersCollectionName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> IsEmailExistAsync(string email)
        {
            UserTbl record =  await Collection.Find(x => x.EmailAddress == email).FirstOrDefaultAsync();
            return ((record != null) && (record.EmailAddress == email));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> IsUserExistAsync(string email, string password)
        {
            UserTbl record = await Collection.Find(x => (x.EmailAddress == email) && (x.Password == password.Encrypt())).FirstOrDefaultAsync();
            return ((record != null) && (record.EmailAddress == email));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserTbl> CreateUserAsync(string fullName, string email, string password)
        {
            UserTbl userTbl = null;

            if (await IsEmailExistAsync(email) == false)
            {
                userTbl = new UserTbl()
                {
                    FullName = fullName,
                    EmailAddress = email,
                    Password = password.Encrypt()
                };

                // add to collection
                await CreateAsync(userTbl);

            }
            return userTbl;
        }

    }
}

