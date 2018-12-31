using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LoginService : ILoginService
    {
        public AuthenticationUser Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public AuthenticationUser LoginViaFacebook(string token)
        {
            throw new NotImplementedException();
        }

        public bool Logout(string token)
        {
            throw new NotImplementedException();
        }
    }
}
