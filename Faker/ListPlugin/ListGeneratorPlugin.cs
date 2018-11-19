using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace ListGeneratorPlugin
{
    public class ListGeneratorPlugin : IPlugin
    {
        public Type type
        {
            get { return typeof(List<>); }
        }

        public object GenerateRandomValue(Type type)
        {
            return (IList)Activator.CreateInstance(type);
        }
    }
}
