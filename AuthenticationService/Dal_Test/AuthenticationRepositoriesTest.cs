﻿using System;
using Common.Models;
using Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dal_Test
{
    [TestClass]
    public class AuthenticationRepositoriesTest
    {
        [TestMethod]
        public void AddUserToDatabase_ShouldReturnTheWantedUser()
        {
            AuthenticationRepositories AR = new AuthenticationRepositories();
            AuthenticationUser user = new AuthenticationUser { UserId = "1", Password = "1234", Username = "itamar" };
            AR.AddUserToDatabase(user);
        }
    }
}
