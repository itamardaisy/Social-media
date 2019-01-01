using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
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
        /// <summary>
        /// Add the AuthenticationUser after checking the user validatioon with class validation
        /// </summary>
        /// <param name="user"> The Added User </param>
        public void AddUserToDatabase(AuthenticationUser user)
        {
            DynamoDBContextConfig contextConfig = new DynamoDBContextConfig
            {
                ConsistentRead = true,
                Conversion = DynamoDBEntryConversion.V2
            };

            using (var context = new DynamoDBContext(contextConfig))
            {
                context.Save(user);
            }
        }

        public void CheckIfUserExist
    }
}
