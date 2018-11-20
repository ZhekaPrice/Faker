using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BasicBoolGenerator : IBasicGenerator
    {
        public object GenerateRandomValue()
        {
            return true;
        }
    }
}
