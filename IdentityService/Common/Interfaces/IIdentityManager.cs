using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IIdentityManager
    {
        void AddUser(string name, int age, string address, string workAddress);
    }
}
