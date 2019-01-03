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

        public TokenRipository()
        {
            _contextConfig = new DynamoDBContextConfig
            {
                ConsistentRead = true,
                Conversion = DynamoDBEntryConversion.V2
            };
        }

        public void AddNewToken(AuthenticationUser user)
        {
            using(var context = new DynamoDBContext(_contextConfig))
            {
                Token token = new Token() { CreatedTime = DateTime.Now, IsValid = true, TokenId = TokenGenerator(), Username = user.Username };
                try
                {
                    context.Save(token);
                }
                catch(Exception ex)
                {
                    throw new SaveToDatabaseException("A problrm during the save to context operation", ex.InnerException);
                }
            }
        }

        private string TokenGenerator()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
