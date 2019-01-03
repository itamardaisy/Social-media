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
                        Email = "the@g.com",
                        FirstName = "The Godfather",
                        LastName = "ggg",
                        Age = 1972 ,
                        Address = "tel aviv",
                        WorkAddress = "england"
                    },

                    new UserIdentity
                    {
                        Email = "it@g.com",
                        FirstName = "Itamaer Daisy",
                        LastName = "Dfsdg",
                        Age = 24 ,
                        Address = "raanana",
                        WorkAddress = "sela"
                    },
                    new UserIdentity
                    {
                        Email = "omer@g.com",
                        FirstName = "omer cohen",
                        LastName = "fdsgs",
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
            if (!currentTables.Contains("Identity"))
            {
                var createTableRequest = new CreateTableRequest
                {
                    TableName = "Identity",
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 1,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Email",
                            KeyType = "HASH"
                        },
                        new KeySchemaElement
                        {
                            AttributeName = "FullName",
                            KeyType = "Range"
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "Email",AttributeType = "S"
                        },
                        new AttributeDefinition()
                        {
                            AttributeName = "Range", AttributeType = "S"
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
