using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace DictionGeneration
{
    public class DictionaryGeneration : IPlugin
    {

        public Type type
        {
            get { return typeof(Dictionary<,>); }
        }

        public object GenerateRandomValue(Type type)
        {
            return (IDictionary)Activator.CreateInstance(type);
        }
    }
}
