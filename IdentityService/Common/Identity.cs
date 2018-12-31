using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Identity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }

        public Identity(string name, int age, string address, string workAddress)
        {
            FullName = name;
            Age = age;
            Address = address;
            WorkAddress = workAddress;
        }
    }
}
