using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DynamoDBTable("UserIdentity")]
    public class UserIdentity
    {
        [DynamoDBHashKey]
        public string FullName { get; set; }
        [DynamoDBRangeKey]
        public int Age { get; set; }
        [DynamoDBProperty]
        public string Address { get; set; }
        public string WorkAddress { get; set; }
    }
}
