using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Tests
{
    [TestClass()]
    public class LoginServiceTest
    {
        [TestMethod()]
        public void LoginTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoginViaFacebookTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LogoutTest()
        {
            BL.LoginService loginService = new LoginService();
            var str = loginService.TokenGenerator();
            Assert.AreNotEqual("s/ldrjRjX0yynzYj37VcNA==", str);
        }
    }
}