using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DynamoDBTable("Identity")]
    public class UserIdentity
    {
        [DynamoDBHashKey]
        public string Email { get; set; }
        [DynamoDBRangeKey]
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
    }
}
