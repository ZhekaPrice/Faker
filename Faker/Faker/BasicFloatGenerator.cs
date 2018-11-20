using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BasicFloatGenerator : IBasicGenerator
    {
        private Random random;

        public BasicFloatGenerator()
        {
            random = new Random();
        }
        public object GenerateRandomValue()
        {
            return random.Next();
        }
    }
}
