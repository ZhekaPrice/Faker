using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUseFaker
{
    public class Foo
    {
        public int Age;
        public string Name;
        public bool IsTrue;
        public Bar Bar;
        public float Float;
        public long Long;
        public string Str1;

        public Foo(int age, string name, bool isTrue, Bar bar)
        {
            Age = age;
            Name = name;
            IsTrue = isTrue;
            Bar = bar;
        }
    }
}
