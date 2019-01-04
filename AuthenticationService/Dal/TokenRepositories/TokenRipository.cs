using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Common;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.TokenRepositories
{
    public class TokenRipository : ITokenRepository
    {
        private readonly DynamoDBContextConfig _contextConfig;
        private readonly AmazonDynamoDBClient _dbclient;
        private readonly AmazonDynamoDBConfig _dbConfig;

        public TokenRipository()
        {
            _contextConfig = new DynamoDBContextConfig
            {
                ConsistentRead = true,
                Conversion = DynamoDBEntryConversion.V2
            };
            _dbConfig = new AmazonDynamoDBConfig();
            _dbclient = new AmazonDynamoDBClient(_dbConfig);
        }

        public string AddNewToken(AuthenticationUser user)
        {
            using(var context = new DynamoDBContext(_contextConfig))
            {
                Token token = new Token() { CreatedTime = DateTime.Now, IsValid = true, TokenId = TokenGenerator(), Email = user.Username };
                try
                {
                    context.Save(token);
                    return token.TokenId;
                }
                catch(Exception ex)
                {
                    throw new SaveToDatabaseException("A problrm during the save to context operation", ex.InnerException);
                }
            }
        }

        public async Task<string> ChangeUserToken(User user)
        {
            using (var context = new DynamoDBContext(_contextConfig))
            {
                var lastToken = await context.LoadAsync<Token>(user.TokenId);
                lastToken.IsValid = false;
                context.
            }
        }

        private string TokenGenerator()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
