using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IIdentityRepository
    {
        void AddUserIdentity(UserIdentity user);
        void ModifyUserIdentity(UserIdentity user);
        IEnumerable<UserIdentity> GetAllUserIdentities();
        UserIdentity GetUserIdentity(string name);
        IEnumerable<UserIdentity> SearchUserIdentities(string fullName, int age);
        void DeleteUserIdentity(UserIdentity user);
    }
}
