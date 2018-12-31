using Amazon.DynamoDBv2;
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
            var client = new AmazonDynamoDBClient();
            var table = Table.LoadTable(client, "AuthenticationTable");
            var item = new Document();

            item["UserId"] = user.UserId;
            item["Username"] = user.Username;
            item["Password"] = user.Password;

            table.PutItem(item);
        }
    }
}
