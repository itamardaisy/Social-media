using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ITokenRepository
    {
        void AddNewToken(AuthenticationUser user);

        bool CheckIfTokenIsValid(Token token);
    }
}
