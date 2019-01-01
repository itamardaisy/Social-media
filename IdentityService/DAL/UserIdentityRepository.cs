using Amazon.DynamoDBv2.DocumentModel;
using Common;
using Common.DynamoDB;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserIdentityRepository : IIdentityRepository
    {
        private readonly DynamoService _dynamoService;

        public UserIdentityRepository()
        {
            _dynamoService = new DynamoService();
        }

        /// <summary>
        ///  AddUserIdentity will accept a UserIdentity object and creates an Item on Amazon DynamoDB
        /// </summary>
        /// <param name="user"></param>
        public void AddUserIdentity(UserIdentity user)
        {
            _dynamoService.Store(user);
        }

        /// <summary>
        /// ModifyUserIdentity  tries to load an existing UserIdentity, modifies and saves it back. If the Item doesn’t exist, it raises an exception
        /// </summary>
        /// <param name="user"></param>
        public void ModifyUserIdentity(UserIdentity user)
        {
            _dynamoService.UpdateItem(user);
        }

        /// <summary>
        /// GetAllUserIdentities will perform a Table Scan operation to return all the UserIdentities
        /// </summary>
        public IEnumerable<UserIdentity> GetAllUserIdentities()
        {
            return _dynamoService.GetAll<UserIdentity>();
        }

        /// <summary>
        /// Search For User Identity
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="age"></param>
        public IEnumerable<UserIdentity> SearchUserIdentities(string fullName, int age)
        {
            IEnumerable<UserIdentity> filteredUserIdentities = _dynamoService.DbContext.Query<UserIdentity>(fullName, QueryOperator.Equal, age);

            return filteredUserIdentities;
        }

        public UserIdentity GetUserIdentity(string name)
        {
            return _dynamoService.GetItem<UserIdentity>(name);
        }

        /// <summary>
        /// Delete UserIdentity will remove an item from DynamoDb
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUserIdentity(UserIdentity user)
        {
            _dynamoService.DeleteItem(user);
        }
    }
}
