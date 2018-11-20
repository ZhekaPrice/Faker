using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BasicDoubleGenerator : IBasicGenerator
    {
        private Random random;

        public BasicDoubleGenerator()
        {
            random = new Random();
        }

        public object GenerateRandomValue()
        {
            return random.NextDouble();
        }
    }
}
