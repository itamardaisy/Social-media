﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Common;
using Common.Exceptions;
using Common.Interfaces;
using Common.Models;
using Dal.TokenRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DynamoDBContextConfig _contextConfig;
        private readonly TokenRipository _tokenRipository;

        public UserRepository()
        {
            _contextConfig = new DynamoDBContextConfig
            {
                ConsistentRead = true,
                Conversion = DynamoDBEntryConversion.V2
            };
            _tokenRipository = new TokenRipository();
        }

        /// <summary>
        /// Add the AuthenticationUser after checking the user validatioon with class validation
        /// </summary>
        /// <param name="user"> The Added User </param>
        public void AddUserToDatabase(AuthenticationUser user)
        {
            using (var context = new DynamoDBContext(_contextConfig))
            {
                try
                {
                    if(CheckIfUserExist(user).Result)
                        context.Save(user);
                }
                catch (Exception ex){
                    throw new SaveToDatabaseException("A problrm during the save to context operation", ex.InnerException);
                }
            }
        }

        public async Task<bool> CheckIfUserExist(AuthenticationUser user)
        {
            using (var context = new DynamoDBContext(_contextConfig))
            {
                try
                {
                    var userCheck = await context.LoadAsync<AuthenticationUser>(user.Email);
                    return userCheck.Email == user.Email ? true : false;
                }
                catch(Exception ex)
                {
                    throw new GetFromDatabaseException("A problrm during the Load from context operation", ex.InnerException);
                }
            }
        }

        public async Task<AuthenticationUser> Login(string email, string password)
        {
            using (var context = new DynamoDBContext(_contextConfig))
            {
                var userCheck = await context.LoadAsync<AuthenticationUser>(email);
                if (userCheck != null)
                {
                    if (userCheck.Password == password)
                    {
                        _tokenRipository.AddNewToken(userCheck);
                        return userCheck;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
    }
}
