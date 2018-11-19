using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUseFaker
{
    public class Bar
    {
        public string Str;
        public double NewDouble;
        public List<int> IntList;
        public DateTime DateTime;
        public char Sumbol2;
        public DateTime DateTime1;

        public Bar(string str, double newDouble, List<int> intList, DateTime dateTime)
        {
            Str = str;
            NewDouble = newDouble;
            IntList = intList;
            DateTime = dateTime;
        }

    }
}
