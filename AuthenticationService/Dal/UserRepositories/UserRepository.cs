using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Common;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private DynamoDBContextConfig _contextConfig;
        private AmazonDynamoDBConfig _config;
        private AmazonDynamoDBClient _client;

        public UserRepository()
        {
            _contextConfig = new DynamoDBContextConfig
            {
                ConsistentRead = true,
                Conversion = DynamoDBEntryConversion.V2
            };
            _config = new AmazonDynamoDBConfig();
            _client = new AmazonDynamoDBClient(_config);
        }

        /// <summary>
        /// Add the AuthenticationUser after checking the user validatioon with class validation
        /// </summary>
        /// <param name="user"> The Added User </param>
        public void AddUserToDatabase(AuthenticationUser user)
        {
            using (var context = new DynamoDBContext(_contextConfig))
            {
                try{
                    context.Save(user);
                }
                catch (Exception ex){
                    throw new SaveToDatabaseException("A problrm accur the save to context operation", ex.InnerException);
                }
            }
        }

        public async void CheckIfUserExist(AuthenticationUser user)
        {
            using (var context = new DynamoDBContext(_contextConfig))
            {
                var userCheck = await context.LoadAsync(userCheck.UserId);
            }
        }
    }
}
