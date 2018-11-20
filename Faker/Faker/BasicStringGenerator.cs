using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BasicStringGenerator : IBasicGenerator
    {
        private Random random;

        public BasicStringGenerator(){
            random = new Random();
        }

        public object GenerateRandomValue()
        {
            string[] stringArray = { "MI:Chost Protocol", "MI:Rogue Nation", "MI:FallOut" };
            return stringArray[random.Next(0,3)];
        }
    }
}
