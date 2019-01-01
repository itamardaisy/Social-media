using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AuthenticationRepositories : IAuthenticationRepositories
    {
        /// <summary>
        /// Add the AuthenticationUser after checking the user validatioon with class validation
        /// </summary>
        /// <param name="user"> The Added User </param>
        public void AddUserToDatabase(AuthenticationUser user)
        {
            DynamoDBContextConfig contextConfig = new DynamoDBContextConfig
            {
                Conversion = DynamoDBEntryConversion.V2,
                ConsistentRead = true
            };

            using (var context = new DynamoDBContext(contextConfig))
            {
                context.Save(user);
            }
        }
    }
}
