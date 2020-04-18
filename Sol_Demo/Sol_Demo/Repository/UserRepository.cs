using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(UserModel userModel);

        Task<IEnumerable<UserModel>> GetUserDataAsync();

        Task<bool> UpdateUserAsync(UserModel userModel);

        Task<bool> DeleteUserAsync(UserModel userModel);
    }

    public class UserRepository : IUserRepository
    {

        private readonly ILiteDbClientProvider liteDbClientProvider;

        public UserRepository(ILiteDbClientProvider liteDbClientProvider)
        {
            this.liteDbClientProvider = liteDbClientProvider;
        }

       

        Task<bool> IUserRepository.AddUserAsync(UserModel userModel)
        {
            using (var db= this.liteDbClientProvider.GetLitDbConnection)
            {

                db
               ?.GetCollection<UserModel>("UserCollection")
               ?.Insert(userModel);

                return Task.FromResult<Boolean>(true);

            }
        }

        Task<IEnumerable<UserModel>> IUserRepository.GetUserDataAsync()
        {
            using (var db = this.liteDbClientProvider.GetLitDbConnection)
            {

                var data =
                     db
                ?.GetCollection<UserModel>("UserCollection")
                ?.Query()
                ?.ToList();

                return Task.FromResult<IEnumerable<UserModel>>(data);

            }
        }

        Task<bool> IUserRepository.UpdateUserAsync(UserModel userModel)
        {
            using (var db = this.liteDbClientProvider.GetLitDbConnection)
            {

                db
               ?.GetCollection<UserModel>("UserCollection")
               ?.Update(userModel);

                return Task.FromResult<Boolean>(true);

            }
        }

        public Task<bool> DeleteUserAsync(UserModel userModel)
        {
            using (var db = this.liteDbClientProvider.GetLitDbConnection)
            {

                db
               ?.GetCollection<UserModel>("UserCollection")
               ?.Delete(new LiteDB.BsonValue(userModel?.Id));

                return Task.FromResult<Boolean>(true);

            }
        }
    }
}
