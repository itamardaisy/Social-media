using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IValidation
    {
        bool CheckClientInputs(string name, string password);
    }
}
