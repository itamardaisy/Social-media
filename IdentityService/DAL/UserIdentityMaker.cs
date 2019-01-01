using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserIdentityMaker
    {
        private readonly AmazonDynamoDBClient _client;
        public UserIdentityMaker()
        {
            _client = new AmazonDynamoDBClient();

        }

        public List<UserIdentity> UserIdentities
        {
            get
            {
                return new List<UserIdentity>
                {
                    new UserIdentity
                    {
                        FullName = "The Godfather",
                        Age = 1972 ,
                        Address = "tel aviv",
                        WorkAddress = "england"
                    },

                    new UserIdentity
                    {
                        FullName = "Itamaer Daisy",
                        Age = 24 ,
                        Address = "raanana",
                        WorkAddress = "sela"
                    },
                    new UserIdentity
                    {
                        FullName = "omer cohen",
                        Age = 24 ,
                        Address = "bet shan",
                        WorkAddress = "amazon"
                    },

                };
            }
        }
        public void Init()
        {
            List<string> currentTables = _client.ListTables().TableNames;
            if (!currentTables.Contains("UserIdentity"))
            {
                var createTableRequest = new CreateTableRequest
                {
                    TableName = "UserIdentity",
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 1,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "FullName",
                            KeyType = "HASH"
                        },
                        new KeySchemaElement
                        {
                            AttributeName = "Age",
                            KeyType = "RANGE"
                        },
                    },
                    AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "FullName",AttributeType = "S"
                        },
                        new AttributeDefinition()
                        {
                            AttributeName = "Age",AttributeType = "N"
                        }
                    }
                };

                CreateTableResponse createTableResponse = _client.CreateTable(createTableRequest);

                while (createTableResponse.TableDescription.TableStatus != "ACTIVE")
                {
                    System.Threading.Thread.Sleep(5000);
                }
            }

        }
    }
}
