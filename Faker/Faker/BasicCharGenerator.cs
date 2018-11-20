using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BasicCharGenerator : IBasicGenerator
    {
        private Random random;

        public BasicCharGenerator()
        {
            random = new Random();
        }

        public object GenerateRandomValue()
        {
            var charString = "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm";
            return charString[random.Next(charString.Length)];
        }
    }
}
