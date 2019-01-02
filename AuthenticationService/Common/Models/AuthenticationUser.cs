using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DynamoDBTable("AuthenticationTable")]
    public class AuthenticationUser
    {
        [DynamoDBHashKey]
        public string UserId { get; set; }

        [DynamoDBRangeKey]
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAvilable { get; set; }
    }
}
