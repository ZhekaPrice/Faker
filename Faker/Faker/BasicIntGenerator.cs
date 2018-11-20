using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BasicIntGenerator : IBasicGenerator
    {
        private Random random;

        public BasicIntGenerator()
        {
            random = new Random();
        }
        public object GenerateRandomValue()
        {
            return random.Next();
        }
    }
}
