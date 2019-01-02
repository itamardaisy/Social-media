﻿using Common;
using Common.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class IdentityManager : IIdentityManager
    {
        private readonly IIdentityRepository userLibrary;
        public IdentityManager(IIdentityRepository identityRepository)
        {
            userLibrary = identityRepository;
        }

        /// <summary>
        /// Add user to dynamoDb - call dal
        /// </summary>
        public void AddUser(UserIdentity user)
        {
            userLibrary.AddUserIdentity(user);
        }

        /// <summary>
        /// delete user from db - calling dal
        /// </summary>
        public void DeleteUser(string name, int age, string address, string workAddress)
        {
            var user = new UserIdentity
            {
                FullName = name,
                Age = age,
                Address = address,
                WorkAddress = workAddress
            };

            userLibrary.DeleteUserIdentity(user);
        }

        /// <summary>
        /// returns user by the name
        /// </summary>
        public UserIdentity GetUser(string email)
        {
            return userLibrary.GetUserIdentity(email);
        }

        /// <summary>
        /// update existing user
        /// </summary>
        public void UpdateUser(string name, int age, string address, string workAddress)
        {
            var user = new UserIdentity
            {
                FullName = name,
                Age = age,
                Address = address,
                WorkAddress = workAddress
            };

            userLibrary.ModifyUserIdentity(user);
        }
    }
}
