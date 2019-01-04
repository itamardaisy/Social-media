using System;
using Common.Models;
using Dal.TokenRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dal_Test
{
    [TestClass]
    public class TokenRepositoryTest
    {
        [TestMethod]
        public void AddNewTokenTest()
        {
            AuthenticationUser user = new AuthenticationUser() { Email = "qdjnd@mewmf.fkemf", IsAvilable = true, Password = "dwqd", Username = "qdw" };
            TokenRipository tr = new TokenRipository();
            tr.AddNewToken(user);
        }
    }
}
