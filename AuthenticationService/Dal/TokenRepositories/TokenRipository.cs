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
        public void AddNewToken(AuthenticationUser user)
        {

        }

        public bool CheckIfTokenIsValid(Token token)
        {
            throw new NotImplementedException();
        }
    }
}
