using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUseFaker
{
    public class PrivateClass
    {
        public int Age;
        public string Name;
        public bool IsTrue;

        private PrivateClass(int age, string name, bool istrue)
        {
            Age = age;
            Name = name;
            IsTrue = istrue;
        }
    }
}
