using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DynamoDBTable("AnimalsInventory")]
    public class AuthenticationUser
    {
        [DynamoDBHashKey]
        public int UserId { get; set; }

        [DynamoDBRangeKey]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
