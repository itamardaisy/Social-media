using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Identity
    {
        private string fullName;
        private int age;
        private string address;
        private string workAddress;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string WorkAddress
        {
            get { return workAddress; }
            set { workAddress = value; }
        }

    }
}
